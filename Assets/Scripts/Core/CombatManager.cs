using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    public static CombatManager Instance;

    public TurnSystem turnSystem;

    
    public PlayerData testPlayerData;
    public EnemyData testEnemyData;

    public PlayerCombatActor playerActor;
    public List<EnemyCombatActor> enemies = new List<EnemyCombatActor>();

    List<CombatAction> plannedActions = new List<CombatAction>();

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        
        if (playerActor == null && testPlayerData != null)
        {
            playerActor = new PlayerCombatActor(testPlayerData);
        }

        if (enemies.Count == 0 && testEnemyData != null)
        {
            enemies.Add(new EnemyCombatActor(testEnemyData));
            enemies.Add(new EnemyCombatActor(testEnemyData));
        }

        
        plannedActions = new List<CombatAction>();
        StartCoroutine(CombatLoop());
    }

    IEnumerator CombatLoop()
    {
        bool combatActive = true;

        while (combatActive)
        {
            plannedActions.Clear();

            yield return StartCoroutine(PlayerChooseAction());

            foreach (var enemy in enemies)
            {
                plannedActions.Add(new CombatAction
                {
                    actor = enemy,
                    target = playerActor,
                    actionType = ActionType.Attack,
                    speed = enemy.GetSpeed()
                });
            }

            plannedActions.Sort((a, b) => b.speed.CompareTo(a.speed));

          
            yield return StartCoroutine(turnSystem.ExecuteActions(plannedActions));

          

            
            if (enemies.TrueForAll(e => e.IsDead()))
            {
                Debug.Log("<color=green>¡VICTORIA! Todos los enemigos derrotados.</color>");
                combatActive = false;
                EndCombat(true);
            }
           
            else if (playerActor.IsDead())
            {
                Debug.Log("<color=red>DERROTA... El jugador ha caído.</color>");
                combatActive = false;
                EndCombat(false);
            }
        }
    }

    void EndCombat(bool victory)
    {
        if (victory)
        {
            Debug.Log("Volviendo a exploración...");

           
        }
        else
        {
            Debug.Log("Game Over. Volviendo al Lobby...");
        }
        GameManager.Instance.ExitCombat(victory);
    }

    IEnumerator PlayerChooseAction()
    {
        Debug.Log("PLAYER TURN:");
        Debug.Log("1 Attack | 2 Defend | 3 Skill | 4 Item");

        ActionType chosen = ActionType.Attack;
        bool selected = false;

        while (!selected)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1)) { chosen = ActionType.Attack; selected = true; }
            if (Input.GetKeyDown(KeyCode.Alpha2)) { chosen = ActionType.Defend; selected = true; }
            if (Input.GetKeyDown(KeyCode.Alpha3)) { chosen = ActionType.Skill; selected = true; }
            if (Input.GetKeyDown(KeyCode.Alpha4)) { chosen = ActionType.Item; selected = true; }
            yield return null;
        }

   
        ICombatActor target = null;

        if (chosen == ActionType.Attack || chosen == ActionType.Skill)
        {
            List<EnemyCombatActor> aliveEnemies = enemies.FindAll(e => !e.IsDead());
            if (aliveEnemies.Count > 0)
            {
                Debug.Log("SELECT TARGET:");
                for (int i = 0; i < aliveEnemies.Count; i++)
                {
                    Debug.Log((i + 1) + ": " + aliveEnemies[i].GetName() + " (HP: " + aliveEnemies[i].GetHP() + ")");
                }

                bool targetSelected = false;
                while (!targetSelected)
                {
                    for (int i = 0; i < aliveEnemies.Count; i++)
                    {
                        if (Input.GetKeyDown(KeyCode.Alpha1 + i))
                        {
                            target = aliveEnemies[i];
                            targetSelected = true;
                            break;
                        }
                    }
                    yield return null;
                }
            }
        }

        if (playerActor == null)
        {
            Debug.LogError("Error: playerActor es nulo. Asegúrate de asignarlo en el Inspector o Start.");
            yield break;
        }

        plannedActions.Add(new CombatAction
        {
            actor = playerActor,
            target = target, 
            actionType = chosen,
            speed = playerActor.GetSpeed(),
            multiplier = 1.0f 
        });

        Debug.Log("Player chose: " + chosen + " targeting " + (target != null ? target.GetName() : "None"));
    }
}

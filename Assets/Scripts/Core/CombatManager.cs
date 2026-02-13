using UnityEngine;

public class CombatManager : MonoBehaviour
{
    public static CombatManager Instance;

    public int turn = 1;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        StartCombat();
    }

    public void StartCombat()
    {
        Debug.Log("StartCombat llamado");
        Debug.Log("GameManager Instance: " + GameManager.Instance);
        GameManager.Instance.SetGameMode(GameManager.GameMode.Combat);
        turn = 1;
        Debug.Log("Combat started");
        StartTurn();
    }

    void StartTurn()
    {
        if (turn % 2 == 1)
        {
            Debug.Log("=== TURNO DEL JUGADOR ===");
        }
        else
        {
            Debug.Log("=== TURNO DEL ENEMIGO ===");
            Invoke(nameof(EnemyTurn), 1f);
        }
    }

    void EnemyTurn()
    {
        Debug.Log("Enemigo ataca...");
        EndTurn();
    }

    public void EndTurn()
    {
        turn++;
        StartTurn();
    }
}
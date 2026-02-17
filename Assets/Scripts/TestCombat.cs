using System.Collections.Generic;
using UnityEngine;

public class TestCombat : MonoBehaviour
{
    public PlayerDatabase playerDB;
    public EnemyDatabase enemyDB;
    public TurnSystem turnSystem;

    void Start()
    {
        Debug.Log("PlayerManager: " + PlayerManager.Instance);
        Debug.Log("playerDB: " + playerDB);
        Debug.Log("Characters length: " + playerDB.playableCharacters.Length);

        // elegir personaje 0
        PlayerManager.Instance.SetCharacter(playerDB.playableCharacters[0]);

        List<ICombatActor> actors = new List<ICombatActor>();

        actors.Add(new PlayerCombatActor());
        actors.Add(new EnemyCombatActor(enemyDB.enemies[0]));
        actors.Add(new EnemyCombatActor(enemyDB.enemies[1]));

        turnSystem.StartRound(actors);
    }
}
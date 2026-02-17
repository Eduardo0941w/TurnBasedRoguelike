using UnityEngine;

public class EnemyCombatActor : ICombatActor
{
    EnemyData data;

    public EnemyCombatActor(EnemyData d)
    {
        data = d;
    }

    public string GetName() => data.enemyName;
    public int GetSpeed() => data.speed;

    public void TakeTurn()
    {
        Debug.Log("ENEMY TURN: " + data.enemyName);
    }
}
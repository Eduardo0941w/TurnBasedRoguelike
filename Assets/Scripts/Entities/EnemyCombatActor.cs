using UnityEngine;
using System.Collections;

public class EnemyCombatActor : ICombatActor
{
    public EnemyData data;
    private int currentHP; 

    public EnemyCombatActor(EnemyData d)
    {
        data = d;
        currentHP = d.maxHP; 
    }

    public string GetName() => data.enemyName;
    public int GetSpeed() => data.speed;

    public IEnumerator TakeTurn(ICombatActor target, float multiplier)
    {
        Debug.Log($"{GetName()} ataca con ferocidad!");

        yield return new WaitForSeconds(1f);
    }
    public void TakeDamage(int amount)
    {
        currentHP -= amount;
        Debug.Log($"{GetName()} recibió {amount} de daño. HP restante: {currentHP}");

        if (currentHP <= 0)
        {
            currentHP = 0;
            Debug.Log($"<color=red>{GetName()} ha sido derrotado.</color>");
        }
    }
    public bool IsDead() => currentHP <= 0;
}
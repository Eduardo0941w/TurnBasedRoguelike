using UnityEngine;
using System.Collections;

public class PlayerCombatActor : ICombatActor
{
    public PlayerData data; 
    private int currentHP;

    public PlayerCombatActor(PlayerData d)
    {
        data = d;
        currentHP = d.maxHP;
    }

    public string GetName() => data.characterName;
    public int GetSpeed() => data.speed;

    public IEnumerator TakeTurn(ICombatActor target, float multiplier)
    {
       
        int finalDamage = Mathf.RoundToInt(data.damage * multiplier);

        Debug.Log($"{GetName()} ataca con su fuerza de {data.damage} (Total: {finalDamage})");


        yield return new WaitForSeconds(0.5f);
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
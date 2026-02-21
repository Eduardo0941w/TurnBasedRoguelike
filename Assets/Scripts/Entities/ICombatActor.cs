using System.Collections;

public interface ICombatActor
{
    string GetName();
    int GetSpeed();
    IEnumerator TakeTurn(ICombatActor target, float multiplier);
    void TakeDamage(int amount);
    bool IsDead();
}
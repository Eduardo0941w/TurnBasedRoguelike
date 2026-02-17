using UnityEngine;
public class PlayerCombatActor : ICombatActor
{
    public string GetName() => PlayerManager.Instance.currentPlayer.characterName;
    public int GetSpeed() => PlayerManager.Instance.currentPlayer.speed;

    public void TakeTurn()
    {
        Debug.Log("PLAYER TURN: " + GetName());
    }
}
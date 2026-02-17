using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Game/Player")]
public class PlayerData : ScriptableObject
{
    public string characterName;
    public int maxHP;
    public int damage;
    public int defense;
    public int speed;

    // Luego: ataques, perks, etc
}
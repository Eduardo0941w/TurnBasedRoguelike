using UnityEngine;

[CreateAssetMenu(fileName = "PlayerDatabase", menuName = "Game/Player Database")]
public class PlayerDatabase : ScriptableObject
{
    public PlayerData[] playableCharacters;
}
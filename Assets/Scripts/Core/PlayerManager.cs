using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance;

    public PlayerData currentPlayer;
    public int currentHP;

    private void Awake()
    {
        Instance = this;
    }
    public void SetCharacter(PlayerData data)
    {
        currentPlayer = data;
        currentHP = data.maxHP;
    }
}
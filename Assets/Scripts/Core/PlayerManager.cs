using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance;

    public PlayerData currentPlayer;
    public int currentHP;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            Debug.Log("PlayerManager creado");
        }
        else
        {
            Debug.Log("PlayerManager duplicado destruido");
            Destroy(gameObject);
        }
    }
    public void SetCharacter(PlayerData data)
    {
        currentPlayer = data;
        currentHP = data.maxHP;
    }
}
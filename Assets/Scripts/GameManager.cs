using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public enum GameMode
    {
        Exploration,
        Combat,
        Inventory,
        Menu
    }

    public GameMode currentGameMode;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        currentGameMode = GameMode.Exploration;
    }

    public bool CanPlayerMove()
    {
        return currentGameMode == GameMode.Exploration;
    }
}
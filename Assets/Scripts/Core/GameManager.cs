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

    [Header("Game State")]
    public GameMode currentGameMode = GameMode.Exploration;

    [Header("Managers")]
    public PlayerManager playerManager;
    public CombatManager combatManager;
    public PartyManager partyManager;
    public RunManager runManager;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            Debug.Log("GameManager creado");
        }
        else
        {
            Debug.Log("GameManager duplicado destruido");
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        SetGameMode(GameMode.Exploration);
    }

    // ---- GAME MODE CONTROL ----
    public void SetGameMode(GameMode newMode)
    {
        currentGameMode = newMode;

        // Aquí puedes notificar a otros sistemas
        Debug.Log("Game mode changed to: " + newMode);
    }

    public bool CanPlayerMove()
    {
        return currentGameMode == GameMode.Exploration;
    }

    public bool IsInCombat()
    {
        return currentGameMode == GameMode.Combat;
    }
}
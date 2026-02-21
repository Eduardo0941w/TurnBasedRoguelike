using UnityEngine;
using UnityEngine.SceneManagement;

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

    [Header("Scene Names")]
    public string explorationSceneName = "ExplorationScene";
    public string combatSceneName = "CombatScene";

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

    public void EnterCombat()
    {
        SetGameMode(GameMode.Combat);
        SceneManager.LoadScene(combatSceneName);
    }

    public void ExitCombat(bool victory)
    {
        if (victory)
        {
            Debug.Log("Volviendo a exploración tras victoria.");
            SetGameMode(GameMode.Exploration);
            SceneManager.LoadScene(explorationSceneName);
        }
        else
        {
            Debug.Log("Derrota. Volviendo al Lobby...");
            SetGameMode(GameMode.Exploration);
            SceneManager.LoadScene("LobbyScene");
        }
    }
    public void SetGameMode(GameMode newMode)
    {
        currentGameMode = newMode;

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
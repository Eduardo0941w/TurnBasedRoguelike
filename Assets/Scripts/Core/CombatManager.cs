using UnityEngine;

public class CombatManager : MonoBehaviour
{
    public static CombatManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void StartCombat()
    {
        GameManager.Instance.SetGameMode(GameManager.GameMode.Combat);
        Debug.Log("Combat started");
    }

    public void EndCombat()
    {
        GameManager.Instance.SetGameMode(GameManager.GameMode.Exploration);
        Debug.Log("Combat ended");
    }
}
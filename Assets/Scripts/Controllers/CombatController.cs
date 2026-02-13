using UnityEngine;

public class PlayerCombatController : MonoBehaviour
{
    void Update()
    {
        if (GameManager.Instance.currentGameMode != GameManager.GameMode.Combat)
            return;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Jugador ataca");
            CombatManager.Instance.EndTurn();
        }
    }
}
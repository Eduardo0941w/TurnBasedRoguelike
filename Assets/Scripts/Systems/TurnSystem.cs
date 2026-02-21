using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnSystem : MonoBehaviour
{
    public IEnumerator ExecuteActions(List<CombatAction> actions)
    {
        Debug.Log("<color=cyan>---- FASE DE EJECUCIÓN ----</color>");

        foreach (var action in actions)
        {
            if (action.actor.IsDead()) continue;

            yield return StartCoroutine(ExecuteAction(action));
        }
    }

    private IEnumerator ExecuteAction(CombatAction action)
    {
        
        if (action.actor.IsDead()) yield break;

        if (action.target != null && action.target.IsDead())
        {
            Debug.Log($"{action.actor.GetName()} intentó atacar a un objetivo ya derrotado.");
            yield break;
        }


        if (action.actor is PlayerCombatActor && action.actionType == ActionType.Attack)
        {
          
            yield return StartCoroutine(MinigameManager.Instance.StartMinigame((result) =>
            {
                action.multiplier = result;
            }));
        }

    
        if (action.actionType == ActionType.Attack && action.target != null)
        {
            
            int baseDamage = 0;

            if (action.actor is PlayerCombatActor player)
            {
                baseDamage = player.data.damage;
            }
            else if (action.actor is EnemyCombatActor enemy)
            {
                baseDamage = enemy.data.damage;
              
            }

           
            int finalDamage = Mathf.RoundToInt(baseDamage * action.multiplier);

            
            action.target.TakeDamage(finalDamage);

            Debug.Log($"<b>{action.actor.GetName()}</b> ataca a <b>{action.target.GetName()}</b> causando <color=red>{finalDamage}</color> de daño (Mult: x{action.multiplier})");
        }

        yield return action.actor.TakeTurn(action.target, action.multiplier);

        yield return new WaitForSeconds(0.5f);
    }
}
using System.Collections.Generic;
using UnityEngine;

public class TurnSystem : MonoBehaviour
{
    List<ICombatActor> turnList = new List<ICombatActor>();

    public void StartRound(List<ICombatActor> actors)
    {
        turnList = actors;

        // ordenar por velocidad
        turnList.Sort((a, b) => b.GetSpeed().CompareTo(a.GetSpeed()));

        Debug.Log("---- TURN ORDER ----");

        foreach (var actor in turnList)
        {
            actor.TakeTurn();
        }
    }
}
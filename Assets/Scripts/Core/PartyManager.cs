using UnityEngine;
using System.Collections.Generic;

public class PartyManager : MonoBehaviour
{
    public static PartyManager Instance;

    public List<CompanionData> companions = new List<CompanionData>();

    private void Awake()
    {
        Instance = this;
    }
}
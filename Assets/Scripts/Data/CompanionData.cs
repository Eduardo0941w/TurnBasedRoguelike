using System;
using System.Collections.Generic;

[Serializable]
public class CompanionData
{
    public string name;
    public int maxHP;
    public int currentHP;
    public float baseDamage;

    public Species species;
    public List<PerkData> perks = new List<PerkData>();
}

public enum Species
{
    Human,
    Beast,
    Robot,
    Alien
}
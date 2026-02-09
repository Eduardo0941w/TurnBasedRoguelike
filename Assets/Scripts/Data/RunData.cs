using System;
using System.Collections.Generic;

[Serializable]
public class RunData
{
    public int seed;
    public int floor;

    public List<PerkData> runPerks = new List<PerkData>();

    public RunData(int seed)
    {
        this.seed = seed;
        floor = 1;
    }
}
using UnityEngine;

public class RunManager : MonoBehaviour
{
    public int seed;
    public int floor;
    public RunData currentRun;

    public void StartRun()
    {
        seed = Random.Range(0, 9999999);
        floor = 1;
        currentRun = new RunData(seed);
    }

    public void NextFloor()
    {
        floor++;
    }
}
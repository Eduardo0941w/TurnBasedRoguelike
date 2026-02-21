public class TurnAction
{
    public ICombatActor actor;
    public int speed;
    public string moveName;
    public int priority;

    public TurnAction(ICombatActor a, string move, int prio)
    {
        actor = a;
        moveName = move;
        speed = a.GetSpeed();
        priority = prio;
    }
}
public enum ActionType
{
    Attack,
    Defend,
    Skill,
    Item
}

public class CombatAction
{
    public ICombatActor actor;
    public ICombatActor target;
    public ActionType actionType;
    public int speed;
    public float multiplier = 1f;
}
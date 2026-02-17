using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "Game/Enemy")]
public class EnemyData : ScriptableObject
{
    public string enemyName;
    public int maxHP;
    public int damage;
    public int defense;
    public int speed;
}
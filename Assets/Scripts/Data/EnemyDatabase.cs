using UnityEngine;

[CreateAssetMenu(fileName = "EnemyDatabase", menuName = "Game/Enemy Database")]
public class EnemyDatabase : ScriptableObject
{
    public EnemyData[] enemies;
}
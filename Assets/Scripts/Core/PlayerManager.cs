using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance;

    public int maxHP = 100;
    public int currentHP = 100;
    public float baseDamage = 10f;

    private void Awake()
    {
        Instance = this;
    }
}
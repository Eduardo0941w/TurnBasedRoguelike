using UnityEngine;

[CreateAssetMenu(fileName = "NewPerk", menuName = "Roguelike/Perk")]
public class PerkData : ScriptableObject
{
    public string perkName;
    public string description;

    public float damageMultiplier = 1f;
    public float hpBonus = 0f;

    public bool affectsParty = false;
}
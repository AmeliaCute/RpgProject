using UnityEngine;

[CreateAssetMenu(fileName = "Artifact", menuName = "RpgProject/Artifact")]
public class Artifact : Item
{
    public enum Type(int EquipSlot)
    {
        Ring = 0,
        Crown = 1,
        Amulet = 2,
    }

    public enum UpgradeType
    {
        hp,
        endurance,
        def,
        dmg,
        mana,
    }

    public float UpgradeValue = 0;
}
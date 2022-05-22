using UnityEngine;

[CreateAssetMenu(fileName = "Armor", menuName = "RpgProject/Armor")]
public class Armor : ForgedItem
{
    public enum slot
    {
        Head,
        Chest,
        Leg,
        Feet,
    }

    public int MagiqueResistance = 0;
    public int PhysiqueResistance = 0;
}

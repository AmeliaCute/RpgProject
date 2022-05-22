using UnityEngine;

[CreateAssetMenu(fileName = "Other", menuName = "RpgProject/Other")]
public class Other : Item
{
    public enum type
    {
        Useless,
        Ressource,
        Quest,
        Essential,
    }

    public type Type = type.Useless;
}

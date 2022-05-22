using UnityEngine;

[CreateAssetMenu(fileName = "Sword", menuName = "RpgProject/Sword")]
public class Sword : ForgedItem
{
    public int Damage = 0;
    public int reloadTime = 500/*ms*/;
}

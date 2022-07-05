using UnityEngine;


[CreateAssetMenu(fileName = "Pickaxe", menuName = "RpgProject/Pickaxe")]
public class Pickaxe : ForgedItem
{
    public float DamageToOre = 0;
    public float reloadTime = 0.5f /*seconde*/;

    public float getDamage() { return DamageToOre; }
    public float getReloadTime() { return reloadTime; }
}
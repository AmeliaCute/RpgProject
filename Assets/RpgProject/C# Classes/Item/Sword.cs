using UnityEngine;

[CreateAssetMenu(fileName = "Sword", menuName = "RpgProject/Sword")]
public class Sword : ForgedItem
{
    public float Damage = 0;
    public float reloadTime = 0.5f /*seconde*/;
    public float attackRange = 1.0f;

    public float getDamage() { return Damage; }
    public float getReloadTime() { return reloadTime; }
    public float getAttackRange() { return attackRange; }
}
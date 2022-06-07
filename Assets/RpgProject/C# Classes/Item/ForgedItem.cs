using UnityEngine;

//Base for craftable Item
public class ForgedItem : Item
{
    public enum Quality
    {
        S,
        A,
        B, 
        C,
        D,
    }

    public float Durability = 1000; 
    public Quality quality = Quality.B;
<<<<<<< Updated upstream
=======

    public int getDurability() { return Durability; }
    public void DamageItem(float damage) { Durability -= damage; }
    public bool isBroken() { if(Durability <= 0) { return true; } return false; }
>>>>>>> Stashed changes
}

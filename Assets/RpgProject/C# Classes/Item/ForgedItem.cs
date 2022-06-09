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

    public float getDurability() { return Durability; }
    public void DamageItem(float damage) { Durability -= damage; }
}

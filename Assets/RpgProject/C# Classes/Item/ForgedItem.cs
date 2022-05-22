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

    public int Durability = 1000; 
    public Quality quality = Quality.B;
}

using UnityEngine;

//Base for all item
public class Item : ScriptableObject
{
    public string _name = ""; 
    public string description; 

    public int price = 0;
    public GameObject itemModel;
    public Sprite itemIcon;
}

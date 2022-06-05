using System;
using System.Diagnostics;
using UnityEngine;

//Base for all item
public class Item : ScriptableObject
{
    public string _name = ""; 
    public string description; 

    public int price = 0;
    public GameObject itemModel;
    public Sprite itemIcon;

    public readonly string uuid = Guid.NewGuid().ToString(); //DONT TOUCH

    public string getName() { return _name; }
    public string getDescription() { return description;  }
    public int getPrice() { return price; }
    public GameObject getModel() { return itemModel; }
    public Sprite getIcon() { return itemIcon; }
    public string getUuid() { return uuid; }
}

using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemFlag 
{
    public string itemName;
    public Sprite icon;
    [TextArea]
    public string description;
    public List<ItemAttribute> attribute;
}
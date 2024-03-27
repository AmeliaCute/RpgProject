using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemFlag 
{
    public string itemName;
    public Sprite icon;
    [TextArea]
    public string description;
    public ItemRarity itemRarity = ItemRarity.Common;
    public List<ItemAttribute> attribute;
    
    public Color getRarityColor()
    {
        switch(itemRarity)
        {
            case ItemRarity.Common:
                return new(1, 0.5109494f, 1); 
            case ItemRarity.Rare:
                return new(0, 0.9062204f, 1); 
            case ItemRarity.Epic:
                return new(0.7881236f,0,1);
            case ItemRarity.Legendary:
                return new(1, 0.8796524f, 0);
            case ItemRarity.Mythic:
                return new(1, 0, 0.2953343f);
            case ItemRarity.Unique:
                return new(1, 0, 0.5774722f);
            default:
                return new(1,1,1);
        }
    }
}

public enum ItemRarity  {
    Common,
    Rare,
    Epic,
    Legendary,
    Mythic,
    Unique,
}
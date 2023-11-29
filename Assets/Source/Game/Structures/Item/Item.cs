using System;
using System.Collections.Generic;
using UnityEngine;

namespace RpgProject.Objects
{
    [Serializable]
    public enum Rarity
    {
        COMMON,
        UNCOMON,
        RARE,
        EPIC,
        LEGENDARY,
        MYTHIC,
        UNIQUE
    }

    [Serializable]
    public class Item
    {
        private string name;
        private string description; 
        public virtual string type => "unknown"; 
        public virtual string subtype => "unknown";
        private int price;

        [System.NonSerialized]
        private Mesh itemModel;
        private string itemIcon;
        private Rarity itemRarity;
        public virtual int stackSize => 128;

        public Item(string name, Rarity rarity, string description, int price, Mesh itemModel, string itemIcon)
        {
            this.name = name;
            this.description = description;
            this.price = price;
            this.itemModel = itemModel;
            this.itemIcon = itemIcon;
            this.itemRarity = rarity;
            RpgClass.LOGGER.Log("Item created: " + this.name + " (" + this.type + ")");
        }

        public string getName() { return name; }
        public string getDescription() { return description;  }
        public int getPrice() { return price; }
        public Mesh getModel() { return itemModel; }
        public Sprite getIcon() { return Resources.Load<Sprite>(itemIcon); }
        public Rarity getRarity() { return itemRarity; }
        public int getStackSize() { return stackSize; }

        public Color32 getRarityColor()
        {
            switch (itemRarity)
            {
                case Rarity.UNCOMON:
                    return new Color32(165, 165, 165, 255);
                case Rarity.COMMON:
                    return new Color32(72, 252, 96, 255);
                case Rarity.RARE:
                    return new Color32(35, 151, 226, 255);
                case Rarity.EPIC:
                    return new Color32(169, 5, 213, 255);
                case Rarity.LEGENDARY:
                    return new Color32(250, 218, 57, 255);
                case Rarity.MYTHIC:
                    return new Color32(251, 87, 241, 255);
                case Rarity.UNIQUE:
                    return new Color32(234, 27, 27, 255);
            }
            return new Color32(255, 255, 255, 255);
        }

        [ObsoleteAttribute("Use getRarityColor instead")]
        public Sprite getSpriteFromRarity()
        {
            switch(itemRarity)
            {
                case Rarity.COMMON:
                    return Resources.Load<Sprite>("Sprites/Inventory/items/Rarity/common"); 
                case Rarity.UNCOMON:
                    return Resources.Load<Sprite>("Sprites/Inventory/items/Rarity/uncommon"); 
                case Rarity.RARE:
                    return Resources.Load<Sprite>("Sprites/Inventory/items/Rarity/rare"); 
                case Rarity.EPIC:
                    return Resources.Load<Sprite>("Sprites/Inventory/items/Rarity/epic"); 
                case Rarity.LEGENDARY:
                    return Resources.Load<Sprite>("Sprites/Inventory/items/Rarity/legendary"); 
                default: 
                    return Resources.Load<Sprite>("Sprites/Inventory/items/Rarity/common"); 
            }
        }
    }    
}
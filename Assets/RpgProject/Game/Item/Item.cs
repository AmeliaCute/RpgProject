using System.Collections.Generic;
using UnityEngine;

namespace RpgProject.Objects
{
    public enum Rarity
    {
        COMMON,
        UNCOMON,
        RARE,
        EPIC,
        LEGENDARY,
    }

    public class Item
    {
        private string name;
        private string description; 
        public virtual string type => "unknown"; 
        public virtual string secret_type => "unknown";
        private int price;
        private Mesh itemModel;
        private Sprite itemIcon;
        private Rarity itemRarity;
        public virtual int stackSize => 128;

        public Item(string name, Rarity rarity, string description, int price, Mesh itemModel, Sprite itemIcon)
        {
            this.name = name;
            this.description = description;
            this.price = price;
            this.itemModel = itemModel;
            this.itemIcon = itemIcon;
            this.itemRarity = rarity;
            RpgClass.RPGLOGGER.Log("Item created: " + this.name + " (" + this.type + ")");
        }

        public string getName() { return name; }
        public string getDescription() { return description;  }
        public int getPrice() { return price; }
        public Mesh getModel() { return itemModel; }
        public Sprite getIcon() { return itemIcon; }
        public Rarity getRarity() { return itemRarity; }
        public int getStackSize() { return stackSize; }

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
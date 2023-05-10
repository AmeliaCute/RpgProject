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
        }

        public string getName() { return name; }
        public string getDescription() { return description;  }
        public int getPrice() { return price; }
        public Mesh getModel() { return itemModel; }
        public Sprite getIcon() { return itemIcon; }
        public Rarity getRarity() { return itemRarity; }
        public int getStackSize() { return stackSize; }
    }    
}
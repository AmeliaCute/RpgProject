using System;
using System.Collections.Generic;
using UnityEngine;

namespace RpgProject.Objects
{
    [Serializable]
    public enum Quality
    {
        S,
        A,
        B, 
        C,
        D,
    }

    [Serializable]
    public class ForgedItem : Item 
    {
        private float Durability;
        private Quality quality;
        public override int stackSize => 1;

        public ForgedItem(string name, Rarity rarity, string description, int price, Mesh itemModel, string itemIcon, float Durability, Quality quality): base(name,rarity, description, price, itemModel, itemIcon)
        {
            this.Durability = Durability;
            this.quality = quality;
        }

        public float getDurability() { return this.Durability; }
        public void DamageItem(float damage) { this.Durability -= damage; }
        public Quality getQuality() { return quality; } 
    }
}
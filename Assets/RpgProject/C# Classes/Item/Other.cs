using System.Collections.Generic;
using UnityEngine;

namespace RpgProject.Objects
{
    public enum type 
    {
        Useless,
        Ressource,
        Quest,
        Essential
    }

    public class Other : Item 
    {
        private type type;
        
        public Other(string name, Rarity rarity, string description, int price, Mesh itemModel, Sprite itemIcon, type type): base(name, rarity, description, price, itemModel, itemIcon)
        {
            this.type = type;
        }

        public type getType() { return this.type; }
    }
}
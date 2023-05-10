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
        private type classtype;
        public override string type => "other";

        public Other(string name, Rarity rarity, string description, int price, Mesh itemModel, Sprite itemIcon, type type): base(name, rarity, description, price, itemModel, itemIcon)
        {
            this.classtype = type;
        }

        public type getType() { return this.classtype; }
    }
}
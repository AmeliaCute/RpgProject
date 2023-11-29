using System;
using System.Collections.Generic;
using UnityEngine;

namespace RpgProject.Objects
{
    [Serializable]
    public enum type 
    {
        Useless,
        Ressource,
        Quest,
        Essential
    }

    [Serializable]
    public class Other : Item 
    {
        private type classtype;
        public override string type => "other";

        public Other(string name, Rarity rarity, string description, int price, Mesh itemModel, string itemIcon, type type): base(name, rarity, description, price, itemModel, itemIcon)
        {
            this.classtype = type;
        }

        public type getType() { return this.classtype; }
    }
}
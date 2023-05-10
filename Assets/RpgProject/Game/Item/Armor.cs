using System.Collections.Generic;
using UnityEngine;

namespace RpgProject.Objects
{
    public enum slot
    {
        Head,
        Chest,
        Leg,
        Feet,
    }

    public class Armor : ForgedItem
    {
        private slot slot;
        private int MagicResistance;
        private int PhysiqueResistance;
        public override string type => "armor";

        public Armor(string name, Rarity rarity, string description, int price, Mesh itemModel, Sprite itemIcon, float Durability, Quality quality, int MagicRes, int PhyRes, slot slot): base(name, rarity, description, price, itemModel, itemIcon, Durability, quality)
        {
            this.slot = slot;
            this.MagicResistance = MagicRes;
            this.PhysiqueResistance = PhyRes;
        }
    }
}
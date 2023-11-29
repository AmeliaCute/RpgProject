using System.Collections.Generic;
using UnityEngine;
using System;

namespace RpgProject.Objects
{
    [Serializable]
    public class Pickaxe : ForgedItem
    {
        private float DamageToOre;
        private float reloadTime;
        public override string type => "tools";

        public Pickaxe(string name, Rarity rarity, string description, int price, Mesh itemModel, string itemIcon, float Durability, Quality quality, float DamageToOre, float reloadTime) : base(name, rarity, description, price, itemModel, itemIcon, Durability, quality)
        {
            this.DamageToOre = DamageToOre;
            this.reloadTime = reloadTime;
        }

        public float getDamage() { return DamageToOre; }
        public float getReloadTime() { return reloadTime; }
    }
}
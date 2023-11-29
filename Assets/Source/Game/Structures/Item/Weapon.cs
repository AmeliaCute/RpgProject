using System.Collections.Generic;
using UnityEngine;
using System;

namespace RpgProject.Objects
{   
    [Serializable]
    public class Weapon : ForgedItem
    {
        public int Damage;
        public float reloadTime;
        public float attackRange;
        public override string type => "weapon";

        public Weapon(string name, Rarity rarity, string description, int price, Mesh itemModel, string itemIcon, float Durability, Quality quality, int Damage, float Reloadtime,int attackRange): base(name,rarity, description, price, itemModel, itemIcon, Durability, quality)
        {
            this.Damage = Damage;
            this.reloadTime = Reloadtime;
            this.attackRange = attackRange;
        }

        public int getDamage() { return Damage; }
        public float getReloadTime() { return reloadTime; }
        public float getAttackRange() { return attackRange; }
    }
}
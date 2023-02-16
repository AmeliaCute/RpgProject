using System.Collections.Generic;
using UnityEngine;

namespace RpgProject.Objects
{
    public class Sword : ForgedItem
    {
        private int Damage;
        private float reloadTime;
        private float attackRange;

        public Sword(string name, Rarity rarity, string description, int price, Mesh itemModel, Sprite itemIcon, float Durability, Quality quality, int Damage, float Reloadtime,int attackRange): base(name,rarity, description, price, itemModel, itemIcon, Durability, quality)
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
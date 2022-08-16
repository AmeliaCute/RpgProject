using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InventoryStats : MonoBehaviour 
{    
    public List<Stat> stats = new List<Stat>()
    {
        new Stat("Stamina", 100, 0), // Affect the time of sprinting
        new Stat("Vitality", 100, 0), // Affect the health of the player
        new Stat("Strength", 0, 0), // Affect the damage of the player to an entity
        new Stat("Intelligence", 0, 0), // Affect the damage of the player to an entity or the things he can do
        new Stat("Dexterity", 0, 0), // Affect the usage of a bow, and long distance attacks weapons
        new Stat("Luck", 0, 0),// Affect the chance of getting an item or a quest or the chance to crit
    };

    public void AddBonusToStat(string statName, int bonus)
    {
        foreach (Stat stat in stats)
        {
            if (stat.getName() == statName)
            {
                stat.AddBonus(bonus);
                return;
            }
        }
    }

    public void RemoveBonusFromStat(string statName, int bonus)
    {
        foreach (Stat stat in stats)
        {
            if (stat.getName() == statName)
            {
                stat.RemoveBonus(bonus);
                return;
            }
        }
    }

    public Stat getStat(string statName)
    {
        for(int i = 0; i < stats.Count; ++i)
        {
            if(stats[i].getName() == statName)
            {
                return stats[i];
            }
        }
        return null;
    }

    public Stat getStatFromInt(int index)
    {
        try
        {
            return stats[index];
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
            return null;
        }
    }

    // REMOVE
    private void Update() {
        if (Input.GetKeyDown(KeyCode.P))
        {
            foreach (Stat stat in stats)
            {
                Debug.Log(stat.getName() + ": " + stat.GetTotal());
            }
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            foreach (Stat stat in stats)
            {
                stat.AddBonus(10);
            }
        }
        if(Input.GetKeyDown(KeyCode.I))
        {
            InventorySlot slot = GetComponent<InventorySlot>();

            slot.UnequipWeapon();
            slot.ChangeWeapon((Sword) slot.getBackpack()[0]);
        }
    }
}
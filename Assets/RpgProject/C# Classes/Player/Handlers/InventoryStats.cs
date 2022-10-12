using System.Collections.Generic;
using System;
using UnityEngine;

public class InventoryStats 
{    
    public static List<Stat> stats = new List<Stat>()
    {
        new Stat("Stamina", 100, 0), // Affect the time of sprinting
        new Stat("Vitality", 100, 0), // Affect the health of the player
        new Stat("Strength", 0, 0), // Affect the damage of the player to an entity
        new Stat("Intelligence", 0, 0), // Affect the damage of the player to an entity or the things he can do
        new Stat("Dexterity", 0, 0), // Affect the usage of a bow, and long distance attacks weapons
        new Stat("Luck", 0, 0),// Affect the chance of getting an item or a quest or the chance to crit
    };

    public static void AddBonusToStat(string statName, int bonus) { 
        if(getStat(statName) != null) getStat(statName).AddBonus(bonus); 
    }

    public static void RemoveBonusFromStat(string statName, int bonus) { 
        if(getStat(statName) != null) getStat(statName).RemoveBonus(bonus); 
    }

    public static Stat getStat(string statName)
    {
        foreach(Stat stat in stats)
            if(stat.getName() == statName)
                return stat;
        return null;
    }

    public static Stat getStatFromInt(int index)
    {
        try { return stats[index]; }
        catch (Exception e) { Debug.Log(e.Message); }
        return null;
    }
}
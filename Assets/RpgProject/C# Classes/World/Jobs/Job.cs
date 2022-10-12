using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class Job
{
    public static event UnityAction StatsUpdateEvent;
    public string Name;
    public List<StatModifier> StatModifiers;
    public int level;
    public int exp;

    /// <summary>
    /// Constructor for Job class
    /// <arg name="name">Name of the job</arg>
    /// <arg name="statModifiers">List of stat modifiers</arg>
    /// </summary>
    public Job(string name, List<StatModifier> statModifiers, int level, int exp)
    {
        Name = name;
        StatModifiers = statModifiers;
        this.level = level;
        this.exp = exp;
    }

    public void AddBonus()
    {
        if(level == 0) return;
        for(int i = 0; i < StatModifiers.Count; i++)
        {
            InventoryStats.AddBonusToStat(StatModifiers[i].getName(), StatModifiers[i].getValue()*level);
            StatsUpdateEvent?.Invoke();
        }
    }

    public void RemoveBonus()
    {
        if(level == 0) return;
        for(int i = 0; i < StatModifiers.Count; i++)
        {
            InventoryStats.RemoveBonusFromStat(StatModifiers[i].getName(), StatModifiers[i].getValue()*level);
            StatsUpdateEvent?.Invoke();
        }
    }

    public string getLevelName()
    {
        switch(level)
        {
            case 0:
                return "Novice";
            case 1:
                return "Néophyte";
            case 2:
                return "Apprenti";
            case 3:
                return "Adepte";
            case 4:
                return "Expert";
            case 5:
                return "Maitre";
            case 6:
                return "Grand Maitre";
            case 7:
                return "Legende";
            case 8:
                return "Mythique";
            case 9:
                return "Immortel";
            case 10:
                return "Dieu";            
        }
        return "NULL";
    }

    public int getLevelExp(int i)
    {
        switch(i)
        {
            case 0:
                return 0;
            case 1:
                return 100;
            case 2:
                return 500;
            case 3:
                return 2200;
            case 4:
                return 6000;
            case 5:
                return 15000;
            case 6:
                return 25000;
            case 7:
                return 59800;
            case 8:
                return 80000;
            case 9:
                return 125000;
            case 10:
                return 180000;
        }
        return 0;
    }

    public void LevelUp()
    {
        if(level <= 10)
        {
            if(level != 0)
                RemoveBonus();
            AddBonus();
            level++;
            exp = 0;
        }
    }

    public void AddExp(int exp)
    {
        this.exp += exp;
        if(this.exp >= getLevelExp(level + 1)) LevelUp();
    }

    public string getName() { return Name; }

}
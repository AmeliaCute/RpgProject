using UnityEngine.Events;
using UnityEngine;

public class Stat
{

    public static event UnityAction StatsUpdateEvent;

    public int BaseValue;
    public int Bonus;

    public string name;

    public Stat(string name, int baseValue, int bonus)
    {
        this.BaseValue = baseValue;
        this.Bonus = bonus;
        this.name = name;
    }

    public int GetTotal() { return BaseValue + Bonus; }

    public void AddBonus(int bonus)
    {
        Bonus += bonus;
        StatsUpdateEvent?.Invoke();
    }

    public void RemoveBonus(int bonus)
    {
        if(Bonus - bonus < 0) Bonus = 0;
        else Bonus -= bonus;
        StatsUpdateEvent?.Invoke();
    }

    public void SetBaseValue(int baseValue)
    {
        StatsUpdateEvent?.Invoke();
        BaseValue = baseValue;
    }

    public void SetBonus(int bonus)
    {
        StatsUpdateEvent?.Invoke();
        Bonus = bonus;
    }

    public string getName()
    {
        return name;
    }
}
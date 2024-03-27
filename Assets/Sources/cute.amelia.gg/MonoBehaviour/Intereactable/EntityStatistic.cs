using UnityEngine;

[System.Serializable]
public class Statistic
{
    [Range(0,999)]
    public float baseValue;
    [Range(-999,999)]
    public float bonusValue;

    public Statistic(float baseValue, float bonusValue)
    {
        this.baseValue = baseValue;
        this.bonusValue = bonusValue;
    }

    public float TotalValue => baseValue + bonusValue;
}
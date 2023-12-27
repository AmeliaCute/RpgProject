[System.Serializable]
public class Statistic
{
    public float baseValue;
    public float bonusValue;

    public Statistic(float baseValue, float bonusValue)
    {
        this.baseValue = baseValue;
        this.bonusValue = bonusValue;
    }

    public float TotalValue => baseValue + bonusValue;
}
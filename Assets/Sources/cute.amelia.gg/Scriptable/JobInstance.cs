using UnityEngine;

[System.Serializable]
public class JobInstance
{
    public JobData jobData;
    public int level;
    public int exp;

    public void AddExp(int x)
    {
        exp += x;
        UpdateLevel();
    }

    public void UpdateLevel()
    {
        if(exp >= jobData.levelExp[level])
        {
            level += 1;
            exp -= jobData.levelExp[level - 1];
        }
    }
}
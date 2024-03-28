using System.Collections.Generic;
using UnityEngine;

[System.Serializable, CreateAssetMenu(menuName = "RpgProject/JobData")] 
public class JobData : ScriptableObject
{
    public new string name;
    [TextArea]
    public string description;
    [Range(1,20)]
    public int maxLevel;
    public int[] levelExp;
    public List<JobQuest> quests;

}
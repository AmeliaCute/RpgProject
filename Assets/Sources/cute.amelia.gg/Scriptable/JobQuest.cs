using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "RpgProject/JobQuest")]
public class JobQuest : ScriptableObject
{
    public string questName, description;
    public int levelRequire, experienceReward, goldReward; 
    public QuestObjective objectives;
    public bool finished;
}
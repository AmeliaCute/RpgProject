using UnityEngine;

[CreateAssetMenu(menuName = "RpgProject/QuestObjective")]
public class QuestObjective : ScriptableObject
{
    public string customName = null;
    public int currentAmount;
    public int targetAmount;
}
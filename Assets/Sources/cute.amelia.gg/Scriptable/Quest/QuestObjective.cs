using UnityEngine;

[System.Serializable, CreateAssetMenu(menuName = "RpgProject/QuestObjective")]
public class QuestObjective : ScriptableObject
{
    public string customName = null;
    public string actionDescription = null;
    public int currentAmount;
    public int targetAmount;
    public bool hidden = false;
}
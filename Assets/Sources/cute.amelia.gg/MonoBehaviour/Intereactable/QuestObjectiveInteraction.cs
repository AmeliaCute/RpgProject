using System.Collections.Generic;
using UnityEngine;

public class QuestObjectiveInteraction : MonoBehaviour
{
    [SerializeField] private List<QuestObjective> questObjectives;
    public delegate void OnQuestObjectiveComplete(Quest quest, int Step);
    public static event OnQuestObjectiveComplete OnQuestObjectiveCompleteEvent;

    public void CompleteObjective() 
    {
        Quest curr = FindAnyObjectByType<QuestManager>().current;
        QuestObjective qObj = questObjectives.Find(x => x == curr.Objectives[curr.Step]);

        if(qObj != null)
            OnQuestObjectiveCompleteEvent(curr, curr.Step);

        return;
    }
}
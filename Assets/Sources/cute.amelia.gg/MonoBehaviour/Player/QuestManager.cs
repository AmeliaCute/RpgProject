using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public List<Quest> quests;
    public Quest current;
    private WidgetQuest w_Quest;

    private void Awake()
    {
        QuestObjectiveInteraction.OnQuestObjectiveCompleteEvent += PublishUpdate;
        w_Quest = FindObjectOfType<WidgetQuest>();
    }

    void Start()
    {
        if (current != null)
            w_Quest.Setup(current, current.Step);
    }

    public void PublishUpdate(Quest quest, int step)
    {
        Quest puQuest = quests.Find(x => x == quest);
        if (++step == puQuest.Objectives.Count)
        {
            puQuest.Step++;
            puQuest.isFinished = true;
            current = null;
            w_Quest.Hide();
        }
        else
        {
            puQuest.Step++;
            if (current != null)
                w_Quest.Setup(current, current.Step);
        }
    }
}
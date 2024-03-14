using UnityEngine;
using UnityEngine.UI;

public class QuestNotif : MonoBehaviour
{
    [SerializeField] private Text infos, questName;

    public void Setup(QuestStateType type, string quest)
    {
        infos.text = type.ToString();
        questName.text = quest;
    }
}

public enum QuestStateType
{
    QUEST_STATE_NONE,
    QUEST_STATE_STARTED,
    QUEST_STATE_COMPLETED,
    QUEST_STATE_FAILED,
}
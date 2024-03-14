using UnityEngine;
using UnityEngine.UI;

public class JobAdvancementQuestObject : MonoBehaviour
{
    public Text title, description, earnC, earnE, advancement;
    public Image background;

    public JobAdvancementQuestObject Setup(JobQuest jobQuest)
    {
        title.text = jobQuest.questName;
        description.text = jobQuest.description;
        earnC.text = jobQuest.goldReward.ToString();
        earnE.text = jobQuest.experienceReward.ToString();
        advancement.text = jobQuest.objectives.currentAmount + "/" + jobQuest.objectives.targetAmount;
        return this;
    }

    public JobAdvancementQuestObject SetColor(Color color)
    {
        background.color = color;
        return this;
    }
}
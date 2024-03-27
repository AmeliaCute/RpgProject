using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class WidgetQuest : MonoBehaviour
{
    [SerializeField] private Text title,action;
    [SerializeField] private Animator animator;
    [SerializeField] private Image icon;

    public void Setup(Quest quest, int step) 
    {
        QuestObjective qObj = quest.Objectives[step];
        title.text = qObj.customName;
        action.text = qObj.actionDescription;
        icon.sprite = quest.GetRaritySprite();
        
        animator.Play(null);
        animator.Play("QuestWidgetNew");
    }

    public void Hide()
    {
        animator.Play("QuestWidgetHide");
    }
}
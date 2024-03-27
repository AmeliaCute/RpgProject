using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "RpgProject/Quest")]
public class Quest : ScriptableObject
{
    public string Name;
    public string TriviaDescription;
    public QuestRarity Rarity;
    public List<QuestObjective> Objectives;
    public int Step = 0; // If Step = size of Objectives that mean quest is finished (start from 0)
    public bool isFinished = false;

    public List<QuestObjective> UnlockCondition; 
    public bool isInstantUnlockAfterMetCondition = false;

    public Sprite GetRaritySprite() {
        switch(Rarity)
        {
            case QuestRarity.Common:
                return Resources.Load<Sprite>("Sprite/quest-normal");
            case QuestRarity.Important:
                return Resources.Load<Sprite>("Sprite/quest-important");
            case QuestRarity.Special:
                return Resources.Load<Sprite>("Sprite/quest-special");
            default:
                return null;
        }
    }
}

public enum QuestRarity { Common, Important, Special }
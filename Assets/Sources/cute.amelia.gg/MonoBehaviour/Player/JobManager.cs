using System.Collections.Generic;
using UnityEngine;

public class JobManager : MonoBehaviour
{   

   /*** 0 = Miner
    *** 1 = Wood cuter
    *** 2 = Paladin
    *** 3 = Mercenary
    *** 4 = Tank
    *** 5 = Cook
    *** 6 = Blacksmith
    ***/
    public List<JobInstance> jobs;


    void Start()
    {
        EnduranceTaskSystem.OnEnduranceTaskCompleteEvent += PublishUpdate;
    }

    public void PublishUpdate(QuestObjective quest, int offset)
    {
        JobInstance job = jobs[offset];
        JobQuest jQuest = job.jobData.quests.Find(x => x.objectives == quest);
        if(jQuest != null)
        {
            if(!jQuest.finished)
            {
                jQuest.objectives = quest;
                QuestChecking(jQuest);
            }
            else 
                Debug.LogWarning("JobManager: PublishUpdate: Quest already finished");
            return;
        }
        Debug.LogError("JobManager: HandleCallback: Quest not found");
    }

    public void QuestChecking(JobQuest quest)
    {
        if(quest.finished == false && quest.objectives.currentAmount >= quest.objectives.targetAmount)
        {
            quest.finished = true;
            Debug.Log("Quest: " + quest.questName + " finished");            
        }
    }

}
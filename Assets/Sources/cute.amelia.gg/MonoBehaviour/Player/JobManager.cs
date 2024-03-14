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
        for(int i = 0; i < job.jobData.quests.Length; i++)
        {
            Debug.Log("Comparing: " + job.jobData.quests[i].questName + " with " + quest.name);

            if(job.jobData.quests[i].questName == quest.name)
            {   
                if(!job.jobData.quests[i].finished)
                {
                    jobs[offset].jobData.quests[i].objectives = quest;
                    QuestChecking(jobs[offset].jobData.quests[i]);
                }
                else 
                    Debug.LogWarning("JobManager: PublishUpdate: Quest already finished");

                return;
            }
        }
        Debug.LogError("JobManager: HandleCallback: Quest not found");
    }

    public void QuestChecking(JobQuest quest)
    {
        if(quest.finished == false && quest.objectives.currentAmount >= quest.objectives.targetAmount)
        {
            quest.finished = true;
            Debug.Log("Quest: " + quest.questName + " finished");
            Instantiate(Resources.Load<GameObject>("Prefab/Ui/QuestNotifications"), GameObject.FindGameObjectsWithTag("CANVAS")[0].GetComponent<Canvas>().transform).GetComponent<QuestNotif>().Setup(QuestStateType.QUEST_STATE_COMPLETED, quest.questName);
            
        }
    }

}
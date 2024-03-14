using System.Collections.Generic;
using UnityEngine;

public class JobAdvancementQuestList : MonoBehaviour
{
    [SerializeField] private JobManager jobManager;
    [SerializeField] private GameObject questPrefab, content;

    void Start()
    {
        jobManager = FindObjectOfType<JobManager>();
        UpdateList();
    }

    public void UpdateList(int offset = 0)
    {
        if(jobManager == null)
            return;

        DestroyChildrens();

        List<JobQuest> unaccessible = new List<JobQuest>();
        foreach(JobQuest questO in jobManager.jobs[offset].jobData.quests)
        {
            if(questO.finished || questO.levelRequire > jobManager.jobs[offset].level)
            {
                unaccessible.Add(questO);
                continue;
            }
            
            Instantiate(questPrefab, content.transform).GetComponent<JobAdvancementQuestObject>().Setup(questO);
        }

        foreach(JobQuest questO in unaccessible)
        {
            Instantiate(questPrefab, content.transform).GetComponent<JobAdvancementQuestObject>().Setup(questO).SetColor(new(1,1,1,0.9f));
        }
    }

    public void DestroyChildrens()
    {
        for(int i = content.transform.childCount - 1; i >= 0; i--)
            Destroy(content.transform.GetChild(i).gameObject);
    }
}
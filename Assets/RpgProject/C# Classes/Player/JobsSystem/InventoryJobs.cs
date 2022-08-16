using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InventoryJobs : MonoBehaviour 
{
    private InventoryStats stats;
    private void Start() {
        stats = GetComponent<InventoryStats>();
    }

    public List <Job> jobs = new List<Job>()
    {
        new Job("Mage", new List<StatModifier>()
                {
                    new StatModifier("Intelligence", 5),
                    new StatModifier("Vitality", 3)
                },0, 0),
        new Job("Forgeron", new List<StatModifier>()
                {
                    new StatModifier("Strength", 5),
                    new StatModifier("Dexterity", 3)
                },0, 0) 
    };

    public void AddExp(string name, int exp)
    {
        for(int i = 0; i < jobs.Count; i++)
        {
            if(jobs[i].Name == name)
            {
                jobs[i].AddExp(exp, stats);
            }
        }
    }

    public Job getJob(string name)
    {
        for(int i = 0; i < jobs.Count; i++)
        {
            if(jobs[i].Name == name)
            {
                return jobs[i];
            }
        }
        return null;
    }

   

    // REMOVE
    private void Update() {
        if (Input.GetKeyDown(KeyCode.L))
        {
            foreach (Job job in jobs)
            {
                job.PrintInfos();
            }
        }
        if(Input.GetKeyDown(KeyCode.K))
        {
            foreach (Job job in jobs)
            {
                job.AddExp(10, stats);
            }
        }
        
    }
}
using UnityEngine;
using UnityEngine.AI;

public class BadHumanAI : enemy
{
    public Transform target;
    public NavMeshAgent agent;  

    public BadHumanAI()
    {
        name = "BadHuman";
        level = 1;
        maxHealth = 100;
        maxEndurance = 100;
        attackCooldown = 1;
        DamageGiven = 16;
    }

    void Event()
    {
        target = GameObject.Find("Player").transform;
        distance = Vector3.Distance(target.position, transform.position);

        if(distance > followRange)
            Idle();
        if (distance < followRange && distance > attackRange)
            Follow();
        if (distance < attackRange)
            Attack();
    }

    void Idle()
    {}

    void Follow()
    {
        agent.destination = target.position;
    }

    void Attack()
    {
        if(Time.time > attackTime)
        {
            target.GetComponent<Player>().damage(DamageGiven);
            attackTime = Time.time + attackCooldown;
        }
    }
}

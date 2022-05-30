using UnityEngine;
using UnityEngine.AI;

//A simple bad entity ai
public class BadHumanAI : MonoBehaviour
{
    private float distance;

    private float followRange = 6;
    private float attackRange = 1.7f;

    private float attackCooldown = 1;
    private float attackTime;

    private float DamageGiven = 16;

    public Transform target;
    public NavMeshAgent agent;

    private void Start()
    {
        attackTime = Time.time;
    }

    void Update()
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
    {
        return;
    }

    void Follow()
    {
        agent.destination = target.position;
    }

    void Attack()
    {
        if(Time.time > attackTime)
        {
            target.GetComponent<Player>().takeDamage(DamageGiven);
            attackTime = Time.time + attackCooldown;
        }
    }
}

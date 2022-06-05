using UnityEngine;
using UnityEngine.AI;

class BadHuman : enemy
{
    private float distance;
    private float followRange = 6;
    private float attackRange = 1.7f;

    private Transform target;
    public NavMeshAgent agent;

    public BadHuman(): base("BadHuman", 1, 100f, 1, 30) {}

    public override void init()
    {
        agent = gameObject.GetComponent<NavMeshAgent>();
    }

    public override void update()
    {
        target = GameObject.Find("Player").transform;

        distance = Vector3.Distance(target.position, transform.position);

        if(distance > followRange)
            Idle();
        if (distance < followRange && distance > attackRange)
            Follow();
        if (distance < attackRange)
            attack();

    }

    void Idle() {}

    void Follow() { agent.destination = target.position; }

    void attack()
    {
        if(Time.time > attackTime)
        {
            target.GetComponent<Player>().damage(DamageGiven);
            attackTime = Time.time + attackCooldown;
        }
    }

    public override void die()
    {
        Destroy(gameObject);
    }
}
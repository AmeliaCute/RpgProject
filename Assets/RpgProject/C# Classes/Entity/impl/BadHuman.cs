using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


class BadHuman : enemy
{
    private float distance;
    public float followRange => 6;
    public float attackRange => 1.7f;

    public override string name => "BadHuman";
    public override int level => 1;

    public override float maxHealth => 100;
    public override float attackCooldown => 1;
    public override float damageGiven => 30;

    private Transform target;
    public NavMeshAgent agent;

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
            target.GetComponent<Player>().takeDamage(damageGiven);
            attackTime = Time.time + attackCooldown;
        }
    }

    public override void die()
    {   
        Destroy(gameObject);
    }
}
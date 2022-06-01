using UnityEngine;
using UnityEngine.AI;

<<<<<<< Updated upstream:Assets/RpgProject/C# Classes/Entity/BadHumanAI.cs
// A simple entity ai
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
=======
class BadHuman : enemy
{
    private float distance;
    private float followRange = 6;
    private float attackRange = 1.7f;

    private Transform target;
    public NavMeshAgent agent;

    public BadHuman(): base("BadHuman", 1, 100f, 1, 30) {}

    public override void init() {}

    public override void update()
>>>>>>> Stashed changes:Assets/RpgProject/C# Classes/Entity/BadHuman.cs
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
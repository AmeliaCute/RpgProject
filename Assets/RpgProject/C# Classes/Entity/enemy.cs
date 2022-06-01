using System.Threading;
using UnityEngine;

abstract class enemy : MonoBehaviour
{
    public string _name;
    public int level;

    public float health;
    private float currentHealth;

    public float attackCooldown;
    public float attackTime; 
    public float DamageGiven;

    /**
      * <summary>
      * Constructor of the enemy class
      * </summary>
      * <param name="name">Name of the enemy</param>
      * <param name="level">Level of the enemy</param>
      * <param name="health">Health of the enemy</param>
      * <param name="attackCooldown">Time between each attack</param>
      * <param name="damageGiven">Damage given by the enemy</param>
      */
    public enemy(string _name, int level, float health, float attackCooldown, float DamageGiven)
    {
        this._name = _name;
        this.level = level;
        this.health = health;
        this.currentHealth = health;
        this.attackCooldown = attackCooldown;
        this.DamageGiven = DamageGiven;
    }

    public string _Name { get { return _name; } set { _name = value; } }

    public int _Level { get { return level; } set { level = value; } }

    public float _Health { get { return health; } set { health = value; } }

    public float _attackCooldown { get { return attackCooldown; } set { attackCooldown = value; } }

    public float _DamageGiven { get { return DamageGiven; } set { DamageGiven = value; } }

    void Start()
    {
        currentHealth = health;
        attackTime = Time.time;
        init();
    }

    void Update()
    { 
        update();
    }

    public abstract void init();
    public abstract void update();
    public abstract void die();

    public void takeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            die();
        }
    }
}
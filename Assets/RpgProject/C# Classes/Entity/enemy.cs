using UnityEngine;

abstract class enemy : Entity
{
    public override bool damageable => true;

    public override string EntityMarker => "ENEMY";

    public virtual int level { get; } 

    public abstract float attackCooldown { get; } 
    public float attackTime;
    public abstract float damageGiven { get; } 

    void Start()
    {
        attackTime = Time.time;
    }
}
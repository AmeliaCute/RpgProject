using UnityEngine;
using UnityEngine.Events;

//TODO: Implement every entity class from this class and implement every virtual and abstract functions
abstract class Entity : MonoBehaviour
{
    public event UnityAction TakeDamage;

    // SPECIFIC PARAMETERS:
    public virtual bool damageable => false;
    public virtual bool hasEndurance => false;
    public virtual bool byPassGamestatesPriority => false;
    public virtual new string name => "NULL";
    public string entityID { get => EntityMarker+":"+name; }
    public virtual string EntityMarker => "ENTITY";

    // HEALTH:
    public virtual float maxHealth { get; set; }
    public float health;

    // ENDURANCE:
    public virtual float maxEndurance { get; set; }
    public float endurance;

    // INIT FUNCTION:
    private void Awake()
    {
        gameObject.tag = EntityMarker;
        init();
        if(damageable) health = maxHealth;
        if(hasEndurance) endurance = maxEndurance;
    }

    // UPDATE FUNCTION:
    private void Update() {
        if(Gamestates.get() != GameState.BUSY || byPassGamestatesPriority) update();
        if(Gamestates.get() == GameState.BUSY) busyUpdate();
    }

    // TOOLS FUNCTIONS:
    public void takeDamage(float damage)
    {
        if(damageable)
        {
            health -= damage;

            if (health <= 0)
            {
                health = 0;
                die();
                return;
            }
            
            TakeDamage?.Invoke();
        }
    }
    
    public virtual void init(){ }
    public virtual void update() { }
    public virtual void die() { }
    public virtual void busyUpdate() { }
}
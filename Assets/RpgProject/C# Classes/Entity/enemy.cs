using UntityEngine; 

public class enemy : MonoBehaviour
{
    private string name;
    private int level;

    //public item weapon;
    //public Armor[4] armor;
    //public Artifact[3] artifact;

    private float maxHealth;
    private float currentHealth;

    public float maxEndurance;
    private float currentEndurance;

    private float attackCooldown = 1;
    private float attackTime;
    private float DamageGiven = 16;

    public ennemy(string name, int level, float Health, float Endurance, float attackCooldown, float DamageGiven)
    {
        this.name = name;
        this.level = level;
        this.MaxHealth = Health;
        this.maxEndurance = Endurance;
        this.attackCooldown = attackCooldown;
        this.DamageGiven = DamageGiven;
    }

    void Start()
    {
        currentHealth = maxHealth;
        currentEndurance = maxEndurance;

        attackTime = Time.time;

<<<<<<< Updated upstream
        Init();
    }

    void Update() { Event;}
=======
    public abstract void init();
    public abstract void die();
>>>>>>> Stashed changes

    public void Init() { }
    public void Event() { }
}
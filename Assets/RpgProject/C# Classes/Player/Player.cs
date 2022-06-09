using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private CharacterController Controller;
    [SerializeField] private Image EnduranceBar;
    [SerializeField] private Image HealthBar;
    [SerializeField] private Animation CharacterAnimation;
    private InventorySlot inventory;

    [SerializeField] private float WalkingSpeed = 5f;
    [SerializeField] private float SprintingSpeed = 7f;

    [SerializeField] private float MaxEndurance = 100f;
    private float CurrentEndurance;

    [SerializeField] private float MaxHealth = 100f;
    private float CurrentHealth;

    [SerializeField] private float attackCooldown = 1f;
    private float CurrentCooldown;
    private float attackRange = 100f;
    private float DamageGiven = 5f;

    private bool isAlive = true;
    private bool isBusy = false;

    private bool isSprinting = false;
    private float TargetAngleSmoothTime = 0.1f;
    private float TargetAngleSmoothVelocity;

    private void Start()
    {
        inventory = GetComponent<InventorySlot>();

        CurrentEndurance = MaxEndurance;
        CurrentHealth = MaxHealth;
        CurrentCooldown = Time.time;

        EnduranceBar.transform.position = new Vector3(100f, 18, 0);
        HealthBar.transform.position = new Vector3(100f, 34, 0);
    }
    void Update()
    {
        // Gravity
        isFlying();

        // Hud
        updateHud();

        if (!isAlive) return; //TODO Faire une animation sur l'ecran lorsque que le joueur meurt
        if (isBusy) return; 

        // Sprinting
        updateSprint();

        // Move
        updateMovement();

        // Other input like attack input
        updateInput();

        // Player stats 
        updateStats();
    }

    private void updateSprint()
    {
        if (Input.GetButtonDown("Sprint"))
            if (isSprinting != true)
                isSprinting = true;
        if (Input.GetButtonUp("Sprint"))
            if (isSprinting != false)
                isSprinting = false;
    }

    public void damage(float damage)
    {
        CurrentHealth = CurrentHealth - damage; //TODO Prendre en compte les states des items
        if (CurrentHealth <= 0)
        {
            CurrentHealth = 0;
            dead();
            isAlive = false;
        }
    }

    private void interact()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position + Vector3.up * 0.25f, transform.TransformDirection(Vector3.right), out hit, attackRange))
        {
            Debug.DrawLine(transform.position + Vector3.up * 0.25f, hit.point, Color.red);
            Debug.Log("Entity name: " + hit.transform.name);

            string tag = hit.transform.tag;

            switch (tag)
            {
                case "Enemy":
                    if (Time.time > CurrentCooldown)
                    {
                        hit.transform.GetComponent<enemy>().takeDamage(DamageGiven);
                        if (inventory.getWeapon() != null)
                            inventory.getWeapon().DamageItem(0.3f);
                        CurrentCooldown = Time.time + attackCooldown;
                    }
                    break;
                case "Npc":
                    hit.transform.GetComponent<villager>().interact();
                    break;
            }

        }
    }
    
    private void dead()
    {
        Debug.Log("Player is dead");
        CharacterAnimation.Play("Die");
    }

    private void isFlying()
    {
        Vector3 moveVector = Vector3.zero;
        if (Controller.isGrounded == false)
            moveVector += Physics.gravity;
        Controller.Move(moveVector * Time.deltaTime);
    }

    private void updateMovement()
    {
        float AxisHor = Input.GetAxisRaw("Horizontal");
        float AxisVer = Input.GetAxisRaw("Vertical");
        Vector3 Direction = new Vector3(AxisHor, 0f, AxisVer).normalized;

        if (Direction.magnitude >= 0.1f)
        {
            float speed = WalkingSpeed;
            if (isSprinting)
            {
                if (CurrentEndurance != 0)
                    speed = SprintingSpeed;
                if (CurrentEndurance > 0)
                    CurrentEndurance = CurrentEndurance - 0.5f;
            }
            else
                if (CurrentEndurance < MaxEndurance)
                CurrentEndurance++;

            float TargetAngle = Mathf.Atan2(-Direction.z, Direction.x) * Mathf.Rad2Deg;
            float Angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, TargetAngle, ref TargetAngleSmoothVelocity, TargetAngleSmoothTime);
            transform.rotation = Quaternion.Euler(0f, Angle, 0f);

            Controller.Move(Direction * speed * Time.deltaTime);
        }
        else // Endurance
            if (CurrentEndurance < MaxEndurance)
            CurrentEndurance++;
    }

    private void updateHud()
    {
        float HealthPerc = ((CurrentHealth * 100) / MaxHealth) / 100;
        float EndurancePerc = ((CurrentEndurance * 100) / MaxEndurance) / 100;

        HealthBar.fillAmount = HealthPerc;
        EnduranceBar.fillAmount = EndurancePerc;
    }

    private void updateInput()
    {
        if (Input.GetButtonDown("Fire1"))
            interact();
    }

    private void updateStats()
    {
        if (inventory.getWeapon() != null)
        {
            DamageGiven = inventory.getWeapon().Damage;
            attackRange = inventory.getWeapon().attackRange;
            attackCooldown = inventory.getWeapon().reloadTime;
        }
        else
        {
           attackCooldown = 1f;
           attackRange = 1.8f;
           DamageGiven = 5f;
}
    }

    public void restoreHealth()
    {
        CurrentHealth = MaxHealth;
    }

    public void restoreEndurance()
    {
        CurrentEndurance = MaxEndurance;
    }

    public float getHealth()
    {
        return CurrentHealth;
    }

    public float getEndurance()
    {
        return CurrentEndurance;
    }

    public bool _isAlive()
    {
        return isAlive;
    }

    public bool _isBusy()
    {
        return isBusy;
    }
}
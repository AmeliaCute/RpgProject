using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

class Player : Entity
{
    /*===================( ENTITY )===================*/

        /*==============={ Basic datas }================*/
            public override string name => "Emilia";
            public override string EntityMarker => "PLAYER";

        /*==============={ Basic stats }================*/
            public override float maxHealth => 100;
            public override float maxEndurance => 100;

        /*==============={ Entity Parameters }================*/
            public override bool damageable => true;
            public override bool hasEndurance => true;
            public override bool byPassGamestatesPriority => true;


        public override void init() { instance = this; }

    /*===================( PLAYER )===================*/

        /*==============={ Objects }================*/
            public static Player instance;
            public Inventory inventory;

        /*==============={ Movements }================*/
            private float WalkingSpeed = 5f;
            private float SprintingSpeed = 7f;

            private bool isSprinting = false;
            private float TargetAngleSmoothTime = 0.1f;
            private float TargetAngleSmoothVelocity;

        /*==============={ Attacks }================*/
            private float attackCooldown = 1f;
            private float CurrentCooldown;
            private float attackRange = 100f;
            private float DamageGiven = 5f;

        /*==============={ Objects }================*/
            private CharacterController Controller;
            [SerializeField] private Image EnduranceBar;
            [SerializeField] private Image HealthBar;
            private Animation CharacterAnimation;

        /*==============={ Others }================*/
            public bool isAlive = true;
            public bool isBusy = false;
            public int money = 100;
            public Quest[] quests;
            public bool isCheckingQuest = false;


        public void Start() 
        {
            Controller = GetComponent<CharacterController>();
            inventory = GetComponent<Inventory>();

            endurance = InventoryStats.getStat("Stamina").GetTotal();
            health = InventoryStats.getStat("Vitality").GetTotal();

            maxEndurance = endurance;
            maxHealth = health;
            
            CurrentCooldown = Time.time;

            DialogueMan.Instance.OnShowDialogue += () => { Gamestates.set(GameState.BUSY); };
            DialogueMan.Instance.OnCloseDialogue += () => { Gamestates.set(GameState.PLAYING);};
            Stat.StatsUpdateEvent += () => { updateStats(); };
            Job.StatsUpdateEvent += () => { updateStats(); };
        }

        public override void update()
        {
            isFlying();
            updateHud();

            if (Input.GetButtonUp("Cancel"))
                Quest.hideQuest();

            if (!isAlive) return;
            if (isBusy) return; 

            updateInput();
            if(Gamestates.get() != GameState.BUSY)
            {
                updateSprint();
                updateMovement();
            }
        }

        private void isFlying()
        {
            Vector3 moveVector = Vector3.zero;

            if (Controller.isGrounded == false) moveVector += Physics.gravity;
            Controller.Move(moveVector * Time.deltaTime);
        }

        private void updateHud()
        {
            HealthBar.fillAmount =  ((health * 100) / maxHealth) / 100;
            EnduranceBar.fillAmount = ((endurance * 100) / maxEndurance) / 100;
        }

        private void updateInput()
        {
            if(Input.GetButtonUp("Fire1")) interact();

            if(Input.GetButtonUp("Inventory")) inventory.ToggleInventory();
        }

        private void updateStats()
        {
            maxHealth = InventoryStats.getStat("Vitality").GetTotal();
            maxEndurance = InventoryStats.getStat("Stamina").GetTotal();


            if (inventory.getWeapon() != null)
            {
                DamageGiven = InventoryStats.getStat("Strength").GetTotal();
                attackRange = inventory.getWeapon().getAttackRange();
                attackCooldown = inventory.getWeapon().getReloadTime();
            }
            else
            {
                attackCooldown = 1f;
                attackRange = 1.8f;
                DamageGiven = 5f;
            }
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
                    if (endurance != 0)
                        speed = SprintingSpeed;
                    if (endurance > 0)
                        endurance = endurance - 0.5f;
                }
                else
                    if (endurance < maxEndurance)
                        endurance++;

                float TargetAngle = Mathf.Atan2(-Direction.z, Direction.x) * Mathf.Rad2Deg;
                float Angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, TargetAngle, ref TargetAngleSmoothVelocity, TargetAngleSmoothTime);
                transform.rotation = Quaternion.Euler(0f, Angle, 0f);

                Controller.Move(Direction * speed * Time.deltaTime);
            }
            else 
                if (endurance < maxEndurance)
                    endurance++;
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

        private void interact()
        {
            RaycastHit hit;

            if (Physics.Raycast(transform.position + Vector3.up * 0.25f, transform.TransformDirection(Vector3.right), out hit, attackRange))
            {
                Debug.DrawLine(transform.position + Vector3.up * 0.25f, hit.point, Color.red);
                Debug.Log("Entity name: " + hit.transform.name);

                switch (hit.transform.tag)
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

                    case "Ore":
                        if (Time.time > CurrentCooldown)
                        {
                            if (inventory.getPickaxe() != null)
                            {
                                inventory.getPickaxe().DamageItem(0.3f);
                                hit.transform.GetComponent<ore>().Damage(inventory.getPickaxe().getDamage());
                            }
                        }
                        break;
                }

            }
        }

        public void restoreHealth()
        {
            health = maxHealth;
        }

        public void restoreEndurance()
        {
            endurance = maxEndurance;
        }

        public void teleport(Vector3 position)
        {
            transform.position = position;
        }

        public void setMoney(int quantity)
        {
            money = quantity;
        }

        public void addMoney(int quantity)
        {
            money += quantity;
        }

        public void removeMoney(int quantity)
        {
            if(!(money - quantity < 0))
                money -= quantity;
        }

        public static Player GetPlayer()
        {
            return instance;
        }

        public static GameObject getObject()
        {
            return instance.gameObject;
        }
}
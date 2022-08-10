using UnityEngine;

public enum NpcState{
    IDLE,
    WALKING,
    TALKING

}

abstract class villager : MonoBehaviour
{
    public string _name;
    public float health;

    private Transform target;
    private float distance;
    private bool showTalkIcon;

    /// <summary>
    /// The constructor of the villager class
    /// </summary>
    /// <param name="_name"> parameter to define the name of the npc </param>
    /// <param name="health"> parameter can be used like when the player is attacking for no reason a poor villager </param>
    public villager(string _name, float health)
    {
        this._name = _name;
        this.health = health;
    }

    public string Name { get { return _name; } set { _name = value; } }
    public float Health { get { return health; } set { health = value; } }

    private void Update()
    {
        if(state == NpcState.TALKING)
        {
            return;
        }
        update();
        distance = Vector3.Distance(target.position, transform.position);
        if (distance < 2.5f)
        {
            if (!showTalkIcon)
            {
                showTalkIcon = true;
                TalkIconOption();
            }
            if (Input.GetButtonDown("pickup"))
            {
                interact();
            }
        }
        else { if (showTalkIcon) { showTalkIcon = false; TalkIconOption(); } }
    }

    private void Start()
    {
        gameObject.transform.tag = "Npc";
        init();
        target = GameObject.Find("Player").transform;

        DialogueMan.Instance.OnShowDialogue += () =>
        {
            state = NpcState.TALKING;
        };

        DialogueMan.Instance.OnCloseDialogue += () =>
        {
            state = NpcState.IDLE;
        };
    }

    /// <summary>
    /// Function to decrease the health of the npc
    /// </summary>
    /// <param name="damage"></param>
    public void takeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            health = 0;
            die();
        }
    }

    private NpcState state;
    public abstract NpcState DefState();
    public abstract void interact();
    public abstract void init();
    public abstract void die();
    public abstract void update();

    private void TalkIconOption()
    {
        if (showTalkIcon)
        {
            GameObject ga = new GameObject("TalkIcon");
            ga.AddComponent<SpriteRenderer>();
            ga.transform.position = new Vector3(transform.position.x, transform.position.y + 1.3f, transform.position.z);
            ga.transform.rotation = Quaternion.Euler(25f, 0f, 0f);

            SpriteRenderer spriteRen = ga.GetComponent<SpriteRenderer>();
            spriteRen.sprite = IconList.GetSprite(1);
            spriteRen.drawMode = SpriteDrawMode.Sliced;
            spriteRen.size = new Vector2(0.9f, 0.9f);

            ga.transform.parent = null;

        }
        else { try { Destroy(GameObject.Find("TalkIcon")); } catch { } }
    }
}
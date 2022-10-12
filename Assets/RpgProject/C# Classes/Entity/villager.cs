using UnityEngine;

public enum NpcState
{
    IDLE,
    WALKING,
    TALKING
}

abstract class villager : Entity
{
    public override float maxHealth => 100;
    public override string entityID => "villager:"+name;
    public override string EntityMarker => "VILLAGER";

    private Transform target;
    private float distance;
    private bool showTalkIcon;
    private NpcState state;

    //FIXME: Use hitbox vector instead of distance (line 28)
    public override void update()
    {
        if(state == NpcState.TALKING)
        {
            return;
        }
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

    public virtual NpcState DefState => NpcState.IDLE;
    public virtual void interact() { }

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
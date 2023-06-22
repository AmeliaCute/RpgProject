using UnityEngine;
using UnityEngine.Events;

abstract class machine : Entity 
{   
    public override bool damageable => false;
    public override string EntityMarker => "MACHINE";
    public new virtual bool byPassGamestatesPriority => true;

    public abstract bool isInteractable { get; }
    public virtual int usableAfterLevel => 0;

    public Collider triggerBox;
    public bool isTriggered;

    private void OnTriggerEnter(Collider other) {
        isTriggered = true;

        if(isInteractable)
        {
            GameObject ga = new GameObject("UseIcon_"+EntityMarker+"_"+name);
            ga.AddComponent<SpriteRenderer>();
            ga.transform.position = new Vector3(transform.position.x, transform.position.y + 1.3f, transform.position.z);
            ga.transform.rotation = Quaternion.Euler(25f, 0f, 0f);

            SpriteRenderer spriteRen = ga.GetComponent<SpriteRenderer>();
            spriteRen.sprite = Resources.Load<Sprite>("Sprites/World/TalkIcon");
            spriteRen.drawMode = SpriteDrawMode.Sliced;
            spriteRen.size = new Vector2(0.9f, 0.9f);

            ga.transform.parent = null;
        }
    }

    private void OnTriggerExit(Collider other) {
        isTriggered = false;
        if(isInteractable)
        {
            try { Destroy(GameObject.Find("UseIcon_"+EntityMarker+"_"+name)); } catch { } 
        }
    }

    public override void update()
    {
        if(isTriggered && isInteractable && Input.GetButtonDown("pickup"))
            Interact();
        onMachineUpdate();
    }

    public virtual void Interact()
    {
        Debug.Log(EntityMarker+"_"+name+" has been interact but nothing has been set");
    }

    //TODO: Make it update every 50ms
    public virtual void onMachineUpdate(){ }
}
using UnityEngine;

public class RegisteredItem : MonoBehaviour
{
    public Item item;
    public Sprite pickupIcon;

    private Transform target;
    private float distance;
    private bool showPickUpIcon;

    private void Start()
    {
        target = GameObject.Find("Player").transform;
        pickupIcon = IconList.GetSprite(0);
    }

    private void Update()
    {
        distance = Vector3.Distance(target.position, transform.position);
        if (distance < 2.5f)
        {
            if(!showPickUpIcon)
            {
                showPickUpIcon = true;
                PickUpOption();
            }
            if (Input.GetButtonDown("pickup"))
            {
                target.GetComponent<InventorySlot>().AddItemBackpack(item);
                try { Destroy(GameObject.Find("PickUpIcon")); } catch { }
                Destroy(gameObject);
            }
        }
        else { if (showPickUpIcon) { showPickUpIcon = false; PickUpOption(); } }
    }

    private void PickUpOption()
    {
        if (showPickUpIcon)
        {
            GameObject ga = new GameObject("PickUpIcon");
            ga.AddComponent<SpriteRenderer>();
            ga.transform.position = new Vector3(transform.position.x, transform.position.y + 0.8f, transform.position.z);
            ga.transform.rotation = Quaternion.Euler(25f, 0f, 0f);

            SpriteRenderer spriteRen = ga.GetComponent<SpriteRenderer>();
            spriteRen.sprite = pickupIcon;
            spriteRen.drawMode = SpriteDrawMode.Sliced;
            spriteRen.size = new Vector2(0.9f, 0.9f);
            
            ga.transform.parent = null;

        }
        else{ try { Destroy(GameObject.Find("PickUpIcon")); } catch { } }
    }
}
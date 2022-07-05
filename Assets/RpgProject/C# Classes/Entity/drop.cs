using UnityEngine;

public class drop : MonoBehaviour
{
    private Vector3 location;
    public Item item;
    
    private BoxCollider boxCollider;

    public drop(Vector3 location, Item item)
    {
        this.item = item;
        this.location = location;
    }

    public void createNewDrop()
    {
        GameObject entity = GameObject.Find("Entity");
        GameObject _drop = new GameObject("[l]"+item.uuid);

        _drop.AddComponent<MeshFilter>();
        _drop.AddComponent<MeshRenderer>();
        _drop.AddComponent<BoxCollider>();
        _drop.AddComponent<Rigidbody>();
        _drop.AddComponent<RegisteredItem>();        

        boxCollider = _drop.GetComponent<BoxCollider>();
        boxCollider.size = new Vector3(0.5f, 0.5f, 0.5f);
        boxCollider.center = new Vector3(0f, 0.5f, 0f);

        _drop.GetComponent<MeshFilter>().sharedMesh = item.getModel();

        _drop.GetComponent<RegisteredItem>().item = item;

        _drop.transform.position = new Vector3(location.x, location.y + 0.5f, location.z);
        _drop.transform.parent = entity.transform;
    }

}

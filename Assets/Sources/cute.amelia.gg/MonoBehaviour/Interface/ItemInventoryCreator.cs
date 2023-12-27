using UnityEngine;

public class ItemInventoryCreator : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private GameObject ItemButtonPrefab;
    
    void Start()
    {
        player = FindFirstObjectByType<Player>();
        foreach(ItemInstance items in player.inventory)
        {
            var it = Instantiate(ItemButtonPrefab);
            it.GetComponent<ItemInventoryButton>().Setup(items);
            it.transform.SetParent(transform, false);
        }
    }
}
using UnityEngine;

public class ItemInventoryCreator : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private GameObject ItemButtonPrefab;
    public ItemCategory Category;
    public void ChangeCategory(ItemCategory category){ Category = category; }

    void Start()
    {
        player = FindFirstObjectByType<Player>();

        InitializeInventory();
        StartCoroutine(FindFirstObjectByType<ToolkitSelector>().SetSelector(player.inventory[0]));
    }

    public void reload()
    {
        for (var i = 0; i < transform.childCount; ++i)
            Destroy(transform.GetChild(i).gameObject);

        InitializeInventory(Category);
    }

    private void InitializeInventory(ItemCategory category = ItemCategory.All)
    {
        if (player.inventory.Count > 0)
        {
            foreach (ItemInstance item in player.inventory)
            {
                if (item.itemType.category == category || category == ItemCategory.All)
                {
                    var it = Instantiate(ItemButtonPrefab);
                    it.GetComponent<ItemInventoryButton>().Setup(item);
                    it.transform.SetParent(transform, false);
                }
            }
        }
    }
}
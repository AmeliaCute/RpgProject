using UnityEngine;
using UnityEngine.UI;

public class ItemInventoryButton : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private Text title, quantity;
    [SerializeField] private ItemInstance itemInstance;
    [SerializeField] private ItemCategory category;

    public void Setup(ItemInstance items)
    {
        itemInstance = items;
        image.sprite = itemInstance.getCurrent().icon;
        quantity.text = $"{items.quantity}";
    }

    public void SendDataToSelector()
    {
       StartCoroutine(FindFirstObjectByType<ToolkitSelector>().SetSelector(itemInstance));
    }
}
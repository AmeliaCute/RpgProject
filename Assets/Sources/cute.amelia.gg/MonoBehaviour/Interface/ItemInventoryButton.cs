using UnityEngine;
using UnityEngine.UI;

public class ItemInventoryButton : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private Text title, quantity;
    [SerializeField] private ItemInstance itemInstance;

    public void Setup(ItemInstance items)
    {
        itemInstance = items;
        image.sprite = items.itemType.icon;
        title.text = items.itemType.itemName;
        quantity.text = $"{items.quantity}";
    }

    public void SendDataToSelector()
    {
        GameObject.FindFirstObjectByType<ToolkitSelector>().SetSelector(itemInstance.itemType);
    }
}
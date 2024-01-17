using UnityEngine;
using UnityEngine.UI;

public class ItemInventoryButton : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private Text title, quantity;
    [SerializeField] private ItemFlag itemInstance;

    public void Setup(ItemInstance items)
    {
        itemInstance = items.getCurrent();
        image.sprite = itemInstance.icon;
        title.text = itemInstance.itemName;
        quantity.text = $"{items.quantity}";
    }

    public void SendDataToSelector()
    {
        GameObject.FindFirstObjectByType<ToolkitSelector>().SetSelector(itemInstance);
    }
}
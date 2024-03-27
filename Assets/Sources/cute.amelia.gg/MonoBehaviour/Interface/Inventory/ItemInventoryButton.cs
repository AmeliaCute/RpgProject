using UnityEngine;
using UnityEngine.UI;

public class ItemInventoryButton : MonoBehaviour
{
    [SerializeField] private Image image, background;
    [SerializeField] private Text quantity;
    [SerializeField] private ItemInstance itemInstance;
    [SerializeField] private ItemCategory category;

    public void Setup(ItemInstance items)
    {
        itemInstance = items;
        image.sprite = itemInstance.getCurrent().icon;
        quantity.text = $"{items.quantity}";
        background.color = items.getCurrent().getRarityColor();
    }

    public void SendDataToSelector()
    {
       StartCoroutine(FindFirstObjectByType<ToolkitSelector>().SetSelector(itemInstance));
    }
}
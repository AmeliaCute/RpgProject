using UnityEngine;
using UnityEngine.UI;

public class ItemInventoryButton : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private Text title, quantity;

    public void Setup(ItemInstance items)
    {
        image.sprite = items.itemType.icon;
        title.text = items.itemType.itemName;
        quantity.text = $"{items.quantity}";
    }
}
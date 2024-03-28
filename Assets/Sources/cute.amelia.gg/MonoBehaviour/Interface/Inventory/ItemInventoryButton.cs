using System;
using UnityEngine;
using UnityEngine.UI;

public class ItemInventoryButton : MonoBehaviour
{
    [SerializeField] private Image image, background;
    [SerializeField] private Text quantity;
    [SerializeField] private ItemInstance itemInstance;
    [SerializeField] private ItemCategory category;
    [SerializeField] private bool UseAttributeAsQuantity;
    [SerializeField] private int AttributeOffset;

    public void Setup(ItemInstance items)
    {
        itemInstance = items;
        image.sprite = itemInstance.getCurrent().icon;
        background.color = items.getCurrent().getRarityColor();

        if(UseAttributeAsQuantity && itemInstance.getCurrent().attribute.Count > AttributeOffset)
            quantity.text = $"{items.quantity}";
            
    }

    public void SendDataToSelector()
    {
       StartCoroutine(FindFirstObjectByType<ToolkitSelector>().SetSelector(itemInstance));
    }
}
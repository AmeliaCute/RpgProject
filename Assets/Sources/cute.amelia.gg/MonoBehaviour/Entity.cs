using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Services.Analytics;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public Statistic health = new Statistic(100, 0);
    public Statistic attack = new Statistic(4, 0);
    public Statistic speed = new Statistic(10, 0);
    public Statistic defense = new Statistic(10, 0);
    public List<ItemInstance> inventory;
    public int level = 10;

    public void AddItem(ItemInstance item)
    {
        if (inventory == null)
            inventory = new List<ItemInstance>();

        List<ItemInstance> sameTypeItems = inventory.FindAll(i => i.itemType == item.itemType);
        ItemInstance instance = new ItemInstance { itemType = item.itemType, quantity = item.quantity};

        int totalQuantity = instance.quantity;

        foreach (ItemInstance existingItem in sameTypeItems)
        {
            int remainingSpace = 9999 - existingItem.quantity;

            if (totalQuantity <= remainingSpace)
            {
                existingItem.quantity += totalQuantity;
                return;
            }
            else
            {
                existingItem.quantity = 9999;
                totalQuantity -= remainingSpace;
            }
        }

        while (totalQuantity > 0)
        {
            int quantityToAdd = Mathf.Min(totalQuantity, 9999);

            inventory.Add(new ItemInstance
            {
                itemType = instance.itemType,
                quantity = quantityToAdd
            });

            totalQuantity -= quantityToAdd;
        }
    }
}
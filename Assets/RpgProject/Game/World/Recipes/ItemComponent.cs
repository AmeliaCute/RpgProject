using System.Collections.Generic;
using RpgProject.Objects;
using UnityEngine;

public class ItemComponent {
    
    public Item item;
    public int quantity;

    //TODO: STORE EVERY ITEMS IN INVENTORY WITH THIS
    public ItemComponent(Item item, int quantity)
    {
        this.item = item;
        this.quantity = quantity;
    }  

    public void addQuantity(int x) { quantity =+ x; }
    public void removeQuantity(int x) { quantity =- x; }

    public Item getItem() {return item; }
    public int getQuantity() { return quantity; }

    public static List<ItemComponent> SortItems(List<ItemComponent> items, string type)
    {
        List<ItemComponent> sortedItems = new List<ItemComponent>();
        foreach(ItemComponent item in items)
        {
            if(item.getItem().type == type)
            {
                sortedItems.Add(item);
            }
        }
        return sortedItems;
    }
}
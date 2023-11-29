using System;
using System.Collections.Generic;
using RpgProject.Objects;
using UnityEngine;

[Serializable]
public class ItemComponent
{

    public Item item;
    
    public int quantity;

    public ItemComponent(Item item, int quantity)
    {
        this.item = item;
        this.quantity = quantity;
    }

    public void addQuantity(int x) { quantity =+ x; }
    public void removeQuantity(int x) { quantity =- x; }
    public Item getItem() { return item; }
    public int getQuantity() { return quantity; }
    public ItemComponent Clone() { return new ItemComponent(item, quantity); }
}
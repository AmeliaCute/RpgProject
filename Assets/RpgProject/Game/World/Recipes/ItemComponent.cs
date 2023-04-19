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
}
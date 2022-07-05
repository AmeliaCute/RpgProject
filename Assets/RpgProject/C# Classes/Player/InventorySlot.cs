using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// It's just a test class gonna may be deleted later
/// </summary>
public class InventorySlot : MonoBehaviour
{
    [SerializeField] private Sword weapon = null;
    [SerializeField] private Pickaxe pickaxe     = null;

    [SerializeField] private List<Item> backpack;

    public void ChangeWeapon(Sword item){if(weapon != null)AddItemBackpack(weapon); weapon = item;}
    public void UnequipWeapon(){if(weapon != null){ AddItemBackpack(weapon); weapon = null; }}
    public Sword getWeapon(){ return weapon; }

    public void ChangePickaxe(Pickaxe item){if (pickaxe != null)AddItemBackpack(pickaxe); pickaxe = item; }
    public void UnequipPickaxe(){if (pickaxe != null) { AddItemBackpack(pickaxe); pickaxe = null; }}
    public Pickaxe getPickaxe() {  return pickaxe; }

    public void AddItemBackpack(Item item)
    {
        if (backpack.Contains(item))
            return;
        backpack.Add(item);
    }
}

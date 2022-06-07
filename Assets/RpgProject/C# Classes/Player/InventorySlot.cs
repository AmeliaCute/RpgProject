using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// It's just a test class gonna may be deleted later
/// </summary>
public class InventorySlot : MonoBehaviour
{
    [SerializeField] private Sword weapon = null;

    [SerializeField] private List<Item> backpack;

    public void ChangeWeapon(Sword item)
    {
        if(item.isBroken)
        {
            Debug.Log("This item is broken");
            return;
        }
        if(weapon != null)
            AddItemBackpack(weapon);
        weapon = item;
    }

    public void UnequipWeapon()
    {
        if(weapon != null)
        {
            AddItemBackpack(weapon);
            weapon = null;
        }
    }

    public Sword getWeapon()
    {
        return weapon;
    }

    public void AddItemBackpack(Item item)
    {
        if (backpack.Contains(item))
            return;
        backpack.Add(item);
    }

    void Update()
    {
        if(weapon.getCurrentEndurance() <= 0)
            UnequipWeapon();
    }
}

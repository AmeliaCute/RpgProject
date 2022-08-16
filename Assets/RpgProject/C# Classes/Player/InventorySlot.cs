using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// It's just a test class gonna may be deleted later
/// </summary>
public class InventorySlot : MonoBehaviour
{
    public static event UnityAction InventoryUpdateEvent;
    private InventoryStats stats;

    [SerializeField] private Sword weapon = null;
    [SerializeField] private Pickaxe pickaxe  = null;
    [SerializeField] private List<Item> backpack;

    public void ChangeWeapon(Sword item){
        if(weapon != null)
        {
            stats.RemoveBonusFromStat("Strength", weapon.getDamage());
            AddItemBackpack(weapon);
        }
        weapon = item; 
        stats.AddBonusToStat("Strength", weapon.getDamage());
        InventoryUpdateEvent?.Invoke();
    }
    public void UnequipWeapon(){
        if(weapon != null)
        {
            AddItemBackpack(weapon);
            stats.RemoveBonusFromStat("Strength", weapon.getDamage());
            weapon = null;
            InventoryUpdateEvent?.Invoke();
        }
    }
    public Sword getWeapon(){ return weapon; }

    public void ChangePickaxe(Pickaxe item){if (pickaxe != null)AddItemBackpack(pickaxe); pickaxe = item; InventoryUpdateEvent?.Invoke();}
    public void UnequipPickaxe(){if (pickaxe != null) { AddItemBackpack(pickaxe); pickaxe = null; InventoryUpdateEvent?.Invoke();}}
    public Pickaxe getPickaxe() {  return pickaxe; }

    public void AddItemBackpack(Item item)
    {
        if (backpack.Contains(item))
            return;
        backpack.Add(item);
    }

    public void RemoveItemBackpack(Item item)
    {
        if (!backpack.Contains(item))
            return;
        backpack.Remove(item);
    }

    public List<Item> getBackpack()
    {
        return backpack;
    }

    private void Start() {
        stats = GetComponent<InventoryStats>();

        stats.AddBonusToStat("Strength", weapon.getDamage());
    }
}

using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;

[System.Serializable, CreateAssetMenu(menuName = "RpgProject/ItemData")]
public class ItemData : ScriptableObject
{   
    public List<ItemFlag> flag;
    public ItemCategory category;
    
}

public enum ItemCategory {
    All,
    Weapon,
    Collectable
}
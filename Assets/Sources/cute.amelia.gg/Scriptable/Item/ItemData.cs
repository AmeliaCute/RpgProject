using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;

[CreateAssetMenu]
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
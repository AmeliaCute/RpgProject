using UnityEngine;

[System.Serializable]
public class ItemInstance
{
    public ItemData itemType;
    [Range(1.0f, 9999.0f)]
    public int quantity;
    public int flag = 0;

    public ItemFlag getCurrent()
    {
        return itemType.flag[flag];
    }
}
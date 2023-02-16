using RpgProject.Objects;
using UnityEngine;

public class Items {

    public static Sword WOODEN_STICK;
    public static Other DEBUG_ITEM;

    public static void register()
    {
        RpgClass.LOADING_ETA = LOADING_STATE.LOADING_ITEMS;

        WOODEN_STICK = new Sword("Debug sword", Rarity.EPIC, "A sword made with bytes",100, Resources.Load<Mesh>("Models/Testing/sword"), Resources.Load<Sprite>("Sprites/World/TalkIcon"), 5f ,Quality.D ,100, 0.1f, 1);
        DEBUG_ITEM = new Other("Debug item", Rarity.LEGENDARY, "A item made with bytes", 1000,  Resources.Load<Mesh>("Models/Testing/sword"), Resources.Load<Sprite>("Sprites/World/TalkIcon"), type.Useless);
    }
}
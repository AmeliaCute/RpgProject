using RpgProject.Objects;
using UnityEngine;

public class Items {

    public static Weapon WOODEN_STICK;
    public static Wand WOODEN_WAND;
    public static Other DEBUG_ITEM;

    public static void register()
    {
        RpgClass.LOADING_ETA = LOADING_STATE.LOADING_ITEMS;

        WOODEN_STICK = new Weapon("Debug sword", Rarity.EPIC, "A sword made with bytes",100, Resources.Load<Mesh>("Models/Testing/sword"), Resources.Load<Sprite>("Sprites/World/TalkIcon"), 5f ,Quality.D ,100, 0.1f, 1);
        WOODEN_WAND = new Wand("Debug wand", Rarity.EPIC, "A wand made with bytes",100, Resources.Load<Mesh>("Models/Testing/sword"), Resources.Load<Sprite>("Sprites/World/TalkIcon"), 5f ,Quality.D ,100, 0.6f, 1, Resources.Load<GameObject>("Prefab/Trails/Electro_Trail"));
        DEBUG_ITEM = new Other("Debug item", Rarity.COMMON, "A item made with bytes", 1000,  Resources.Load<Mesh>("Models/Testing/sword"), Resources.Load<Sprite>("Sprites/World/TalkIcon"), type.Useless);
    }
}
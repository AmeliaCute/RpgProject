using System.Resources;
using RpgProject.Objects;
using UnityEngine;
using RpgProject.Framework.Resource;

public class Items {

    public static Weapon WOODEN_STICK;


    /* DEBUG THINGS */
    public static Weapon DEBUG_SWORD;
    public static Other DEBUG_ITEM;

    public static void register()
    {
        RpgClass.LOADING_ETA = LOADING_STATE.LOADING_ITEMS;

        WOODEN_STICK = new Weapon("Wooden stick", Rarity.COMMON, "A sword made with bytes. The `Weapon` constructor takes in several parameters such as the name of the weapon, its rarity, description, damage, mesh, icon, weight, quality, durability, and speed. These parameters are used to initialize the properties of the `Weapon` object.",100, null, "Sprites/Items/WOODEN_STICK", 5f ,Quality.D ,5, 0.1f, 1);
        DEBUG_SWORD = new Weapon("Debug sword", Rarity.MYTHIC, "A sword made with bytes", 34534, ResourcesManager.TESTING_SWORD_MESH, "Sprites/Items/DEBUG_SWORD", 5f ,Quality.D ,314, 0.03f, 1);
        
        DEBUG_ITEM = new Other("Debug item", Rarity.LEGENDARY, "A item made with bytes", 1000,  ResourcesManager.TESTING_SWORD_MESH,  "Sprites/Items/DEBUG_ITEM_ALT", type.Useless);
    }
}
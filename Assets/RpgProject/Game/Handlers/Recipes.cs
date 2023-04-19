using System.Collections.Generic;
using UnityEngine;
using RpgProject.Objects;

public class Recipes {

    public static RecipeWorkbench STICK;

    public static void register()
    {
        RpgClass.LOADING_ETA = LOADING_STATE.LOADING_RECIPES;

        STICK = new RecipeWorkbench(new List<ItemComponent>{new ItemComponent(Items.DEBUG_ITEM,3)}, new List<ItemComponent>{new ItemComponent(Items.WOODEN_STICK,1)}, 0, false);
    }
}
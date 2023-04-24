using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RpgClass : MonoBehaviour{

    public static LOADING_STATE LOADING_ETA = LOADING_STATE.STARTING;
    public static List<RecipeWorkbench> WORKBENCH_RECIPES;

    private void Awake()
    {
        Debug.Log("Starting client");
        Debug.Log("Loading items");
        Items.register();

        Debug.Log("Loading recipes");
        WORKBENCH_RECIPES = new List<RecipeWorkbench>();
        Recipes.register();

        LOADING_ETA = LOADING_STATE.FINISH;
        Debug.Log("Loading finish");
    }

    public void Start()
    {
        Player.instance.inventory.weapon = Items.WOODEN_STICK;
    }
}

public enum LOADING_STATE {
    STARTING,
    LOADING_ASSETS,
    LOADING_ITEMS,
    LOADING_RECIPES,
    LOADING_ENTITY,
    FINISH,
}

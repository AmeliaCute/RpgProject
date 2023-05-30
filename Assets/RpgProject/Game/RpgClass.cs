using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Logger = RpgProject.Framework.Debug.Logger;

public class RpgClass : MonoBehaviour{

    public static LOADING_STATE LOADING_ETA = LOADING_STATE.STARTING;
    public static List<RecipeWorkbench> WORKBENCH_RECIPES;

    public static Logger RPGLOGGER;
    public static RpgClass instance;

    private void Awake()
    {
        Debug.Log("Starting client");
        
        Debug.Log("Initializing logger");
        instance = this;
        RPGLOGGER = new Logger("Rpg", 3);
        RPGLOGGER.LogWithCustomPrefix("Getting RpgClass instance","🧩");

        RPGLOGGER.LogWithCustomPrefix("Loading items..","🔁");
        Items.register();

        RPGLOGGER.LogWithCustomPrefix("Loading recipes..","🔁");
        WORKBENCH_RECIPES = new List<RecipeWorkbench>();
        Recipes.register();

        LOADING_ETA = LOADING_STATE.FINISH;
        RPGLOGGER.Passed("Loading finished");
    }

    public void Start()
    {
        Player.instance.inventory.weapon = Items.WOODEN_WAND;
    }

    public void OnApplicationQuit()
    {
        RPGLOGGER.Log("Quitting game..");
        RPGLOGGER.LogWithCustomPrefix("Closing logs..", "📂");
        RPGLOGGER.getWritedFile().Close();
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

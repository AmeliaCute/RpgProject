using System.Collections.Generic;
using UnityEngine;
using RpgProject.Framework.Debug;
using RpgProject.Framework.Resource;
using Logger = RpgProject.Framework.Debug.Logger;
using RpgProject.Game.Data;

public class RpgClass : MonoBehaviour{

    public static LOADING_STATE LOADING_ETA = LOADING_STATE.STARTING;
    public static List<RecipeWorkbench> WORKBENCH_RECIPES;

    private Bindable<int> VerbosityLevel = new Bindable<int>(3);



    public static Logger RPGLOGGER;
    public static Monitor PERFORMANCE_MONITOR;
    public static RpgClass instance;

    private void Awake()
    {
        Debug.Log("Starting client");
        BindableTool.BindWith<int>(RpgSettings.VerbosityLevel, VerbosityLevel);
        Debug.Log(VerbosityLevel.Value);

        Debug.Log("Initializing logger");
        instance = this;
        RPGLOGGER = new Logger("Rpg", VerbosityLevel.Value);
        RPGLOGGER.LogWithCustomPrefix("Getting RpgClass instance","🧩");

        RPGLOGGER.LogWithCustomPrefix("Attaching performances monitor..", "🖥️");
        PERFORMANCE_MONITOR = gameObject.AddComponent<Monitor>();

        RPGLOGGER.LogWithCustomPrefix("Loading assets..", "🧊");
        ResourcesManager.register();

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
        if(Player.instance != null)
            Player.instance.inventory.weapon = Items.DEBUG_SWORD;
    }

    public void OnApplicationQuit()
    {
        RPGLOGGER.LogWithCustomPrefix("Quitting game..", "🎈");
        RPGLOGGER.LogWithCustomPrefix("Closing logs..", "📂");
        RPGLOGGER.GetWrittenFile().Close();
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

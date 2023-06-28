using System.Collections.Generic;
using UnityEngine;
using RpgProject.Framework.Debug;
using RpgProject.Framework.Resource;
using Logger = RpgProject.Framework.Debug.Logger;
using RpgProject.Game.Data;
using System.IO;

public class RpgClass : MonoBehaviour{

    public static LOADING_STATE LOADING_ETA = LOADING_STATE.STARTING;
    public static List<RecipeWorkbench> WORKBENCH_RECIPES;

    private int VerbosityLevel;


    public static Settings SETTINGS;
    public static User USER;
    public static Logger LOGGER;
    public static Monitor PERFORMANCE_MONITOR;
    public static RpgClass instance;

    private void Awake()
    {
        Debug.Log("Starting client");
        instance = this;

        Debug.Log("Loading settings");
        SETTINGS = new Settings(Path.Combine(Application.persistentDataPath, "rpgsettings.json"));

        Debug.Log("Initializing logger");
        LOGGER = new Logger("Rpg", SETTINGS.Values.VerbosityLevel);

        LOGGER.LogWithCustomPrefix("Attaching performances monitor..", "🖥️");
        PERFORMANCE_MONITOR = gameObject.AddComponent<Monitor>();

        LOGGER.LogWithCustomPrefix("Loading assets..", "🧊");
        ResourcesManager.register();

        LOGGER.LogWithCustomPrefix("Loading items..","🔁");
        Items.register();

        LOGGER.LogWithCustomPrefix("Loading recipes..","🔁");
        WORKBENCH_RECIPES = new List<RecipeWorkbench>();
        Recipes.register();

        LOGGER.LogWithCustomPrefix("Loading user data..","🔁");
        USER = new User(Application.persistentDataPath+"/Local/user.json");

        LOADING_ETA = LOADING_STATE.FINISH;
        LOGGER.Passed("Loading finished");
    }

    public void Start()
    {
        if(Player.instance != null)
            Player.instance.inventory.weapon = Items.DEBUG_SWORD;
    }

    public void OnApplicationQuit()
    {
        LOGGER.LogWithCustomPrefix("Quitting game..", "🎈");
        LOGGER.LogWithCustomPrefix("Closing logs..", "📂");
        LOGGER.GetWrittenFile().Close();
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

using System.IO;
using UnityEngine;
using RpgProject.Framework.Debug;
using Logger = RpgProject.Framework.Debug.Logger;
using RpgProject.Game.Data;
using RpgProject.Game.Entity;
using RpgProject.Game.Threaded;
using Camera = RpgProject.Game.Threaded.Camera;
using RpgProject.Framework.Resource;
using RpgProject.Game;
using User = RpgProject.Game.Data.User;
using RpgProject.FrameworkV2;
using Unity.VisualScripting;
using RpgProject.FrameworkV2.Handlers;
using System.Collections.Generic;

class RpgClass : MonoBehaviour
{
    public static LOADING_STATE LOADING_ETA = LOADING_STATE.STARTING;
    public static GAMEMODE MODE_ETA = GAMEMODE.NOTINGAME;
    public static Logger LOGGER;
    public static Monitor PERFORMANCE_MONITOR;
    public static Settings SETTINGS;
    public static User USER;
    public static Player PLAYER;
    public static InputHandler INPUT;
    public static RpgClass instance;
    public static Camera CAMERA;

    public static List<Drawable> INTERFACE_BUFFER = new();


    void OnEnable()
    {
        instance = this;

        SETTINGS = new Settings(Path.Combine(Application.persistentDataPath, "Local"));
        LOGGER = new Logger("Rpg", SETTINGS.Values.VerbosityLevel);

        INPUT = gameObject.AddComponent<InputHandler>();

        LOGGER.LogWithCustomPrefix("Attaching performances monitor..", "💻");
        PERFORMANCE_MONITOR = gameObject.AddComponent<Monitor>();

        LOGGER.Log("Loading resources..");
        ResourcesManager.register();
        Items.register();

        LOADING_ETA = LOADING_STATE.FINISH;
        LOGGER.Passed("Loading finished");

        USER = new User(Path.Combine(Application.persistentDataPath, "Local/save"), "data_2.bin");
        DiscordRichPresence.Start();

        // CHANGE THAT AFTER ADDING A MAIN MENU
        MODE_ETA = GAMEMODE.PLAYING;
    }

    void Start()
    {
        INPUT.addListener(GAMEMODE.PLAYING, new(KeyCode.Escape, () => {new PauseMenu();}));

        if(MODE_ETA == GAMEMODE.PLAYING)
        {
            PLAYER = new Player(new(0, 0.9744148f, 0), "Test");

            //START ALL HANDLERS AND INITIALIZER

            CAMERA = new Camera();
            CAMERA.Start();

            Spawning.LoadAll();

            foreach(RectTransform child in GameObject.FindObjectOfType<Canvas>().transform)
                LOGGER.Error(child.gameObject.name);
        }
    }

    void Update()
    {
        // DiscordRichPresence.Update();
    }

    public void OnApplicationQuit()
    {
        CAMERA.Stop();

        SETTINGS.Save();
        USER.Save(USER.Values);

        DiscordRichPresence.Stop();
        LOGGER.GetWrittenFile().Close();
    }
}

public enum LOADING_STATE
{
    STARTING = 0,
    LOADING_ASSETS = 1,
    LOADING_ITEMS = 2,
    LOADING_RECIPES = 3,
    LOADING_ENTITY = 4,
    FINISH = 5,
}

public enum GAMEMODE
{
    INTERFACE,
    NOTINGAME,
    PLAYING,
    DEBUG,
}
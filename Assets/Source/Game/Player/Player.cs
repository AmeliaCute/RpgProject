using System.IO;
using RpgProject.Game.Data;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Player
{
    public GameObject gameObject;
    public GameObject model;
    public EntityPlayer entityPlayer;
    public Inventory inventory;

    // INVENTORY ↓

    public Player(Vector3 position, string name)
    {
        
        gameObject = new GameObject("PLAYER_" + name);
        entityPlayer = gameObject.AddComponent<EntityPlayer>();

        model = GameObject.Instantiate(Resources.Load<GameObject>("Models/Testing/charactere"));
        model.transform.SetParent(gameObject.transform, false);
        model.transform.rotation = Quaternion.Euler(0, 90, 0);
        model.transform.position = new Vector3(position.x,position.y-1.55f,position.z);

        gameObject.transform.position = position;

        entityPlayer.CONTROLLER.center = new Vector3(0,.5f,0);

        inventory = new(Path.Combine(Application.persistentDataPath, "Local/save"), "data_1.bin");

        //! TEST 
        entityPlayer.AddComponent<GrassRenderHelper>();
    }
}

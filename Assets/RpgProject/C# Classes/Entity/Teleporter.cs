using UnityEngine;

[ExecuteAlways]
public class Teleporter : MonoBehaviour
{
    public GameObject spawnlocation;
    public bool hasBeenTake = false;

    public void interact(Player player)
    {
        if(!hasBeenTake)
        {
            hasBeenTake = true;
            Debug.Log("Teleportation point unlocked: "+spawnlocation.transform.position.ToString());
            return;
        }
        Teleport(player);
    }

    public void Teleport(Player player)
    {
        player.teleport(spawnlocation.transform.position);
    }

}

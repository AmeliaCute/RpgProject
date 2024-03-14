using UnityEngine;

public class Killer : MonoBehaviour
{
    public void Kill()
    {
        GameObject.Destroy(gameObject);
    }

    public static void UltraOmegaKill()
    {
        Application.Quit(0);
    }
}
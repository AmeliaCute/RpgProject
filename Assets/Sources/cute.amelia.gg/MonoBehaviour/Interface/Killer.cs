using UnityEngine;

public class Killer : MonoBehaviour
{
    public void Kill()
    {
        GameObject.Destroy(gameObject);
    }
}
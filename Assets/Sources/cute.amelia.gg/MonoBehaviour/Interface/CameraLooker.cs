using UnityEngine;

public class CameraLooker : MonoBehaviour
{
    public bool updateObject = false;
    void Update()
    {
        if(updateObject)
            transform.LookAt(Camera.main.transform);
    }
}
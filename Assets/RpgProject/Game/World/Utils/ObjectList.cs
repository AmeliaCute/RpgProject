using UnityEngine;

public class ObjectList : MonoBehaviour
{
    public GameObject[] UnityObjlist;
    public static GameObject[] Objlist;

    private void Start()
    {
        Objlist = UnityObjlist;
    }

    public static GameObject GetObject(int index)
    {
        return Objlist[index];
    }
}
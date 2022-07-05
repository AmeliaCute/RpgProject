using UnityEngine;

public class IconList : MonoBehaviour
{
    public Sprite[] Unityiconlist = new Sprite[0];
    public static Sprite[] iconlist = new Sprite[0];

    private void Start()
    {
        iconlist = Unityiconlist;
    }

    public static Sprite GetSprite(int index)
    {
        return iconlist[index];
    }
}
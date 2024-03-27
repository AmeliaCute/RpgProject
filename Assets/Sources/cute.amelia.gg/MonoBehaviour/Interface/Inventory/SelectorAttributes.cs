using UnityEngine;
using UnityEngine.UI;           

public class SelectorAttributes : MonoBehaviour
{
    [SerializeField] private Text name,value;

    public void Setup(ItemAttribute item)
    {
        name.text = item.name;
        value.text = item.value;
    }
}
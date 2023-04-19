using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class ChoiceText : MonoBehaviour
{
    private Text text;

    private void Awake()
    {
        text = GetComponent<Text>();
    }

    public void setText(string text)
    {
        this.text.text = text;
    }

    public void setSelected(bool selected)
    {
        text.color = selected ? Color.yellow : Color.white;
    }

    public void Update()
    {
        text.enabled = true;
        text.GetComponentInChildren<Image>().enabled = true;
    }   
}
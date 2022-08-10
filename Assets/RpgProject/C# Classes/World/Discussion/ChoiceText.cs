using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

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
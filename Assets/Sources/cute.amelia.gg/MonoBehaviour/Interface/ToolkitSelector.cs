using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToolkitSelector : MonoBehaviour
{
    [SerializeField] private Image icon;
    [SerializeField] private Text title;
    [SerializeField] private Text description;
    [SerializeField] private Animator animator;

    public void SetSelector(ItemData item)
    {
        animator.Play("SelectorReload"); /*Supposed to be played only once*/
        icon.sprite = item.icon;
        title.text = item.name;
        description.text = item.description;
    }
}
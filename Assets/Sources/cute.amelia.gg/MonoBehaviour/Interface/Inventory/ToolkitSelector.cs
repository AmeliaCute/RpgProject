using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToolkitSelector : MonoBehaviour
{
    [SerializeField] private Image icon, background;
    [SerializeField] private Text title,description;
    [SerializeField] private Text MainStat, SubStat;
    [SerializeField] private GameObject attributeList;
    [SerializeField] private GameObject AttributeUI01Prefab;
    [SerializeField] private VerticalLayoutGroup vlg;

    public IEnumerator SetSelector(ItemInstance item)
    {
        vlg.enabled = false;

        Debug.Log($"Setting Selector to {item.getCurrent().itemName}");
        icon.sprite = item.getCurrent().icon;
        title.text = item.getCurrent().itemName;
        description.text = item.getCurrent().description;
        background.color = item.getCurrent().getRarityColor();

        for (var i = 0; i < attributeList.transform.childCount; ++i)
            Destroy(attributeList.transform.GetChild(i).gameObject);
        MainStat.text = "";
        SubStat.text = "";

        foreach (ItemAttribute attribute in item.getCurrent().attribute)
        {
            if(attribute.MainStat)
                MainStat.text = attribute.value + " " + attribute.StatNameAbreviations;
            else if(attribute.SubStat)
                SubStat.text = attribute.value + " " + attribute.StatNameAbreviations;
            else
            {
                var it = Instantiate(AttributeUI01Prefab);
                it.GetComponent<SelectorAttributes>().Setup(attribute);
                it.transform.SetParent(attributeList.transform, false);
            }
        }

        yield return new WaitForEndOfFrame();
        vlg.enabled = true;

        yield return null;
    }
}

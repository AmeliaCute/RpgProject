using RpgProject.Objects;
using UnityEngine;
using UnityEngine.UI;

namespace RpgProject.UI
{
    public class ItemGraphique
    {
        public static GameObject itemIcon(ItemComponent x, Vector2 pos, int iconSize)
        {
            GameObject icon = new GameObject("UI-ICON_"+x.getItem().getName()+"+"+x.getQuantity());
            RectTransform icon_rectTransform = icon.AddComponent<RectTransform>();
            icon.layer = LayerMask.NameToLayer("UI");
            icon_rectTransform.localScale = new Vector2(iconSize, iconSize);
            icon_rectTransform.position = new Vector3(960+pos.x, 540+pos.y, 0);
            
            iconSize = iconSize/100;
            GameObject background = new GameObject("Background");
            background.transform.SetParent(icon.transform);
            background.layer = LayerMask.NameToLayer("UI");
            background.AddComponent<RectTransform>();
            background.GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);

            GameObject imgRarity = new GameObject("imgRarity");
            imgRarity.transform.SetParent(background.transform);
            imgRarity.layer = LayerMask.NameToLayer("UI");
            imgRarity.AddComponent<Image>();
            imgRarity.GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);
            imgRarity.GetComponent<RectTransform>().localScale = new Vector2(iconSize, iconSize);
            switch(x.getItem().getRarity())
            {
                case Rarity.COMMON:
                    imgRarity.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/Inventory/items/Rarity/common"); 
                    break;
                case Rarity.UNCOMON:
                    imgRarity.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/Inventory/items/Rarity/uncommon"); 
                    break;
                case Rarity.RARE:
                    imgRarity.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/Inventory/items/Rarity/rare"); 
                    break;
                case Rarity.EPIC:
                    imgRarity.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/Inventory/items/Rarity/epic"); 
                    break;
                case Rarity.LEGENDARY:
                    imgRarity.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/Inventory/items/Rarity/legendary"); 
                    break;
                default: 
                    imgRarity.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/Inventory/items/Rarity/common"); 
                    break;
            }

            GameObject item = new GameObject("Icon");
            item.transform.SetParent(background.transform);
            item.layer = LayerMask.NameToLayer("UI");
            item.AddComponent<Image>();
            item.GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);
            item.GetComponent<RectTransform>().localScale = new Vector2(0.85f, 0.85f);
            item.GetComponent<Image>().sprite = x.getItem().getIcon();

            GameObject border = new GameObject("Border");
            border.transform.SetParent(background.transform);
            border.layer = LayerMask.NameToLayer("UI");
            border.AddComponent<Image>();
            border.GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);
            border.GetComponent<RectTransform>().localScale = new Vector2(iconSize, iconSize);
            border.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/Inventory/items/Border");

            if(x.getQuantity() > 1)
            {
                GameObject QuantityOverlay = new GameObject("Quantity_Overlay");
                QuantityOverlay.transform.SetParent(border.transform);
                QuantityOverlay.AddComponent<Image>();
                QuantityOverlay.GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);
                QuantityOverlay.GetComponent<RectTransform>().localScale = new Vector2(1, 1);
                QuantityOverlay.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/Inventory/items/Quantity");

                GameObject QuantityText = new GameObject("Quantity_Text");
                QuantityText.transform.SetParent(QuantityOverlay.transform);
                Text t = QuantityText.AddComponent<Text>();
                RectTransform tRectTransform = t.GetComponent<RectTransform>();
                tRectTransform.localPosition = new Vector3(32, -42, 0);
                tRectTransform.localScale = new Vector2(0.2f, 0.2f);
                tRectTransform.sizeDelta = new Vector2(125, 100);
                t.fontSize = 80;
                t.font = Resources.Load<Font>("Fonts/myriad");
                t.text = x.getQuantity().ToString();
                t.alignment = TextAnchor.MiddleCenter;
                t.color = Color.black;
            }

            return icon;
        }
    }
}
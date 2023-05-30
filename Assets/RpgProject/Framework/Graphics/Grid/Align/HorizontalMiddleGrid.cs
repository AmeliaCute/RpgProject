using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RpgProject.Framework.Graphics
{
    public class HorizontalMiddleGrid : Container
    {
        public float Gap { get; set;} = 0;

        public override GameObject CreateGameObject()
        {
            GameObject containerObject = new GameObject("HorizontalMiddleGrid");
            RectTransform containerRectTransform = containerObject.AddComponent<RectTransform>();
            Image containerImage = containerObject.AddComponent<Image>();
            containerImage.color = Color;

            if(Border)
            {
                var mask = containerObject.AddComponent<Mask>();

                containerImage.sprite = Resources.Load<Sprite>("Sprites/RoundedWhiteSquare");
                containerImage.type = Image.Type.Sliced;

                var backgroundObject = new GameObject("Background");
                var backgroundRectTransform = backgroundObject.AddComponent<RectTransform>();
                var backgroundComponent = backgroundObject.AddComponent<Image>();
                backgroundRectTransform.SetParent(containerRectTransform);
                backgroundComponent.color = Color;
                backgroundComponent.sprite = Optional_ContainerSprite;
                
                backgroundRectTransform.sizeDelta = new UnityEngine.Vector2(Width * Screen.width  / 16f, Height * Screen.height / 9f);
            }

            containerRectTransform.sizeDelta = new Vector2(Width * Screen.width / 16f, Height * Screen.height / 9f);
            containerRectTransform.transform.position = new UnityEngine.Vector2(Offset.x * Screen.width / 16f, Offset.y * Screen.height / 9f);


            float xOffset = 0f;
            RpgClass.RPGLOGGER.Warning("Calculating all child width..");
            foreach (Drawable child in Children)
            {
                if (child != null)
                {
                    var c = child.CreateGameObject().GetComponent<RectTransform>();
                    xOffset -= c.sizeDelta.x / 2;
                    GameObject.Destroy(c.transform.gameObject);
                }
            }
            RpgClass.RPGLOGGER.Log("Childrens width offset: "+xOffset);
            foreach (Drawable child in Children)
            {
                if (child != null)
                {
                    GameObject childObject = child.CreateGameObject();
                    RpgClass.RPGLOGGER.Log("Creating a "+childObject.name);
                    RectTransform childRectTransform = childObject.GetComponent<RectTransform>();

                    float childWidth = childRectTransform.sizeDelta.x;
                    float childXOffset = xOffset + childWidth / 2f;
                    childRectTransform.anchoredPosition = new Vector2(childXOffset, 0f);
                    RpgClass.RPGLOGGER.Log("Child offset applicated to current position ("+child.Offset.x + ",cancel)");

                    xOffset += childWidth + (Gap * Screen.width / 16);

                    if (childObject != null)
                        childObject.transform.SetParent(containerObject.transform, false);

                    RpgClass.RPGLOGGER.Passed("Child created");
                }
            }
            return containerObject;
        }
    }
}
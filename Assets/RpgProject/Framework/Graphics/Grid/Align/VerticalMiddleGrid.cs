using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using RpgProject.Framework.Resource;

namespace RpgProject.Framework.Graphics
{
    public class VerticalMiddleGrid : Container
    {
        public float Gap { get; set;} = 0;

        public override GameObject CreateGameObject()
        {
            GameObject containerObject = new GameObject("VerticalMiddleGrid");
            RectTransform containerRectTransform = containerObject.AddComponent<RectTransform>();
            Image containerImage = containerObject.AddComponent<Image>();
            containerImage.color = Color;

            if (Border)
            {
                var mask = containerObject.AddComponent<Mask>();

                containerImage.sprite = ResourcesManager.BUTTON_ROUNDED_WHITE_SQUARE;
                containerImage.type = Image.Type.Sliced;

                var backgroundObject = new GameObject("Background");
                var backgroundRectTransform = backgroundObject.AddComponent<RectTransform>();
                var backgroundComponent = backgroundObject.AddComponent<Image>();
                backgroundRectTransform.SetParent(containerRectTransform);
                backgroundComponent.color = Color;
                backgroundComponent.sprite = Optional_ContainerSprite;

                backgroundRectTransform.sizeDelta = new UnityEngine.Vector2(Width * Screen.width / 16f, Height * Screen.height / 9f);
            }

            containerRectTransform.sizeDelta = new Vector2(Width * Screen.width / 16f, Height * Screen.height / 9f);
            containerRectTransform.transform.position = new UnityEngine.Vector2(Offset.x * Screen.width / 16f, Offset.y * Screen.height / 9f);


            float yOffset = 0f;
            RpgClass.LOGGER.Warning("Calculating all child height..");
            foreach (Drawable child in Children)
            {
                if (child != null)
                {
                    var c = child.CreateGameObject().GetComponent<RectTransform>();
                    yOffset -= c.sizeDelta.y / 2;
                    GameObject.Destroy(c.transform.gameObject);
                }
            }
            RpgClass.LOGGER.Log("Children's height offset: " + yOffset);
            foreach (Drawable child in Children)
            {
                if (child != null)
                {
                    GameObject childObject = child.CreateGameObject();
                    RpgClass.LOGGER.Log("Creating a " + childObject.name);
                    RectTransform childRectTransform = childObject.GetComponent<RectTransform>();

                    float childHeight = childRectTransform.sizeDelta.y;
                    float childYOffset = yOffset + childHeight / 2f;
                    childRectTransform.anchoredPosition = new Vector2(0f, childYOffset);
                    RpgClass.LOGGER.Log("Child offset applied to current position (cancel, " + child.Offset.y + ")");

                    yOffset += childHeight + (Gap * Screen.height / 9);

                    if (childObject != null)
                        childObject.transform.SetParent(containerObject.transform, false);

                    RpgClass.LOGGER.Passed("Child created");
                }
            }
            return containerObject;
        }
    }
}
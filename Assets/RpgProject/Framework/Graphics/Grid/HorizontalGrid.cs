using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RpgProject.Framework.Graphics
{
    public class HorizontalGrid : Drawable
    {
        public List<Drawable> Children = new List<Drawable>();
        public UnityEngine.Color Color = UnityEngine.Color.clear;
        public float Gap { get; set;} = 0;
        public float Width;
        public float Height;

        public override GameObject CreateGameObject()
        {
            GameObject containerObject = new GameObject("Container");
            RectTransform containerRectTransform = containerObject.AddComponent<RectTransform>();
            Image containerImage = containerObject.AddComponent<Image>();

            containerRectTransform.sizeDelta = new Vector2(Width * Screen.width / 16f, Height * Screen.height / 9f);
            containerImage.color = Color;

            float xOffset = -(Width * Screen.width / 16f / 2f);
            foreach (Drawable child in Children)
            {
                if (child != null)
                {
                    GameObject childObject = child.CreateGameObject();
                    RectTransform childRectTransform = childObject.GetComponent<RectTransform>();

                    float childWidth = childRectTransform.sizeDelta.x;
                    float childXOffset = xOffset + childWidth / 2f;
                    childRectTransform.anchoredPosition = new Vector2(childXOffset, 0f);

                    xOffset += childWidth + (Gap * Screen.width / 16);

                    if (childObject != null)
                        childObject.transform.SetParent(containerObject.transform, false);
                }
            }
            return containerObject;
        }
    }
}

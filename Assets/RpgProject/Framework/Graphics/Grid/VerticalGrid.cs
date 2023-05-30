using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RpgProject.Framework.Graphics
{
    public class VerticalGrid : Drawable
    {
        public List<Drawable> Children = new List<Drawable>();
        public UnityEngine.Color Color = UnityEngine.Color.clear;
        public float Gap { get; set;} = 0;
        public override GameObject CreateGameObject()
        {
            GameObject containerObject = new GameObject("Container");
            RectTransform containerRectTransform = containerObject.AddComponent<RectTransform>();
            Image containerImage = containerObject.AddComponent<Image>();

            containerRectTransform.sizeDelta = new Vector2(Width * Screen.width / 16f, Height * Screen.height / 9f);
            containerRectTransform.transform.position = new UnityEngine.Vector2(Offset.x * Screen.width / 16f, Offset.y * Screen.height / 9f);
            containerImage.color = Color;

            float yOffset = (Height * Screen.height / 9f / 2f);
            foreach (Drawable child in Children)
            {
                if (child != null)
                {
                    GameObject childObject = child.CreateGameObject();
                    RectTransform childRectTransform = childObject.GetComponent<RectTransform>();

                    float childHeight = childRectTransform.sizeDelta.y;
                    float childYOffset = yOffset - childHeight / 2f;
                    childRectTransform.anchoredPosition = new Vector2(0f, childYOffset);

                    yOffset -= childHeight + (Gap * Screen.height / 9f);

                    if (childObject != null)
                        childObject.transform.SetParent(containerObject.transform, false);
                }
            }
            return containerObject;
        }
    }
}

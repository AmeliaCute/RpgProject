using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

namespace RpgProject.Framework.Graphics
{
    public class Container : Drawable
    {
        public List<Drawable> Children = new List<Drawable>();
        private UnityEngine.Color _Color = UnityEngine.Color.clear;
        public UnityEngine.Color Color { get { return _Color; } set { _Color = value; } }
        public Sprite Optional_ContainerSprite { get; set; } = null;
        public bool Border { get; set; } = false;

        public override GameObject CreateGameObject()
        {
            GameObject containerObject = new GameObject("Container");
            var rectTransform = containerObject.AddComponent<RectTransform>();
            var image = containerObject.AddComponent<Image>();
            image.color = Color;
            
            if(Border)
            {
                var mask = containerObject.AddComponent<Mask>();

                image.sprite = Resources.Load<Sprite>("Sprites/RoundedWhiteSquare");
                image.type = Image.Type.Sliced;
                image.color = UnityEngine.Color.white;

                var backgroundObject = new GameObject("Background");
                var backgroundRectTransform = backgroundObject.AddComponent<RectTransform>();
                var backgroundComponent = backgroundObject.AddComponent<Image>();
                backgroundRectTransform.SetParent(rectTransform);
                backgroundComponent.color = Color;
                backgroundComponent.sprite = Optional_ContainerSprite;
                
                backgroundRectTransform.sizeDelta = new UnityEngine.Vector2(Width * Screen.width  / 16f, Height * Screen.height / 9f);
            }

            rectTransform.sizeDelta = new UnityEngine.Vector2(Width * Screen.width / 16f, Height * Screen.height / 9f);
            image.color = Color;

            foreach (Drawable child in Children)
                if (child != null)
                {
                    GameObject childObject = child.CreateGameObject();

                    childObject.transform.position = new UnityEngine.Vector2(child._Offset.x * Screen.width / 16f, child._Offset.y * Screen.height / 9f);

                    if (childObject != null)
                        childObject.transform.SetParent(containerObject.transform, false);
                }

            return containerObject;
        }
    }
}
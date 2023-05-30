using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Threading.Tasks;
using System;

namespace RpgProject.Framework.Graphics.Rendering
{
    public class Image : Container
    {
        public Sprite Sprite { get; set; }
        public float Size { get; set; } = 1;

        public override GameObject CreateGameObject()
        {
            GameObject imageObject = new GameObject("Image");
            RpgClass.RPGLOGGER.Log("Creating a new image component");
            var imageRectTransform = imageObject.AddComponent<RectTransform>();
            var imageComponent = imageObject.AddComponent<UnityEngine.UI.Image>();
            imageRectTransform.anchorMin = UnityEngine.Vector2.zero;
            imageRectTransform.anchorMax = UnityEngine.Vector2.one;
            imageRectTransform.sizeDelta = UnityEngine.Vector2.zero;
            imageComponent.sprite = Sprite;
            imageComponent.color = Color.white;

            imageRectTransform.sizeDelta = new Vector2(Size * Screen.width / 16f, Size * Screen.height / 9f);
            imageRectTransform.transform.position = new UnityEngine.Vector2(Offset.x * Screen.width / 16f, Offset.y * Screen.height / 9f);

            return imageObject;
        }
    }
}
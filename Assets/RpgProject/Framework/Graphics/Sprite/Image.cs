using UnityEngine;
using image = UnityEngine.UI.Image;

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

            RectTransform imageRectTransform = imageObject.AddComponent<RectTransform>();
            imageRectTransform.anchorMin = Vector2.zero;
            imageRectTransform.anchorMax = Vector2.one;
            imageRectTransform.sizeDelta = Vector2.zero;
            imageRectTransform.anchoredPosition = Offset * new Vector2(Screen.width / 16f, Screen.height / 9f);

            image imageComponent = imageObject.AddComponent<image>();
            imageComponent.sprite = Sprite;
            imageComponent.color = Color.white;

            imageRectTransform.sizeDelta = new Vector2(Size * Screen.width / 16f, Size * Screen.height / 9f);

            return imageObject;
        }
    }
}

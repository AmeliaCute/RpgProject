using UnityEngine;
using UnityEngine.UI;

namespace RpgProject.Framework.Graphics.Overlays
{
    public class RoundedButton : Button
    {
        public override GameObject CreateGameObject()
        {
            GameObject buttonObject = new GameObject("Button");
            var rectTransform = buttonObject.AddComponent<RectTransform>();
            var image = buttonObject.AddComponent<Image>();
            var mask = buttonObject.AddComponent<Mask>();

            image.sprite = Resources.Load<Sprite>("Sprites/RoundedWhiteSquare");
            image.type = Image.Type.Sliced;
            image.color = Color.white;

            GameObject backgroundObject = new GameObject("Background");
            var backgroundRectTransform = backgroundObject.AddComponent<RectTransform>();
            var backgroundComponent = backgroundObject.AddComponent<Image>();
            backgroundRectTransform.SetParent(rectTransform);
            backgroundComponent.color = Color;
            
            //Optional sprite >> x

            Rendering.Text text = new Rendering.Text
            {
                Label = Label,
                Margin = Margin
            };
            GameObject textobject = text.AddObject(buttonObject);
            
            float xHeight = textobject.GetComponent<Text>().preferredHeight / 2;
            rectTransform.sizeDelta = new UnityEngine.Vector2(_Size * Screen.width / 6, xHeight);
            backgroundRectTransform.sizeDelta = new UnityEngine.Vector2(_Size * Screen.width / 6, xHeight);

            Button_Handlers rtrt = buttonObject.AddComponent<Button_Handlers>();
            rtrt.Action = Action;

            return buttonObject;
        }
    }
}
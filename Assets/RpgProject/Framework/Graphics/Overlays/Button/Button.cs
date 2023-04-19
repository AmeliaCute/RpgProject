using System.Numerics;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Threading;
using System.Threading.Tasks;
using System;

namespace RpgProject.Framework.Graphics.Overlays
{
    public class Button : Drawable
    {
        public int _LabelSize = -1;
        public readonly float INTERFACE_MARGIN = 0.1f;

        public string Label { get; set; }
        public int LabelSize { get { return _LabelSize; } set { _LabelSize = value; } }

        public UnityEngine.Vector2 Size { get; set; }

        public UnityEngine.Color Color { get; set; }

        public Action<object> Action { get; set; }
        
        public override GameObject CreateGameObject()
        {
            GameObject buttonObject = new GameObject("Button");
            var rectTransform = buttonObject.AddComponent<RectTransform>();
            var image = buttonObject.AddComponent<Image>();
            
            var screenWidth = Screen.width;
            var screenHeight = Screen.height;
            var width = screenWidth * 0.125f;
            var height = screenHeight * 0.1f;
            var interfaceWidth =  width * (1 + INTERFACE_MARGIN * 2);
            var interfaceHeight = height * (1 + INTERFACE_MARGIN * 2);

            rectTransform.sizeDelta = new UnityEngine.Vector2(Size.x * width, Size.y *  height);
            
            image.color = Color;

            GameObject textObject = new GameObject("Text");
            var textRectTransform = textObject.AddComponent<RectTransform>();
            var textComponent = textObject.AddComponent<Text>();
            textRectTransform.SetParent(rectTransform);
            textRectTransform.anchorMin = UnityEngine.Vector2.zero;
            textRectTransform.anchorMax = UnityEngine.Vector2.one;
            textRectTransform.sizeDelta = UnityEngine.Vector2.zero;
            textComponent.font = Resources.GetBuiltinResource<Font>("Arial.ttf");
            if(_LabelSize == -1) textComponent.fontSize = (int) Math.Round(25 * ((Size.y + Size.x)/2));
            else textComponent.fontSize = _LabelSize;
            textComponent.alignment = TextAnchor.MiddleCenter;
            textComponent.text = Label;

            var preferredHeight = textComponent.preferredHeight;

            /*Button_Handlers rtrt = new Button_Handlers(Action);
            rtrt.gameObject.transform.SetParent(buttonObject.transform);*/

            return buttonObject;
        }
    }

    public class Button_Handlers : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
    {
        public Action<object> Action { get; set; }
        private bool mouseOver = false;

        public void OnPointerEnter(PointerEventData eventData)
        {
            mouseOver = true;
        }

        public void OnPointerExit(PointerEventData eventData) { mouseOver = false; }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (mouseOver) Task.Factory.StartNew(Action, "alpha");
        }
    }
}
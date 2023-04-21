using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Threading.Tasks;
using System;

namespace RpgProject.Framework.Graphics.Overlays
{
    public class Button : Rendering.Text
    {
        public float _Size = 1f; 
        public float INTERFACE_MARGIN = 1f;

        public Action<object> Action { get; set; }
        public float Size { get {return _Size; } set { _Size = value; }}
        
        public override GameObject CreateGameObject()
        {
            GameObject buttonObject = new GameObject("Button");
            var rectTransform = buttonObject.AddComponent<RectTransform>();
            var image = buttonObject.AddComponent<Image>();

            image.color = Color;

            Rendering.Text text = new Rendering.Text
            {
                Label = Label,
                Margin = Margin
            };
            GameObject textobject = text.AddObject(buttonObject);


            textobject.GetComponent<RectTransform>().SetParent(rectTransform);
            rectTransform.sizeDelta = new UnityEngine.Vector2(_Size * Screen.width / 6, textobject.GetComponent<Text>().preferredHeight / 2);

            Button_Handlers rtrt = buttonObject.AddComponent<Button_Handlers>();
            rtrt.Action = Action;

            return buttonObject;
        }
    }

    public class Button_Handlers : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
    {
        public Action<object> Action { get; set; }
        private bool mouseOver = false;

        public void OnPointerEnter(PointerEventData eventData) { mouseOver = true; }
        public void OnPointerExit(PointerEventData eventData) { mouseOver = false; }
        public void OnPointerClick(PointerEventData eventData) { if (mouseOver) Task.Factory.StartNew(Action, "alpha"); }
    }
}
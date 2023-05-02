using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace RpgProject.Framework.Graphics.Overlays
{
    public class Button : Rendering.Text
    {
        public float _Size = 1f; 
        public float INTERFACE_MARGIN = 1f;

        public Action Action { get; set; }
        public float Size { get {return _Size; } set { _Size = value; }}
        
        public override GameObject CreateGameObject()
        {
            var buttonObject = new GameObject("Button");
            var rectTransform = buttonObject.AddComponent<RectTransform>();
            var image = buttonObject.AddComponent<Image>();
            image.color = Color;

            Rendering.Text text = new Rendering.Text { Label = Label, Margin = Margin };
            GameObject textobject = text.AddObject(buttonObject);
            textobject.GetComponent<RectTransform>().SetParent(rectTransform);

            rectTransform.sizeDelta = new UnityEngine.Vector2(_Size * Screen.width / 6, textobject.GetComponent<Text>().preferredHeight / 2);

            Button_Handlers rtrt = buttonObject.AddComponent<Button_Handlers>();
            rtrt.Action = Action;
            rtrt.targetSize = new Vector2(_Size * Screen.width / 6  + 10, textobject.GetComponent<Text>().preferredHeight / 2 + 10);

            return buttonObject;
        }
    }

    public class Button_Handlers : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
    {
        public Action Action { get; set; }
        private bool mouseOver = false;

        public Vector3 targetSize;
        public float duration = 1.5f; 

        private Vector2 startSize; 
        private float startTime;
        
        void Start()
        {
            startSize = GetComponent<RectTransform>().sizeDelta; 
            startTime = Time.time;
        }

        void Update()
        {
            
        }

        public void OnPointerEnter(PointerEventData eventData) 
        { 
            mouseOver = true; 
        }
        public void OnPointerExit(PointerEventData eventData) 
        { 
            mouseOver = false; 
        }
        public void OnPointerClick(PointerEventData eventData) { Action.Start(); }
    }

    public abstract class Action
    {
        public abstract void Start();
    }
}
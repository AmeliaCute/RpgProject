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
            
            foreach (Drawable child in Children)
                if (child != null)
                {
                    GameObject childObject = child.CreateGameObject();
                    RpgClass.RPGLOGGER.Log("Creating a "+childObject.name);

                    childObject.transform.position = new UnityEngine.Vector2(child.Offset.x * Screen.width / 16f, child.Offset.y * Screen.height / 9f);
                    RpgClass.RPGLOGGER.Log("Child offset applicated to current position ("+child.Offset.x + "," + child.Offset.y + ")");


                    if (childObject != null)
                        childObject.transform.SetParent(buttonObject.transform, false);

                    RpgClass.RPGLOGGER.Passed("Child created");
                }

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
            Action.OnObjectUpdate();
        }

        public void OnPointerEnter(PointerEventData eventData) 
        { 
            mouseOver = true; 
            Action.OnMouseEnter();
        }
        public void OnPointerExit(PointerEventData eventData) 
        { 
            mouseOver = false; 
            Action.OnMouseExit();
        }
        public void OnPointerClick(PointerEventData eventData) { Action.Start(); }
    }

    public abstract class Action
    {
        public abstract void Start();
        public virtual void OnMouseEnter() {}
        public virtual void OnMouseExit() {}
        public virtual void OnObjectUpdate() {}
    }
}
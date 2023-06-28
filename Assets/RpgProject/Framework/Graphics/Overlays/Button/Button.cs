using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace RpgProject.Framework.Graphics.Overlays
{
    public class Button : Rendering.Text
    {
        public float Size { get; set; } = 1f;
        public float InterfaceMargin { get; set; } = 1f;

        public Action Action { get; set; }

        public override GameObject CreateGameObject()
        {
            var buttonObject = new GameObject("Button");
            var rectTransform = buttonObject.AddComponent<RectTransform>();
            var image = buttonObject.AddComponent<Image>();
            image.color = Color;

            Rendering.Text text = new Rendering.Text { Label = Label, Margin = Margin };
            GameObject textObject = text.AddObject(buttonObject);
            RectTransform textRectTransform = textObject.GetComponent<RectTransform>();
            textRectTransform.SetParent(rectTransform);

            rectTransform.sizeDelta = new Vector2(Size * Screen.width / 6, textRectTransform.GetComponent<Text>().preferredHeight / 2);

            foreach (Drawable child in Children)
            {
                if (child != null)
                {
                    GameObject childObject = child.CreateGameObject();
                    RpgClass.LOGGER.Log("Creating a " + childObject.name);

                    childObject.transform.position = new Vector2(child.Offset.x * Screen.width / 16f, child.Offset.y * Screen.height / 9f);
                    RpgClass.LOGGER.Log("Child offset applied to current position (" + child.Offset.x + "," + child.Offset.y + ")");

                    if (childObject != null)
                        childObject.transform.SetParent(buttonObject.transform, false);

                    RpgClass.LOGGER.Passed("Child created");
                }
            }

            ButtonHandlers buttonHandlers = buttonObject.AddComponent<ButtonHandlers>();
            buttonHandlers.Action = Action;
            buttonHandlers.targetSize = new Vector2(Size * Screen.width / 6 + 10, textRectTransform.GetComponent<Text>().preferredHeight / 2 + 10);

            return buttonObject;
        }
    }

    public class ButtonHandlers : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
    {
        public Action Action { get; set; }
        private bool mouseOver = false;

        public Vector2 targetSize;
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
            if(Action != null) Action.OnObjectUpdate();
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            mouseOver = true;
            if(Action != null) Action.OnMouseEnter();
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            mouseOver = false;
            if(Action != null) Action.OnMouseExit();
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if(Action != null) Action.Start();
        }
    }

    public abstract class Action
    {
        public abstract void Start();
        public virtual void OnMouseEnter() { }
        public virtual void OnMouseExit() { }
        public virtual void OnObjectUpdate() { }
    }
}

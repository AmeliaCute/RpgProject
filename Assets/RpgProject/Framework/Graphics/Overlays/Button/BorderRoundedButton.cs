using System.Resources;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using RpgProject.Framework.Resource;

namespace RpgProject.Framework.Graphics.Overlays
{
    public class BorderRoundedButton : Button
    {
        public new Vector2 Size { get; set; } = new Vector2(1f, 1f);
        public UnityEngine.Color OptionalBorderColor { get; set; } = Color.white;
        public Sprite Sprite { get; set; } = null;

        public override GameObject CreateGameObject()
        {
            GameObject buttonContainer = new GameObject("ButtonContainer");
            var containerRectTransform = buttonContainer.AddComponent<RectTransform>();

            GameObject buttonObject = new GameObject("Button");
            var rectTransform = buttonObject.AddComponent<RectTransform>();
            rectTransform.SetParent(containerRectTransform);
            var image = buttonObject.AddComponent<Image>();
            var mask = buttonObject.AddComponent<Mask>();

            GameObject borderObject = new GameObject("Border");
            var borderRectTransform = borderObject.AddComponent<RectTransform>();
            var borderImage = borderObject.AddComponent<Image>();
            borderRectTransform.SetParent(containerRectTransform);
            borderRectTransform.sizeDelta = new UnityEngine.Vector2(Size.x * Screen.width / 16, Size.y * Screen.height / 9);
            borderImage.sprite =  ResourcesManager.BUTTON_ROUNDED_WHITE_SQUARE_BORDERED;
            borderImage.type = Image.Type.Sliced;
            borderImage.color = new Color(OptionalBorderColor.r, OptionalBorderColor.g, OptionalBorderColor.b, 0f);

            image.sprite = ResourcesManager.BUTTON_ROUNDED_WHITE_SQUARE;
            image.type = Image.Type.Sliced;
            image.color = Color.white;

            GameObject backgroundObject = new GameObject("Background");
            var backgroundRectTransform = backgroundObject.AddComponent<RectTransform>();
            var backgroundComponent = backgroundObject.AddComponent<Image>();
            backgroundRectTransform.SetParent(rectTransform);
            backgroundComponent.color = Color;
            backgroundComponent.sprite = Sprite;

            Rendering.Text text = new Rendering.Text { Label = Label, Margin = Margin };
            GameObject textObject = text.AddObject(buttonObject);

            foreach (Drawable child in Children)
            {
                if (child != null)
                {
                    GameObject childObject = child.CreateGameObject();
                    RpgClass.RPGLOGGER.Log("Creating a " + childObject.name);

                    childObject.transform.position = new UnityEngine.Vector2(child.Offset.x * Screen.width / 16f, child.Offset.y * Screen.height / 9f);
                    RpgClass.RPGLOGGER.Log("Child offset applied to current position (" + child.Offset.x + "," + child.Offset.y + ")");

                    if (childObject != null)
                        childObject.transform.SetParent(buttonContainer.transform, false);

                    RpgClass.RPGLOGGER.Passed("Child created");
                }
            }

            rectTransform.sizeDelta = new UnityEngine.Vector2(Size.x * Screen.width / 16, Size.y * Screen.height / 9);
            backgroundRectTransform.sizeDelta = rectTransform.sizeDelta;

            BorderRoundedButtonHandlers buttonHandlers = buttonContainer.AddComponent<BorderRoundedButtonHandlers>();
            buttonHandlers.Action = Action;
            buttonHandlers.RectTransform = rectTransform;

            return buttonContainer;
        }
    }

    public class BorderRoundedButtonHandlers : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
    {
        public Action Action { get; set; }
        private Animator animator;
        private Animation animations;
        public RectTransform RectTransform;
        private bool isPointerOver = false;

        void Start()
        {
            animator = gameObject.AddComponent<Animator>();
            animator.runtimeAnimatorController = ResourcesManager.BUTTON_BORDER_CONTROLLER;

            animations = gameObject.AddComponent<Animation>();
            animations.AddClip(ResourcesManager.BUTTON_BORDER_OVER_ANIMATION, "over_buttonborder");
            animations.AddClip(ResourcesManager.BUTTON_BORDER_EXIT_ANIMATION, "exit_buttonborder");
        }

        void Update()
        {
            if(Action != null) Action.OnObjectUpdate();
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (!isPointerOver)
            {
                isPointerOver = true;
                animator.speed = 1;
                animator.Play("over_buttonborder", 0);
                if(Action != null) Action.OnMouseEnter();
            }
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            if (isPointerOver)
            {
                isPointerOver = false;
                animator.speed = 1;
                animator.Play("exit_buttonborder", 0);
                if(Action != null) Action.OnMouseExit();
            }
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if(Action != null) Action.Start();
        }
    }
}
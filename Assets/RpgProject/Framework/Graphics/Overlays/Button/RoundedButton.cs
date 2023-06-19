using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using RpgProject.Framework.Resource;

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

            image.sprite = ResourcesManager.BUTTON_ROUNDED_WHITE_SQUARE;
            image.type = Image.Type.Sliced;
            image.color = Color.white;

            GameObject backgroundObject = new GameObject("Background");
            var backgroundRectTransform = backgroundObject.AddComponent<RectTransform>();
            var backgroundComponent = backgroundObject.AddComponent<Image>();
            backgroundRectTransform.SetParent(rectTransform);
            backgroundComponent.color = Color;

            Rendering.Text text = new Rendering.Text { Label = Label, Margin = Margin };
            GameObject textObject = text.AddObject(buttonObject);

            float xHeight = textObject.GetComponent<Text>().preferredHeight / 2;
            rectTransform.sizeDelta = new UnityEngine.Vector2(Size * Screen.width / 6, xHeight < 50 ? 50 : xHeight);
            backgroundRectTransform.sizeDelta = rectTransform.sizeDelta;

            RoundedButtonHandlers buttonHandlers = buttonObject.AddComponent<RoundedButtonHandlers>();
            buttonHandlers.Action = Action;
            buttonHandlers.RectTransform = rectTransform;

            return buttonObject;
        }
    }

    public class RoundedButtonHandlers : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
    {
        public Action Action { get; set; }
        private Animator animator;
        private Animation animations;
        public RectTransform RectTransform;
        private bool isPointerOver = false;

        void Start()
        {
            animator = gameObject.AddComponent<Animator>();
            animator.runtimeAnimatorController = ResourcesManager.BUTTON_CONTROLLER;
            animations = gameObject.AddComponent<Animation>();
            animations.AddClip(ResourcesManager.BUTTON_OVER_ANIMATION, "over_button");
            animations.AddClip(ResourcesManager.BUTTON_OVER_ANIMATION, "exit_button");
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (!isPointerOver)
            {
                isPointerOver = true;
                animator.speed = 1;
                animator.Play("over_button", 0);
            }
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            if (isPointerOver)
            {
                isPointerOver = false;
                animator.speed = 1;
                animator.Play("exit_button", 0);
            }
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            Action.Start();
        }
    }
}

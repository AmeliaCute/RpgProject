using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Threading.Tasks;
using System;
using System.Threading;

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

            Rendering.Text text = new Rendering.Text { Label = Label, Margin = Margin };
            GameObject textobject = text.AddObject(buttonObject);
            
            float xHeight = textobject.GetComponent<Text>().preferredHeight / 2;
            rectTransform.sizeDelta = new UnityEngine.Vector2(_Size * Screen.width / 6, xHeight < 50 ? 50 : xHeight);
            backgroundRectTransform.sizeDelta = new UnityEngine.Vector2(_Size * Screen.width / 6, xHeight < 50 ? 50 : xHeight);

            RoundedButton_Handlers rtrt = buttonObject.AddComponent<RoundedButton_Handlers>();
            rtrt.Action = Action;
            rtrt.RectTransform = rectTransform;

            return buttonObject;
        }
    }

    public class RoundedButton_Handlers : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
    {
        public Action Action { get; set; }
        public Animator animator;
        public Animation animation_;
        public RectTransform RectTransform;
        private bool isPointerOver = false;
        void Start()
        {
            animator = gameObject.AddComponent<Animator>();
            animator.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("Animations/Ui/Button/Button");
            animation_ = gameObject.AddComponent<Animation>();
            animation_.AddClip(Resources.Load<AnimationClip>("Animations/Ui/Button/over_button"), "over_button");
            animation_.AddClip(Resources.Load<AnimationClip>("Animations/Ui/Button/exit_button"), "exit_button");
        }

        void Update()
        {
            
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
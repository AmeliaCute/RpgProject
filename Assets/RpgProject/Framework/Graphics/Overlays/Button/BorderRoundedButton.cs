using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Threading.Tasks;
using System;
using System.Threading;

namespace RpgProject.Framework.Graphics.Overlays
{
    public class BorderRoundedButton : Button
    {
        public new Vector2 Size {get; set;} = new Vector2(1f,1f);
        public UnityEngine.Color Optional_BorderColor {get; set;} = Color.white;
        public Sprite Sprite {get;set;} = null;
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
            borderImage.sprite = Resources.Load<Sprite>("Sprites/RoundedWhiteSquareBorder");
            borderImage.type = Image.Type.Sliced;
            borderImage.color = new Color(Optional_BorderColor.r, Optional_BorderColor.g, Optional_BorderColor.b, 0f);

            image.sprite = Resources.Load<Sprite>("Sprites/RoundedWhiteSquare");
            image.type = Image.Type.Sliced;
            image.color = Color.white;

            GameObject backgroundObject = new GameObject("Background");
            var backgroundRectTransform = backgroundObject.AddComponent<RectTransform>();
            var backgroundComponent = backgroundObject.AddComponent<Image>();
            backgroundRectTransform.SetParent(rectTransform);
            backgroundComponent.color = Color;
            backgroundComponent.sprite = Sprite;

            Rendering.Text text = new Rendering.Text { Label = Label, Margin = Margin };
            GameObject textobject = text.AddObject(buttonObject);
            
            rectTransform.sizeDelta = new UnityEngine.Vector2(Size.x * Screen.width / 16, Size.y * Screen.height / 9);
            backgroundRectTransform.sizeDelta = new UnityEngine.Vector2(Size.x * Screen.width / 16, Size.y * Screen.height / 9);

            BorderRoundedButton_Handlers rtrt = buttonContainer.AddComponent<BorderRoundedButton_Handlers>();
            rtrt.Action = Action;
            rtrt.RectTransform = rectTransform;

            return buttonContainer;
        }
    }

    public class BorderRoundedButton_Handlers : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
    {
        public Action Action { get; set; }
        public Animator animator;
        public Animation animation_;
        public RectTransform RectTransform;
        public bool isPointerOver = false;

        void Start()
        {
            animator = gameObject.AddComponent<Animator>();
            animator.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("Animations/Ui/Button/Buttonborder");
            animation_ = gameObject.AddComponent<Animation>();
            animation_.AddClip(Resources.Load<AnimationClip>("Animations/Ui/Button/over_buttonborder"), "over_buttonborder");
            animation_.AddClip(Resources.Load<AnimationClip>("Animations/Ui/Button/exit_buttonborder"), "exit_buttonborder");
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
                animator.Play("over_buttonborder", 0);
            }
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            if (isPointerOver)
            {
                isPointerOver = false;
                animator.speed = 1;
                animator.Play("exit_buttonborder", 0);
            }
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            Action.Start();
        }
    }

}
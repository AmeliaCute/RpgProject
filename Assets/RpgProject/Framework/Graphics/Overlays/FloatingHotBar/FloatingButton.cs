using System;
using System.Drawing;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace RpgProject.Framework.Graphics.Overlays
{
    public class FloatingButton : Button
    {
        public override GameObject CreateGameObject()
        {
            GameObject buttonObject = new GameObject("Button");
            var rectTransform = buttonObject.AddComponent<RectTransform>();
            var image = buttonObject.AddComponent<Image>();

            image.color = new UnityEngine.Color(Color.r,Color.g,Color.b, 0f);

            Rendering.Text text = new Rendering.Text { Label = Label, LabelSize = Mathf.RoundToInt(1f * 30 * (Screen.height / 1080f)), Margin = Margin, LabelFont = Resources.Load<Font>("Fonts/NerdFont") };
            GameObject textobject = text.AddObject(buttonObject);
            textobject.GetComponent<RectTransform>().offsetMin = new Vector2(Mathf.Round(-7.5f * (Screen.height / 1080f)), 0f);
            
            rectTransform.sizeDelta = new UnityEngine.Vector2(_Size * Screen.width / 16, _Size * Screen.height / 9);

            FloatingButton_Handlers rtrt = buttonObject.AddComponent<FloatingButton_Handlers>();
            rtrt.Action = Action;
            rtrt.RectTransform = rectTransform;

            return buttonObject;
        }
    }

    public class FloatingButton_Handlers : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
    {
        public Action Action { get; set; }
        public Animator animator;
        public Animation animation_;
        public RectTransform RectTransform;
        public bool isPointerOver = false;

        void Start()
        {
            animator = gameObject.AddComponent<Animator>();
            animator.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("Animations/Ui/Button/Buttonfloating");
            animation_ = gameObject.AddComponent<Animation>();
            animation_.AddClip(Resources.Load<AnimationClip>("Animations/Ui/Button/over_buttonfloating"), "over_buttonfloating");
            animation_.AddClip(Resources.Load<AnimationClip>("Animations/Ui/Button/exit_buttonfloating"), "exit_buttonfloating");
            animation_.AddClip(Resources.Load<AnimationClip>("Animations/Ui/Button/click_buttonfloating"), "click_buttonfloating");
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
                animator.Play("over_buttonfloating", 0);
            }
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            if (isPointerOver)
            {
                isPointerOver = false;
                animator.speed = 1;
                animator.Play("exit_buttonfloating", 0);
            }
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            animator.Play(null);
            animator.Play("click_buttonfloating", 0);
            Action.Start();
        }
    }
}
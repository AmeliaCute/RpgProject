using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using RpgProject.Framework.Resource;

namespace RpgProject.Framework.Graphics
{
    public class Container : Drawable
    {
        public List<Drawable> Children { get; set; } = new List<Drawable>();

        public Color Color { get; set; } = Color.clear;

        public Sprite Optional_ContainerSprite { get; set; } = null;

        public bool Border { get; set; } = false;

        // Fade duration is in ms
        public float AnimSpeed { get; set; } = -1;

        public AnimationClip fadeContainerAnimation;
        public RuntimeAnimatorController fadeContainerAnimationController;

        public Container()
        {
            fadeContainerAnimation = ResourcesManager.CONTAINER_FADE_ANIMATION;
            fadeContainerAnimationController = ResourcesManager.CONTAINER_CONTROLLER;
        }

        public override GameObject CreateGameObject()
        {
            GameObject containerObject = new GameObject("Container");
            RpgClass.RPGLOGGER.Log("Creating a new container");
            RectTransform rectTransform = containerObject.AddComponent<RectTransform>();
            rectTransform.anchoredPosition = Offset * new Vector2(Screen.width / 16f, Screen.height / 9f);
            Image image = containerObject.AddComponent<Image>();
            image.color = Color;

            if (Border)
            {
                GameObject backgroundObject = new GameObject("Background");
                RectTransform backgroundRectTransform = backgroundObject.AddComponent<RectTransform>();
                Image backgroundComponent = backgroundObject.AddComponent<Image>();
                backgroundRectTransform.SetParent(rectTransform);
                backgroundComponent.color = Color;
                backgroundComponent.sprite = Optional_ContainerSprite;
                backgroundRectTransform.sizeDelta = new Vector2(Width * Screen.width / 16f, Height * Screen.height / 9f);

                Mask mask = containerObject.AddComponent<Mask>();
                image.sprite = ResourcesManager.BUTTON_ROUNDED_WHITE_SQUARE;
                image.type = Image.Type.Sliced;
                image.color = Color.white;
            }

            rectTransform.sizeDelta = new Vector2(Width * Screen.width / 16f, Height * Screen.height / 9f);
            image.color = Color;

            RpgClass.RPGLOGGER.Log("Adding children to the container");
            foreach (Drawable child in Children)
            {
                if (child != null)
                {
                    GameObject childObject = child.CreateGameObject();
                    RpgClass.RPGLOGGER.Log("Creating a " + childObject.name);

                    childObject.transform.SetParent(containerObject.transform, false);
                    RectTransform childRectTransform = childObject.GetComponent<RectTransform>();
                    childRectTransform.anchoredPosition = child.Offset * new Vector2(Screen.width / 16f, Screen.height / 9f);

                    RpgClass.RPGLOGGER.Log("Child offset applied to current position (" + child.Offset.x + "," + child.Offset.y + ")");
                    RpgClass.RPGLOGGER.Log("Child created");
                }
            }

            if (AnimSpeed > 0)
            {
                Animator containerAnimator = containerObject.AddComponent<Animator>();
                Animation containerAnimation = containerObject.AddComponent<Animation>();
                containerAnimation.AddClip(fadeContainerAnimation, "fadeAnim");
                containerAnimator.runtimeAnimatorController = fadeContainerAnimationController;
                ContainerFadeManager containerFadeManager = containerObject.AddComponent<ContainerFadeManager>();
                containerFadeManager.t = AnimSpeed;
            }

            return containerObject;
        }
    }

    public class ContainerFadeManager : MonoBehaviour
    {
        public float t = 1;

        private void Start()
        {
            Animator animator = transform.GetComponent<Animator>();
            animator.speed = -0.004f * t + 5; // Adjust the animation speed based on t
            animator.Play("fadeAnim");
        }
    }
}

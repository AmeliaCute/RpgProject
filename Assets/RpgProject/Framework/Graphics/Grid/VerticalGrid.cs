using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using RpgProject.Framework.Resource;

namespace RpgProject.Framework.Graphics
{
    public class VerticalGrid : Drawable
    {
        public List<Drawable> Children = new List<Drawable>();
        public UnityEngine.Color Color = UnityEngine.Color.clear;
        public float Gap { get; set; } = 0;

        // Fade duration is in ms
        public float FadeDuration { get; set; } = -1;

        public AnimationClip FadeContainerAnimation { get; set; }  = ResourcesManager.CONTAINER_FADE_ANIMATION;
        public RuntimeAnimatorController FadeContainerAnimationController { get; set; } = ResourcesManager.CONTAINER_CONTROLLER;

        public override GameObject CreateGameObject()
        {
            GameObject containerObject = new GameObject("Container");
            RectTransform containerRectTransform = containerObject.AddComponent<RectTransform>();
            Image containerImage = containerObject.AddComponent<Image>();

            containerRectTransform.sizeDelta = new Vector2(Width * Screen.width / 16f, Height * Screen.height / 9f);
            containerRectTransform.anchoredPosition = new Vector2(Offset.x * Screen.width / 16f, Offset.y * Screen.height / 9f);
            containerImage.color = Color;

            float yOffset = Height * Screen.height / 9f / 2f;
            float gapHeight = Gap * Screen.height / 9f;

            foreach (Drawable child in Children)
            {
                if (child != null)
                {
                    GameObject childObject = child.CreateGameObject();
                    RectTransform childRectTransform = childObject.GetComponent<RectTransform>();

                    float childHeight = childRectTransform.sizeDelta.y;
                    float childYOffset = yOffset - childHeight / 2f;
                    childRectTransform.anchoredPosition = new Vector2(0f, childYOffset);

                    yOffset -= childHeight + gapHeight;

                    childObject.transform.SetParent(containerObject.transform, false);
                }
            }

            if (FadeDuration > 0 && FadeContainerAnimation != null && FadeContainerAnimationController != null)
            {
                var containerAnimator = containerObject.AddComponent<Animator>();
                var containerAnimation = containerObject.AddComponent<Animation>();
                containerAnimation.AddClip(FadeContainerAnimation, "fadeAnim");
                containerAnimator.runtimeAnimatorController = FadeContainerAnimationController;
                var containerFadeManager = containerObject.AddComponent<ContainerFadeManager>();
                containerFadeManager.t = FadeDuration;
            }

            return containerObject;
        }
    }
}

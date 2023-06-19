using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RpgProject.Framework.Graphics
{
    public class HorizontalGrid : Drawable
    {
        public List<Drawable> Children = new List<Drawable>();
        public UnityEngine.Color Color = UnityEngine.Color.clear;
        public float Gap { get; set;} = 0;

        // Fade duration is in ms
        public float AnimSpeed { get; set; } = -1;

        public AnimationClip fadeContainerAnimation { get; set; } = Resources.Load<AnimationClip>("Animations/Ui/Container/FadeContainer");
        public RuntimeAnimatorController fadeContainerAnimationController { get; set; } = Resources.Load<RuntimeAnimatorController>("Animations/Ui/Container/Container");

        public override GameObject CreateGameObject()
        {
            GameObject containerObject = new GameObject("Container");
            RectTransform containerRectTransform = containerObject.AddComponent<RectTransform>();
            Image containerImage = containerObject.AddComponent<Image>();

            containerRectTransform.sizeDelta = new Vector2(Width * Screen.width / 16f, Height * Screen.height / 9f);
            containerRectTransform.transform.position = new UnityEngine.Vector2(Offset.x * Screen.width / 16f, Offset.y * Screen.height / 9f);
            containerImage.color = Color;

            float xOffset = -(Width * Screen.width / 16f / 2f);
            foreach (Drawable child in Children)
            {
                if (child != null)
                {
                    GameObject childObject = child.CreateGameObject();
                    RectTransform childRectTransform = childObject.GetComponent<RectTransform>();

                    float childWidth = childRectTransform.sizeDelta.x;
                    float childXOffset = xOffset + childWidth / 2f;
                    childRectTransform.anchoredPosition = new Vector2(childXOffset, 0f);

                    xOffset += childWidth + (Gap * Screen.width / 16);

                    if (childObject != null)
                        childObject.transform.SetParent(containerObject.transform, false);
                }
            }

            if(AnimSpeed > 0)
            {
                var containerAnimator = containerObject.AddComponent<Animator>();
                var containerAnimation = containerObject.AddComponent<Animation>();
                containerAnimation.AddClip(fadeContainerAnimation, "fadeAnim");
                containerAnimator.runtimeAnimatorController = fadeContainerAnimationController;
                var containerFadeManager = containerObject.AddComponent<ContainerFadeManager>();
                containerFadeManager.t = AnimSpeed;
            }
            return containerObject;
        }
    }
}
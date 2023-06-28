/**
 *
 * UNIMPLEMENTED WORK CAUSE I'M TIRED AND I DON'T WANT TO FIX THAT MF
 *
 */

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RpgProject.Framework.Graphics
{
    public class HorizontalDynamicGrid : HorizontalGrid
    {
        public override GameObject CreateGameObject()
        {
            GameObject containerObject = new GameObject("Container");
            RectTransform containerRectTransform = containerObject.AddComponent<RectTransform>();
            Image containerImage = containerObject.AddComponent<Image>();
            var TotalWidth = GetTotalWidth();

            containerRectTransform.sizeDelta = new Vector2(TotalWidth * Screen.width / 16f, Height * Screen.height / 9f);
            containerRectTransform.transform.position = new UnityEngine.Vector2(Offset.x * Screen.width / 16f, Offset.y * Screen.height / 9f);
            containerImage.color = Color;

            float xOffset = -(TotalWidth * Screen.width / 16f / 2f);
            foreach (Drawable child in Children)
            {
                if (child != null)
                {
                    GameObject childObject = child.CreateGameObject();
                    RectTransform childRectTransform = childObject.GetComponent<RectTransform>();

                    childObject?.transform.SetParent(containerObject.transform, false);
                    float childWidth = childRectTransform.sizeDelta.x;
                    float childXOffset = xOffset + childWidth / 2f;
                    childRectTransform.anchoredPosition = child.Offset * new Vector2(child.Offset.x + (Screen.width / 16f), Screen.height / 9f);

                    xOffset += childWidth + (Gap * Screen.width / 16);
                }
            }

            if (FadeDuration > 0)
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

        private float GetTotalWidth()
        {
            float totalWidth = 0f;
            foreach (Drawable child in Children)
            {
                if (child != null)
                {
                    GameObject childObject = child.CreateGameObject();
                    RectTransform childRectTransform = childObject.GetComponent<RectTransform>();
                    totalWidth += GetChildTotalWidth(childRectTransform);
                    GameObject.Destroy(childObject);
                }
            }
            totalWidth += (Children.Count - 1) * Gap;
            return totalWidth;
        }

        private float GetChildTotalWidth(RectTransform parentRectTransform)
        {
            float totalWidth = 0f;
            foreach (Transform childTransform in parentRectTransform)
            {
                RectTransform childRectTransform = childTransform.GetComponent<RectTransform>();
                if (childRectTransform != null)
                {
                    totalWidth += childRectTransform.sizeDelta.x;
                    totalWidth += GetChildTotalWidth(childRectTransform);
                }
            }
            return totalWidth;
        }

    }
}

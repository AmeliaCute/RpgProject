using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using RpgProject.Framework.Resource;

namespace RpgProject.Framework.Graphics
{
    public class HorizontalScrollableGrid : HorizontalGrid
    {
        public string OptionalName { get; set; } = null;

        public override GameObject CreateGameObject()
        {
            GameObject containerObject = new GameObject(string.IsNullOrEmpty(OptionalName) ? "Container" : OptionalName);
            var containerRectTransform = containerObject.AddComponent<RectTransform>();
            var containerImage = containerObject.AddComponent<Image>();
            var scrollableDiv = containerObject.AddComponent<H_ScrollableHandler>();

            containerObject.AddComponent<Mask>();
            containerImage.color = Color;
            containerImage.sprite = ResourcesManager.BUTTON_WHITE_SQUARE;

            GameObject backgroundObject = new GameObject("BackgroundContainer");
            var backgroundRectTransform = backgroundObject.AddComponent<RectTransform>();
            scrollableDiv.contentTransform = backgroundRectTransform;
            backgroundRectTransform.SetParent(containerRectTransform);

            containerRectTransform.sizeDelta = new Vector2(Width * Screen.width / 16f, Height * Screen.height / 9f);
            containerRectTransform.anchoredPosition = new Vector2(Offset.x * Screen.width / 16f, Offset.y * Screen.height / 9f);
            backgroundRectTransform.sizeDelta = containerRectTransform.sizeDelta;

            float xOffset = -containerRectTransform.sizeDelta.x / 2;
            foreach (Drawable child in Children)
            {
                if (child != null)
                {
                    GameObject childObject = child.CreateGameObject();
                    RectTransform childRectTransform = childObject.GetComponent<RectTransform>();

                    float childWidth = childRectTransform.sizeDelta.x;
                    float childXOffset = xOffset + childWidth / 2f;
                    childRectTransform.anchoredPosition = new Vector2(childXOffset, 0f);

                    xOffset += childWidth + (Gap * Screen.width / 16f);

                    childObject.transform.SetParent(backgroundRectTransform, false);
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
    }

    public class H_ScrollableHandler : MonoBehaviour, IDragHandler, IPointerEnterHandler, IPointerExitHandler
    {
        public RectTransform contentTransform;
        public float speed = 400f;
        public float scrollSpeed = 100f;
        public float smoothing = 25.5f;

        private Vector2 startPos;
        private Vector2 contentStartPos;
        private float smoothX;
        private float childrensSize = 0;
        private bool pointerInside;

        private void Start()
        {
            startPos = transform.position;
            contentStartPos = contentTransform.position;
            smoothX = contentTransform.position.x;

            foreach (Transform child in contentTransform)
                childrensSize += child.GetComponent<RectTransform>().sizeDelta.x;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            pointerInside = true;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            pointerInside = false;
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (childrensSize < contentTransform.sizeDelta.x)
                return;

            float input = eventData.delta.x;
            float scrollInput = Input.GetAxis("Mouse ScrollWheel");

            float newX = contentTransform.position.x + (input + scrollInput * scrollSpeed) * speed * Time.deltaTime;
            newX = Mathf.Clamp(newX, contentStartPos.x, contentStartPos.x + contentTransform.rect.width);

            // Smoothing pos x
            smoothX = Mathf.Lerp(smoothX, newX, smoothing * Time.deltaTime);

            contentTransform.position = new Vector2(smoothX, contentTransform.position.y);

            float percent = (contentTransform.position.x - contentStartPos.x) / contentTransform.rect.width;
            contentTransform.position = new Vector2(startPos.x + percent * contentTransform.rect.width, startPos.y);
        }

        private void Update()
        {
            if (pointerInside && Input.GetAxis("Mouse ScrollWheel") != 0)
                OnDrag(new PointerEventData(EventSystem.current));
        }
    }
}

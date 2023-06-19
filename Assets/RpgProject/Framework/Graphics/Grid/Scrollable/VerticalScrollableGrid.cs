using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using RpgProject.Framework.Resource;

namespace RpgProject.Framework.Graphics
{
    public class VerticalScrollableGrid : VerticalGrid
    {
        public string OptionalName { get; set; } = null;

        // Fade duration is in ms
        public float AnimSpeed { get; set; } = -1;

        public override GameObject CreateGameObject()
        {
            GameObject containerObject = new GameObject(string.IsNullOrEmpty(OptionalName) ? "Container" : OptionalName);
            var containerRectTransform = containerObject.AddComponent<RectTransform>();
            var containerImage = containerObject.AddComponent<Image>();
            var scrollableDiv = containerObject.AddComponent<ScrollableHandler>();

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

            float yOffset = containerRectTransform.sizeDelta.y / 2;
            foreach (Drawable child in Children)
            {
                if (child != null)
                {
                    GameObject childObject = child.CreateGameObject();
                    RectTransform childRectTransform = childObject.GetComponent<RectTransform>();

                    float childHeight = childRectTransform.sizeDelta.y;
                    float childYOffset = yOffset - childHeight / 2f;
                    childRectTransform.anchoredPosition = new Vector2(0f, childYOffset);

                    yOffset -= childHeight + (Gap * Screen.height / 9f);

                    childObject.transform.SetParent(backgroundRectTransform, false);
                }
            }

            if (AnimSpeed > 0)
            {
                var containerAnimator = containerObject.AddComponent<Animator>();
                var containerAnimation = containerObject.AddComponent<Animation>();
                containerAnimation.AddClip(FadeContainerAnimation, "fadeAnim");
                containerAnimator.runtimeAnimatorController = FadeContainerAnimationController;
                var containerFadeManager = containerObject.AddComponent<ContainerFadeManager>();
                containerFadeManager.t = AnimSpeed;
            }

            return containerObject;
        }
    }

    public class ScrollableHandler : MonoBehaviour, IDragHandler, IPointerEnterHandler, IPointerExitHandler
    {
        public RectTransform contentTransform;
        public float speed = 400f;
        public float scrollSpeed = 100f;
        public float smoothing = 25.5f;

        private Vector2 startPos;
        private Vector2 contentStartPos;
        private float smoothY;
        private float childrensSize = 0;
        private bool pointerInside;

        private void Start()
        {
            startPos = transform.position;
            contentStartPos = contentTransform.position;
            smoothY = contentTransform.position.y;

            foreach (Transform child in contentTransform)
            {
                childrensSize += child.GetComponent<RectTransform>().sizeDelta.y;
            }
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
            if (childrensSize < contentTransform.sizeDelta.y)
                return;

            float input = eventData.delta.y;
            float scrollInput = Input.GetAxis("Mouse ScrollWheel") * -1;

            float newY = contentTransform.position.y + (input + scrollInput * scrollSpeed) * speed * Time.deltaTime;
            newY = Mathf.Clamp(newY, contentStartPos.y, contentStartPos.y + contentTransform.rect.height);

            // Smoothing pos y
            smoothY = Mathf.Lerp(smoothY, newY, smoothing * Time.deltaTime);

            contentTransform.position = new Vector2(contentTransform.position.x, smoothY);

            float percent = (contentTransform.position.y - contentStartPos.y) / contentTransform.rect.height;
            contentTransform.position = new Vector2(startPos.x, startPos.y + percent * contentTransform.rect.height);
        }

        private void Update()
        {
            if (pointerInside && Input.GetAxis("Mouse ScrollWheel") != 0)
            {
                OnDrag(new PointerEventData(EventSystem.current));
            }
        }
    }
}
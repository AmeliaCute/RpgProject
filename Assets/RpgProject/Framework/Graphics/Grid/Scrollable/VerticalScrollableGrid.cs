using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace RpgProject.Framework.Graphics
{
    public class VerticalScrollableGrid : VerticalGrid
    {
        public override GameObject CreateGameObject()
        {
            GameObject containerObject = new GameObject("Container");
            var containerRectTransform = containerObject.AddComponent<RectTransform>();
            var containerImage = containerObject.AddComponent<Image>();
            containerObject.AddComponent<Mask>();
            containerImage.color = Color;
            containerImage.sprite = Resources.Load<Sprite>("Sprites/WhiteSquare");
            
            GameObject backgroundObject = new GameObject("BackgroundContainer");
            var backgroundRectTransform = backgroundObject.AddComponent<RectTransform>();
            backgroundObject.AddComponent<Scrollabe_Handler>();
            backgroundRectTransform.SetParent(containerObject.transform);

            containerRectTransform.sizeDelta = new Vector2(Width * Screen.width / 16f, Height * Screen.height / 9f);
            backgroundRectTransform.sizeDelta = new Vector2(Width * Screen.width / 16f, Height * Screen.height / 9f);
            containerRectTransform.transform.position = new UnityEngine.Vector2(_Offset.x * Screen.width / 16f, _Offset.y * Screen.height / 9f);
            

            float yOffset = (Height * Screen.height / 9f / 2f);
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

                    if (childObject != null)
                        childObject.transform.SetParent(backgroundObject.transform, false);
                }
            }
            return containerObject;
        }
    }

    public class Scrollabe_Handler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        public RectTransform contentTransform;
        public float speed = 400f;
        public float scrollSpeed = 100f;
        public float smoothing = 25.5f;

        private Vector2 _startPos;
        private Vector2 _contentStartPos;
        private float _smoothY;
        private bool pointerInside;

        public void OnPointerEnter(PointerEventData eventData)
        {
            pointerInside = true;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            pointerInside = false;
        }

        private void Start()
        {
            _startPos = transform.position;
            contentTransform = GetComponent<RectTransform>();
            _contentStartPos = contentTransform.position;
            _smoothY = contentTransform.position.y;
        }

        private void Update()
        {
            if(pointerInside)
            {
                float input = Input.GetAxis("Vertical");
                float scrollInput = Input.GetAxis("Mouse ScrollWheel") * -1;

                if (Mathf.Abs(input) > 0f || Mathf.Abs(scrollInput) > 0f)
                {
                    float newY = contentTransform.position.y + (input + scrollInput * scrollSpeed) * speed * Time.deltaTime;
                    newY = Mathf.Clamp(newY, _contentStartPos.y, _contentStartPos.y + contentTransform.rect.height);

                    // Lissage de la position Y
                    _smoothY = Mathf.Lerp(_smoothY, newY, smoothing * Time.deltaTime);

                    contentTransform.position = new Vector2(contentTransform.position.x, _smoothY);

                    float percent = (contentTransform.position.y - _contentStartPos.y) / (contentTransform.rect.height);
                    transform.position = new Vector2(_startPos.x, _startPos.y + percent * contentTransform.rect.height);
                }
            }
        }
    }
}

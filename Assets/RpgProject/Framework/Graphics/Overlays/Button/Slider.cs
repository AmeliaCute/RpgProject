using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace RpgProject.Framework.Graphics.Overlay
{

    public class Slider : Container
    {
        public int _LabelSize = -1;
        public readonly float INTERFACE_MARGIN = 1f;

        public string Label { get; set; }
        public int LabelSize { get { return _LabelSize; } set { _LabelSize = value; } }

        public float Size { get; set; }

        public new UnityEngine.Color Color { get; set; }

        public override GameObject CreateGameObject()
        {
            
            return null;
        }
    }

    public class Slider_Handlers : MonoBehaviour, IPointerDownHandler, IDragHandler
    {
        public RectTransform sliderHandle;
        public RectTransform sliderTrack;
        public float minValue = 0f;
        public float maxValue = 1f;
        public float currentValue = 0f;

        private float sliderWidth;
        private float normalizedValue;

        private void Start()
        {
            sliderWidth = sliderTrack.rect.width - sliderHandle.rect.width;
            SetValue(currentValue);
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            UpdateValue(eventData.position);
        }

        public void OnDrag(PointerEventData eventData)
        {
            UpdateValue(eventData.position);
        }

        private void UpdateValue(Vector2 position)
        {
            var localPosition = sliderTrack.InverseTransformPoint(position);
            var delta = localPosition.x - sliderHandle.rect.width / 2;
            delta = Mathf.Clamp(delta, 0f, sliderWidth);

            sliderHandle.anchoredPosition = new Vector2(delta, sliderHandle.anchoredPosition.y);

            normalizedValue = delta / sliderWidth;
            currentValue = minValue + (maxValue - minValue) * normalizedValue;
        }

        public void SetValue(float value)
        {
            currentValue = Mathf.Clamp(value, minValue, maxValue);
            normalizedValue = (currentValue - minValue) / (maxValue - minValue);

            var delta = normalizedValue * sliderWidth;
            sliderHandle.anchoredPosition = new Vector2(delta, sliderHandle.anchoredPosition.y);
        }
    }

}
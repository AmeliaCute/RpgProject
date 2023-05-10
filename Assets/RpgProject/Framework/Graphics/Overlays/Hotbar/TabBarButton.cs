using System;
using System.Drawing;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace RpgProject.Framework.Graphics.Overlays
{
    public class TabBarButton : Button
    {
        public override GameObject CreateGameObject()
        {
            GameObject buttonObject = new GameObject("Button");
            var rectTransform = buttonObject.AddComponent<RectTransform>();
            var image = buttonObject.AddComponent<Image>();

            image.color = new UnityEngine.Color(Color.r,Color.g,Color.b, 0f);

            Rendering.Text text = new Rendering.Text { Label = Label, LabelSize = Mathf.RoundToInt(1f * 30 * (Screen.height / 1080f)), Margin = Margin, LabelFont = Resources.Load<Font>("Fonts/fa-solid") };
            GameObject textobject = text.AddObject(buttonObject);
            textobject.GetComponent<RectTransform>().offsetMin = new Vector2(Mathf.Round(-7.5f * (Screen.height / 1080f)), 0f);
            
            rectTransform.sizeDelta = new UnityEngine.Vector2(_Size * Screen.width / 16, _Size * Screen.height / 9);

            TabButton_Handlers rtrt = buttonObject.AddComponent<TabButton_Handlers>();
            rtrt.Action = Action;

            return buttonObject;
        }
    }

    public class TabButton_Handlers : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
    {
        public Action Action { get; set; }
        private bool isPointerInside = false;
        private bool animPointerExit = false;
        private float startTime;
        private float duration = 0.3f;
        private UnityEngine.Color targetColor;
        private UnityEngine.Color startColor;

        void Start()
        {
            startColor = GetComponentInChildren<Image>().color;
            targetColor = new UnityEngine.Color(startColor.r,startColor.g,startColor.b, 0.6f);
        }

        void Update()
        {
            if(isPointerInside)
            {
                float elapsedTime = Time.time - startTime;
                float t = Mathf.Clamp01(elapsedTime / duration);
                GetComponentInChildren<Image>().color = UnityEngine.Color.Lerp(startColor, targetColor, t);
                
            }
            if(animPointerExit)
            {
                float elapsedTime = Time.time - startTime;
                float t = Mathf.Clamp01(elapsedTime / duration);
                GetComponentInChildren<Image>().color = UnityEngine.Color.Lerp(targetColor, startColor, t);
                if(GetComponentInChildren<Image>().color == startColor) animPointerExit = false;
            }
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            isPointerInside = true;
            startTime = Time.time;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            isPointerInside = false;
            animPointerExit = true;
            startTime = Time.time;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            Action.Start();
        }
    }
}
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Threading.Tasks;
using System;
using System.Threading;

namespace RpgProject.Framework.Graphics.Overlays
{
    public class RoundedButton : Button
    {
        public override GameObject CreateGameObject()
        {
            GameObject buttonObject = new GameObject("Button");
            var rectTransform = buttonObject.AddComponent<RectTransform>();
            var image = buttonObject.AddComponent<Image>();
            var mask = buttonObject.AddComponent<Mask>();

            image.sprite = Resources.Load<Sprite>("Sprites/RoundedWhiteSquare");
            image.type = Image.Type.Sliced;
            image.color = Color.white;

            GameObject backgroundObject = new GameObject("Background");
            var backgroundRectTransform = backgroundObject.AddComponent<RectTransform>();
            var backgroundComponent = backgroundObject.AddComponent<Image>();
            backgroundRectTransform.SetParent(rectTransform);
            backgroundComponent.color = Color;
            
            //Optional sprite >> x

            Rendering.Text text = new Rendering.Text { Label = Label, Margin = Margin };
            GameObject textobject = text.AddObject(buttonObject);
            
            float xHeight = textobject.GetComponent<Text>().preferredHeight / 2;
            rectTransform.sizeDelta = new UnityEngine.Vector2(_Size * Screen.width / 6, xHeight);
            backgroundRectTransform.sizeDelta = new UnityEngine.Vector2(_Size * Screen.width / 6, xHeight);

            RoundedButton_Handlers rtrt = buttonObject.AddComponent<RoundedButton_Handlers>();
            rtrt.Action = Action;
            rtrt.targetSize = new Vector2(_Size * Screen.width / 6  + 5, xHeight + 5);
            rtrt.targetFontSize = text.LabelSize + 2;

            return buttonObject;
        }
    }

    public class RoundedButton_Handlers : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
    {
        public Action Action { get; set; }

        public Vector2 targetSize;
        public float targetFontSize;
        public float duration = 0.2f;

        private float startFontSize;
        private Vector2 startSize;
        private float startTime;
        private bool isPointerInside = false;
        private bool animPointerExit = false;

        void Start()
        {
            startSize = GetComponent<RectTransform>().sizeDelta;
            startFontSize = gameObject.transform.Find("Text").GetComponent<UnityEngine.UI.Text>().fontSize;
        }

        void Update()
        {
            if (isPointerInside)
            {
                float elapsedTime = Time.time - startTime;
                float t = Mathf.Clamp01(elapsedTime / duration);
                GetComponent<RectTransform>().sizeDelta = Vector2.Lerp(startSize, targetSize, t);
                gameObject.transform.Find("Background").GetComponent<RectTransform>().sizeDelta = Vector2.Lerp(startSize, targetSize, t);
                gameObject.transform.Find("Text").GetComponent<UnityEngine.UI.Text>().fontSize = Mathf.RoundToInt(Mathf.Lerp(startFontSize, targetFontSize, t));
            }
            if(animPointerExit)
            {
                float elapsedTime = Time.time - startTime;
                float t = Mathf.Clamp01(elapsedTime / duration);
                GetComponent<RectTransform>().sizeDelta = Vector2.Lerp(targetSize, startSize, t);
                gameObject.transform.Find("Background").GetComponent<RectTransform>().sizeDelta = Vector2.Lerp(targetSize, startSize, t);
                gameObject.transform.Find("Text").GetComponent<UnityEngine.UI.Text>().fontSize = Mathf.RoundToInt(Mathf.Lerp(targetFontSize, startFontSize, t));
                if(GetComponent<RectTransform>().sizeDelta == startSize) animPointerExit = false;
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
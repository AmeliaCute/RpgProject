using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Threading.Tasks;
using System;

namespace RpgProject.Framework.Graphics.Rendering
{
    public class Text : Container
    {
        public int _LabelSize = -1;
        public Font _LabelFont = Resources.Load<Font>("Fonts/Comfortaa-Regular");
        public float _Margin = 0;

        private readonly float INTERFACE_MARGIN = 1f;

        public string Label { get; set; }
        public int LabelSize { get { return _LabelSize; } set { _LabelSize = value; } }
        public Font LabelFont { get { return _LabelFont; } set { _LabelFont = value; } }
        public float Margin { get {return _Margin; } set { _Margin = value; }}
        public override GameObject CreateGameObject()
        {
            GameObject textObject = new GameObject("Text");
            var textRectTransform = textObject.AddComponent<RectTransform>();
            var textComponent = textObject.AddComponent<UnityEngine.UI.Text>();
            textRectTransform.anchorMin = UnityEngine.Vector2.zero;
            textRectTransform.anchorMax = UnityEngine.Vector2.one;
            textRectTransform.sizeDelta = UnityEngine.Vector2.zero;
            textRectTransform.offsetMin = new Vector2(_Margin, _Margin);
            textRectTransform.offsetMax = new Vector2(-_Margin, -_Margin);
            textComponent.font = _LabelFont;
            textComponent.color = Color.white;
            textComponent.fontSize = this.LabelSize == -1 ? Mathf.RoundToInt(INTERFACE_MARGIN *  25 * (Screen.height / 1080f)) : this.LabelSize;
            textComponent.alignment = TextAnchor.MiddleCenter;
            textComponent.text = Label;

            return textObject;
        }

        public GameObject AddObject(GameObject gameObject)
        {
            GameObject textObject = new GameObject("Text");
            var textRectTransform = textObject.AddComponent<RectTransform>();
            textObject.GetComponent<RectTransform>().SetParent(gameObject.GetComponent<RectTransform>());
            var textComponent = textObject.AddComponent<UnityEngine.UI.Text>();
            textRectTransform.anchorMin = UnityEngine.Vector2.zero;
            textRectTransform.anchorMax = UnityEngine.Vector2.one;
            textRectTransform.sizeDelta = UnityEngine.Vector2.zero;
            textRectTransform.offsetMin = new Vector2(_Margin, _Margin);
            textRectTransform.offsetMax = new Vector2(-_Margin, -_Margin);
            textComponent.font = _LabelFont;
            textComponent.color = Color.white;
            textComponent.fontSize = this.LabelSize == -1 ? Mathf.RoundToInt(INTERFACE_MARGIN *  25 * (Screen.height / 1080f)) : this.LabelSize;
            textComponent.alignment = TextAnchor.MiddleCenter;
            textComponent.text = Label;

            return textObject;
        }
    }
}
using UnityEngine;
using UnityEngine.UI;
using  RpgProject.Framework.Resource;

namespace RpgProject.Framework.Graphics.Overlays
{
    public class Header : Container
    {
        public int _LabelSize = Mathf.RoundToInt(1f * 35 * (Screen.height / 1080f));
        public Font _LabelFont = ResourcesManager.COMFORTAA_BOLD;
        public float _Margin = 0;

        public string Label { get; set; }
        public int LabelSize { get { return _LabelSize; } set { _LabelSize = value; } }
        public Font LabelFont { get { return _LabelFont; } set { _LabelFont = value; } }
        public float Margin { get {return _Margin; } set { _Margin = value; }}
        public override GameObject CreateGameObject()
        {
            GameObject textObject = new GameObject("Text");
            var textRectTransform = textObject.AddComponent<RectTransform>();
            var textComponent = textObject.AddComponent<UnityEngine.UI.Text>();
            textComponent.text = Label;
            textRectTransform.sizeDelta = new Vector2(Width * Screen.width / 16, Height * Screen.height / 9f);
            textComponent.font = _LabelFont;
            textComponent.color = Color.white;
            textComponent.fontSize = LabelSize;
            textComponent.alignment = TextAnchor.MiddleCenter;

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
            textComponent.fontSize = LabelSize;
            textComponent.alignment = TextAnchor.MiddleCenter;
            textComponent.text = Label;

            return textObject;
        }
    }
}
using System.Resources;
using UnityEngine;
using text = UnityEngine.UI.Text;
using RpgProject.Framework.Resource;

namespace RpgProject.Framework.Graphics.Rendering
{
    public class Text : Container
    {
        public int LabelSize { get; set; } = 25;
        public Font LabelFont { get; set; } = ResourcesManager.COMFORTAA_REGULAR;
        public float Margin { get; set; } = 0;

        public string Label { get; set; }
        public TextAnchor TextAnchor { get; set; } = TextAnchor.MiddleCenter;


        public override GameObject CreateGameObject()
        {
            text textComponent;
            GameObject textObject = new GameObject("Text");
            RpgClass.LOGGER.Log("Creating a new text component");

            RectTransform textRectTransform = textObject.AddComponent<RectTransform>();
            textRectTransform.anchorMin = Vector2.zero;
            textRectTransform.anchorMax = Vector2.one;
            textRectTransform.sizeDelta = Vector2.zero;
            textRectTransform.offsetMin = new Vector2(Margin, Margin);
            textRectTransform.offsetMax = new Vector2(-Margin, -Margin);

            textComponent = textObject.AddComponent<text>();
            textComponent.font = LabelFont;
            textComponent.color = Color;
            textComponent.fontSize = Mathf.RoundToInt(1f * LabelSize * (Screen.height / 1080f));
            textComponent.alignment = TextAnchor;
            textComponent.text = Label;

            RpgClass.LOGGER.Passed("Text finished to be created");
            return textObject;
        }

        public GameObject AddObject(GameObject gameObject)
        {
            text textComponent;
            GameObject textObject = new GameObject("Text");
            RpgClass.LOGGER.Log("Creating a new text component");

            RectTransform textRectTransform = textObject.AddComponent<RectTransform>();
            try
            {
                RpgClass.LOGGER.Log("Attaching a text component to a " + gameObject.name);
                textRectTransform.SetParent(gameObject.GetComponent<RectTransform>());
            }
            catch
            {
                RpgClass.LOGGER.Error("Attach failed.");
            }

            textRectTransform.anchorMin = Vector2.zero;
            textRectTransform.anchorMax = Vector2.one;
            textRectTransform.sizeDelta = Vector2.zero;
            textRectTransform.offsetMin = new Vector2(Margin, Margin);
            textRectTransform.offsetMax = new Vector2(-Margin, -Margin);

            textComponent = textObject.AddComponent<text>();
            textComponent.font = LabelFont;
            textComponent.color = Color;
            textComponent.fontSize = Mathf.RoundToInt(1f * LabelSize * (Screen.height / 1080f));
            textComponent.alignment = TextAnchor.MiddleCenter;
            textComponent.text = Label;

            RpgClass.LOGGER.Passed("Text finished to be created");
            return textObject;
        }
    }
}

using RpgProject.Framework.Resource;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace RpgProject.FrameworkV2
{
    partial class T_Input : DrawableObject
    {
        public string Value;

        public Font Font { get; set; } = ResourcesManager.COMFORTAA_REGULAR;
        public int FontSize { get; set; } = 14;
        public string PlaceHolderLabel { get; set; } = "Text";
        public string Label { get; set; } = "";
        public GameObject PlaceHolderObject { get; protected set; }
        public GameObject ActualTextObject { get; protected set; }
        public Text PlaceHolder { get; protected set; }
        public Text Text { get; protected set; }
        public InputField Input { get; protected set; }
        public Color32 PlaceHolderColor { get; set; } = new(255,255,255,200);
        public Color32 Color { get; set; } = new(255,255,255,255);
        public Color32 SelectionColor { get; set; } = new(255,0,255,150);
        public TextAnchor Alignement { get; set; } = TextAnchor.MiddleLeft;
        public Material Material { get; set; } = null;
        public bool AlignByGeometry { get; set; } = true;
        public InputField.ContentType ContentType { get; set; } = InputField.ContentType.Standard;
        public InputField.LineType LineType { get; set; } = InputField.LineType.SingleLine;
        public InputField.InputType InputType { get; set; } = InputField.InputType.Standard;
        public UnityAction<string> EndEditEvent { get; set; } = (string x) => { return; };

        public override GameObject Create()
        {
            base.Create();

            InitObjects();
            LinkObjects();

            UpdateFont(Font);
            UpdateFontSize(FontSize);

            UpdateTextLabel(Label);
            UpdatePlaceHolderLabel(PlaceHolderLabel);
            UpdateSelectionColor(SelectionColor);

            UpdateColor(Color);
            UpdatePlaceHolderColor(PlaceHolderColor);

            UpdateTextAlignement(Alignement);
            UpdateMaterial(Material);
                        
            return Object;
        }

        protected void InitObjects()
        {
            PlaceHolderObject = new GameObject("PlaceHolder");
            ActualTextObject = new GameObject("ActualText");

            PlaceHolderObject.transform.SetParent(Object.transform);
            ActualTextObject.transform.SetParent(Object.transform);

            PlaceHolder = PlaceHolderObject.AddComponent<Text>();
            Text = ActualTextObject.AddComponent<Text>();

            PlaceHolderObject.GetComponent<RectTransform>().sizeDelta = RectTransform.sizeDelta;
            ActualTextObject.GetComponent<RectTransform>().sizeDelta = RectTransform.sizeDelta;

            Input = Object.AddComponent<InputField>();
        }

        protected void LinkObjects()
        {
            Input.textComponent = Text;
            Input.placeholder = PlaceHolder;

            Input.onEndEdit.AddListener(EndEditEvent);
            Input.onEndEdit.AddListener( (string x ) => { Value = x; } );
        }

        public void UpdateLabel(string label)
        {
            Label = label;
            if(Text != null)
            {
                Text.text = label;
                PlaceHolder.text = label;
            }
        }

        public void UpdateTextLabel(string label) 
        {
            if(Text != null && Input != null)
            {
                Input.text = label;
            }
        }
        public void UpdatePlaceHolderLabel(string label)
        {
            Label = label;
            if(PlaceHolder != null)
                PlaceHolder.text = label;
        }

        public void UpdateSelectionColor(Color32 color)
        {
            SelectionColor = color;
            if(Input != null)
                Input.selectionColor = color;
        }

        public void UpdateMaterial(Material material)
        {
            Material = material;
            if(Text != null )
            {
                Text.material = material;
                PlaceHolder.material = material;
            }
        }

        public void UpdateFont(Font font)
        {
            Font = font;
            if(Text != null)
            {
                Text.font = font;
                PlaceHolder.font = font;
            }
        }
        
        public void UpdateFontSize(int size)
        {
            FontSize = size;
            if(Text != null)
            {
                Text.fontSize = size;
                PlaceHolder.fontSize = size;
            }
        }

        public void UpdateColor(Color32 color)
        {
            Color = color;
            if(Text != null)
            {
                Text.color = color;
                PlaceHolder.color = color;
            }
        }

        public void UpdatePlaceHolderColor(Color32 color)
        {
            Color = color;
            if(PlaceHolder != null)
            {
                PlaceHolder.color = color;
            }
        }

        public void UpdateTextAlignement(TextAnchor anchor)
        {
            Alignement = anchor;
            if(Text != null)
            {
                Text.alignment = anchor;
                PlaceHolder.alignment = anchor;
            }
        }

        public void UpdateAlignByGeometry(bool align)
        {
            AlignByGeometry = align;
            if(Text != null)
            {
                Text.alignByGeometry = align;
                PlaceHolder.alignByGeometry = align;
            }
        }
    }
}
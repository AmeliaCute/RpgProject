using RpgProject.Framework.Resource;
using UnityEngine;
using UnityEngine.UI;

namespace RpgProject.FrameworkV2
{
    partial class Textable : DrawableObject
    {
        public Font Font { get; set; } = ResourcesManager.COMFORTAA_REGULAR;
        public int FontSize { get; set; } = 14;
        public string Label { get; set; } = "Text";
        public Text Text { get; protected set; } = null;
        public Color32 Color { get; set; } = new(255,255,255,255);
        public TextAnchor Alignement { get; set; } = TextAnchor.MiddleLeft;
        public Material Material { get; set; } = null;
        public bool AlignByGeometry { get; set; } = true;

        public override GameObject Create()
        {
            base.Create();

            Text = Object.AddComponent<Text>();

            UpdateFont(Font);
            UpdateFontSize(FontSize);
            UpdateLabel(Label);
            UpdateColor(Color);
            UpdateTextAlignement(Alignement);
            UpdateMaterial(Material);
                        
            return Object;
        }

        public void UpdateLabel(string label)
        {
            Label = label;
            if(Text != null)
                Text.text = label;
        }

        public void UpdateMaterial(Material material)
        {
            Material = material;
            if(Text != null )
                Text.material = material;
        }

        public void UpdateFont(Font font)
        {
            Font = font;
            if(Text != null)
                Text.font = font;
        }
        
        public void UpdateFontSize(int size)
        {
            FontSize = size;
            if(Text != null)
                Text.fontSize = size;
        }

        public void UpdateColor(Color32 color)
        {
            Color = color;
            if(Text != null)
                Text.color = color;
        }

        public void UpdateTextAlignement(TextAnchor anchor)
        {
            Alignement = anchor;
            if(Text != null)
                Text.alignment = anchor;
        }

        public void UpdateAlignByGeometry(bool align)
        {
            AlignByGeometry = align;
            if(Text != null)
                Text.alignByGeometry = align;
        }
    }
}
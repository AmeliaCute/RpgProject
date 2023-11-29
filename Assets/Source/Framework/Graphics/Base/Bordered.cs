using RpgProject.Framework.Resource;
using RpgProject.FrameworkV2.Generator;
using UnityEngine;
using UnityEngine.UI;

namespace RpgProject.FrameworkV2
{
    partial class Bordered : DrawableObject
    {
        public RawImage ImageComponent { get; protected set; }
        public RoundedTexture RoundedTexture { get; protected set; }
        public Color32 Color { get; set; } = new Color32(0,0,0,0);
        public int BorderRadius { get; set; } = 10;

        public override GameObject Create()
        {
            base.Create();

            ImageComponent = Object.AddComponent<RawImage>();
            RoundedTexture = Object.AddComponent<RoundedTexture>();
            UpdateColor(Color);
            UpdateBorder(BorderRadius);

            return Object;
        }

        public void UpdateColor(Color32 color)
        {
            Color = color;
            if(RoundedTexture != null)
                RoundedTexture.color = color;
        }

        public void UpdateBorder(int borderRadius)
        {
            if(RoundedTexture != null)
            {
                RoundedTexture.borderRadius = borderRadius;
                RoundedTexture.Generate();
            }
        }
    }
}
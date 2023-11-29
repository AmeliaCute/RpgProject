using RpgProject.Framework.Resource;
using UnityEngine;
using UnityEngine.UI;

namespace RpgProject.FrameworkV2
{
    partial class Spritable : DrawableObject
    {
        public Image ImageComponent { get; protected set; }
        public Color32 Color { get; set; } = new Color32(255,255,255,255);
        public Sprite Sprite { get; set; } = null;
        public Image.Type ImageType { get; set; } = Image.Type.Sliced;
        public Material Material { get; set; } = null;

        public override GameObject Create()
        {
            base.Create();

            ImageComponent = Object.AddComponent<Image>();
            UpdateImageType(ImageType);
            UpdateSprite(Sprite);
            UpdateColor(Color);

            if(Material != null)
                UpdateMaterial(Material);

            return Object;
        }

        
        public void UpdateMaterial(Material material)
        {
            Material = material;
            if(ImageComponent != null )
                ImageComponent.material = material;
        }
        public void UpdateImageType(Image.Type type)
        {
            ImageType = type;
            if(ImageComponent != null)
                ImageComponent.type = type;
            
        }

        public void UpdateSprite(Sprite sprite)
        {
            Sprite = sprite;
            if(ImageComponent != null)
                ImageComponent.sprite = sprite;
        }

        public void UpdateColor(Color32 color)
        {
            Color = color;
            if(ImageComponent != null)
                ImageComponent.color = color;
        }
    }
}
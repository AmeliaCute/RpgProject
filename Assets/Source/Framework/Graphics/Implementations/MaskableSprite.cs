using RpgProject.Framework.Resource;
using RpgProject.FrameworkV2.Generator;
using UnityEngine;
using UnityEngine.UI;

namespace RpgProject.FrameworkV2
{
    partial class MaskableSprite : Spritable
    {  
        public int BorderRadius { get; set; } = 25;
        public Mask Mask { get; protected set; } = null;
        public bool Maskable { get; set; } = false;

        public override GameObject Create()
        {
            // ! Test purpose, probably need a rework or just a clean code ver.
            GameObject gameObject = new GameObject(Identifier+"_MASK");
            Mask = gameObject.AddComponent<Mask>();
            RawImage Image = gameObject.AddComponent<RawImage>();
            RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
            rectTransform.sizeDelta = ConvertVectorToUniversalDim(Size);
            rectTransform.position = ConvertVectorToUniversalDim(Position);
            Image.color = Color;
            Image.maskable = Maskable;

            RoundedTexture roundedTexture = gameObject.AddComponent<RoundedTexture>();
            roundedTexture.borderRadius = BorderRadius;
            roundedTexture.color = Color;
            roundedTexture.Generate();
            base.Create();

            Object.transform.SetParent(gameObject.transform, false);

            return gameObject;
        }


    }
}
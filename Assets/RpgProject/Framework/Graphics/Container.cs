using System.Net.Mime;
using System.Numerics;
using System.Drawing;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace RpgProject.Framework.Graphics
{
    public class Container : Drawable
    {
        public List<Drawable> Children = new List<Drawable>();
        private UnityEngine.Color _Color = UnityEngine.Color.clear;

        public float Width { get; set; }
        public float Height { get; set; }
        public UnityEngine.Color Color { get { return _Color; } set { _Color = value; } }

        public override GameObject CreateGameObject()
        {
            GameObject containerObject = new GameObject("Container");
            containerObject.AddComponent<RectTransform>();
            containerObject.AddComponent<Image>();

            containerObject.GetComponent<RectTransform>().sizeDelta = new UnityEngine.Vector2(Width * Screen.width / 16f, Height * Screen.height / 8f);
            containerObject.GetComponent<Image>().color = Color;

            foreach (Drawable child in Children)
                if (child != null)
                {
                    GameObject childObject = child.CreateGameObject();

                    childObject.transform.position = new UnityEngine.Vector2(child._Offset.x * Screen.width / 16f, child._Offset.y * Screen.height / 8f);

                    if (childObject != null)
                        childObject.transform.SetParent(containerObject.transform, false);
                }

            return containerObject;
        }
    }
}
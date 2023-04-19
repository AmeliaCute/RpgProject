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

        public UnityEngine.Vector2 Size { get; set; }

        public UnityEngine.Color Color { get; set; }

        public Container(params Drawable[] children)
        {
            this.Children.AddRange(children);
        }

        public override GameObject CreateGameObject()
        {
            GameObject containerObject = new GameObject("Container");
            containerObject.AddComponent<RectTransform>();
            containerObject.AddComponent<Image>();

            containerObject.GetComponent<RectTransform>().sizeDelta = Size;
            containerObject.GetComponent<Image>().color = Color;

            foreach (Drawable child in Children)
            {
                if (child != null)
                {
                    GameObject childObject = child.CreateGameObject();
                    if (childObject != null)
                    {
                        childObject.transform.SetParent(containerObject.transform, false);
                    }
                }
            }

            return containerObject;
        }
    }
}
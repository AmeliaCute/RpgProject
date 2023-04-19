using UnityEngine;
using UnityEngine.UI;
using System.Threading;
using System.Threading.Tasks;

namespace RpgProject.Framework.Graphics
{
    public abstract class Drawable
    {
        public virtual bool showCursor => false;

        public virtual GameObject CreateGameObject()
        {
            return null;
        }

        public static GameObject Create(params Drawable[] drawables)
        {
            GameObject drawableObject = new GameObject("Drawable");

            foreach (Drawable drawable in drawables)
            {
                GameObject childObject = drawable.CreateGameObject();
                if (childObject != null)
                {
                    childObject.transform.SetParent(drawableObject.transform, false);
                }
            }
            drawableObject.transform.position = new Vector3(960, 540, 0);
            drawableObject.transform.SetParent(GameObject.Find("Canvas").transform);
            return drawableObject;
        }
    }
}
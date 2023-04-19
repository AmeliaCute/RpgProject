using UnityEngine;
using UnityEngine.UI;
using System.Threading;
using System.Threading.Tasks;
using RpgProject.Framework.Graphics.Overlays;

namespace RpgProject.Framework.Graphics
{
    public abstract class Drawable
    {
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

            Texture2D cursorTexture = Resources.Load<Texture2D>("Sprites/Hud/cursor");
            Cursor.SetCursor(cursorTexture, new Vector2(cursorTexture.width / 2, cursorTexture.height / 2), CursorMode.Auto);

            drawableObject.transform.position = new Vector3(960, 540, 0);
            drawableObject.transform.SetParent(GameObject.Find("Canvas").transform);
            return drawableObject;
        }
    }
}
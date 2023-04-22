using System.Threading.Tasks;
using UnityEngine;

namespace RpgProject.Framework.Graphics
{
    public abstract class Drawable
    {
        public UnityEngine.Vector2 _Offset = new UnityEngine.Vector2(0,0);
        public UnityEngine.Vector2 Offset { get { return _Offset; } set { _Offset = value; } }
         public float Width { get; set; }
        public float Height { get; set; }
        public virtual GameObject CreateGameObject() { return null; }

        public static GameObject Create(params Drawable[] drawables)
        {
            GameObject drawableObject = new GameObject("Drawable");

            foreach (Drawable drawable in drawables)
            {
                GameObject childObject = drawable.CreateGameObject();
                if (childObject != null)
                    childObject.transform.SetParent(drawableObject.transform, false);
            }
            
            drawableObject.transform.position = new Vector3(Screen.width/2, Screen.height/2, 0);

            Texture2D cursorTexture = Resources.Load<Texture2D>("Sprites/Hud/cursor");
            Cursor.SetCursor(cursorTexture, new Vector2(cursorTexture.width / 2, cursorTexture.height / 2), CursorMode.Auto);

            drawableObject.transform.SetParent(GameObject.Find("Canvas").transform);
            return drawableObject;
        }

        public static void Clear()
        {
            GameObject.Destroy(GameObject.Find("Drawable"));
        }
    }
}
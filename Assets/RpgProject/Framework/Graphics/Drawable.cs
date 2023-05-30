using System.Threading.Tasks;
using UnityEngine;

namespace RpgProject.Framework.Graphics
{
    public abstract class Drawable
    {
        public UnityEngine.Vector2 Offset { get; set; } = new UnityEngine.Vector2(0,0);
        public float Width { get; set; }
        public float Height { get; set; }
        public virtual GameObject CreateGameObject() { return null; }

        public static GameObject Create(DrawableType type, params Drawable[] drawables)
        {
            GameObject drawableObject = new GameObject(type+"_Drawable");
            RpgClass.RPGLOGGER.Log("Creating a new drawable part of type "+type);

            foreach (Drawable drawable in drawables)
            {
                GameObject childObject = drawable.CreateGameObject();
                if (childObject != null)
                    childObject.transform.SetParent(drawableObject.transform, false);
            }
            
            drawableObject.transform.position = new Vector3(Screen.width/2, Screen.height/2, 0);

            Texture2D cursorTexture = Resources.Load<Texture2D>("Sprites/Hud/cursor");
            Cursor.SetCursor(cursorTexture, new Vector2(cursorTexture.width / 4f, cursorTexture.height / 4f), CursorMode.Auto);

            drawableObject.transform.SetParent(GameObject.Find("Canvas").transform);
            return drawableObject;
        }

        public static GameObject Create(string type, params Drawable[] drawables)
        {
            GameObject drawableObject = new GameObject(type+"_Drawable");
            RpgClass.RPGLOGGER.Log("Creating a new drawable part of type"+type);

            foreach (Drawable drawable in drawables)
            {
                GameObject childObject = drawable.CreateGameObject();
                if (childObject != null)
                    childObject.transform.SetParent(drawableObject.transform, false);
            }
            
            drawableObject.transform.position = new Vector3(Screen.width/2, Screen.height/2, 0);

            Texture2D cursorTexture = Resources.Load<Texture2D>("Sprites/Hud/cursor");
            Cursor.SetCursor(cursorTexture, new Vector2(cursorTexture.width / 4f, cursorTexture.height / 4f), CursorMode.Auto);

            drawableObject.transform.SetParent(GameObject.Find("Canvas").transform);
            return drawableObject;
        }

        public static void Clear(DrawableType type)
        {
            GameObject.Destroy(GameObject.Find(type+"_Drawable"));
            RpgClass.RPGLOGGER.Log("Clearing all Drawable of type "+type);
        }

        public static void Clear(string type)
        {
            GameObject.Destroy(GameObject.Find(type+"_Drawable"));
            RpgClass.RPGLOGGER.Log("Clearing all Drawable of type "+type);
        }

        public static void ClearAll()
        {
            GameObject.Destroy(GameObject.Find("Overlay_Drawable"));
            GameObject.Destroy(GameObject.Find("Foreground_Drawable"));
            GameObject.Destroy(GameObject.Find("Background_Drawable"));
            RpgClass.RPGLOGGER.Log("Clearing all Drawable in the scene");
        }
    }

    public enum DrawableType
    {
        Overlay,
        Foreground,
        Background
    }
}
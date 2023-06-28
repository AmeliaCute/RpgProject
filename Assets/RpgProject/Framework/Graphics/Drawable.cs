using System.Threading.Tasks;
using UnityEngine;

namespace RpgProject.Framework.Graphics
{
    public abstract class Drawable
    {
        public Vector2 Offset { get; set; } = Vector2.zero;

        public float Width { get; set; }

        public float Height { get; set; }

        public virtual GameObject CreateGameObject()
        {
            RpgClass.LOGGER.Error("You can't create a base Drawable object by using method CreateGameObject(). use extends of Drawable instead.");
            return null;
        }

        public static GameObject Create(DrawableType type, params Drawable[] drawables)
        {
            string typeName = type.ToString();
            GameObject drawableObject = new GameObject(typeName + "_Drawable");
            RpgClass.LOGGER.Log("Creating a new drawable part of type " + typeName);

            foreach (Drawable drawable in drawables)
            {
                GameObject childObject = drawable.CreateGameObject();
                if (childObject != null) childObject.transform.SetParent(drawableObject.transform, false);
            }

            Canvas canvas = GameObject.FindObjectOfType<Canvas>();
            if (canvas != null) drawableObject.transform.SetParent(canvas.transform);
            else RpgClass.LOGGER.Error("Canvas not found in the scene.");

            drawableObject.transform.position = new Vector3(Screen.width / 2, Screen.height / 2, 0);
            return drawableObject;
        }

        public static GameObject Create(string type, params Drawable[] drawables)
        {
            GameObject drawableObject = new GameObject(type + "_Drawable");
            RpgClass.LOGGER.Log("Creating a new drawable part of type " + type);

            foreach (Drawable drawable in drawables)
            {
                GameObject childObject = drawable.CreateGameObject();
                if (childObject != null) childObject.transform.SetParent(drawableObject.transform, false);
            }

            Canvas canvas = GameObject.FindObjectOfType<Canvas>();
            if (canvas != null) drawableObject.transform.SetParent(canvas.transform);
            else RpgClass.LOGGER.Error("Canvas not found in the scene.");

            drawableObject.transform.position = new Vector3(Screen.width / 2, Screen.height / 2, 0);
            return drawableObject;
        }

        public static void Clear(DrawableType type)
        {
            string typeName = type.ToString();
            GameObject gameObject = GameObject.Find(typeName + "_Drawable");
            if (gameObject != null)
            {
                GameObject.Destroy(gameObject);
                RpgClass.LOGGER.Log("Clearing all Drawable of type " + typeName);
            }
        }

        public static void Clear(string type)
        {
            GameObject gameObject = GameObject.Find(type + "_Drawable");
            if (gameObject != null)
            {
                GameObject.Destroy(gameObject);
                RpgClass.LOGGER.Log("Clearing all Drawable of type " + type);
            }
        }

        public static void ClearAll()
        {
            Clear(DrawableType.Overlay);
            Clear(DrawableType.Foreground);
            Clear(DrawableType.Background);
            RpgClass.LOGGER.Log("Clearing all Drawable in the scene");
        }
    }

    public enum DrawableType
    {
        Overlay,
        Foreground,
        Background
    }
}
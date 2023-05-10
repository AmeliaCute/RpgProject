using System.Drawing;
using RpgProject.Framework.Graphics.Overlays;
using RpgProject.Framework.Graphics;
using Color = UnityEngine.Color;
using RpgProject.Framework.Graphics.Screens;

namespace RpgProject.Framework.Graphics.Screens
{
    public class StartingMenu
    {
        public StartingMenu()
        {
            Drawable.Create(
                DrawableType.Foreground,
                new Container
                {
                    Width = 16f,
                    Height = 9f,
                    Color = new UnityEngine.Color32(56,56,56, 255)
                }
            );
            Drawable.Create(
                DrawableType.Overlay,
                new HorizontalMiddleGrid
                {
                    Border = true,
                    Width = 15.5f,
                    Height = 0.5f,
                    Offset = new UnityEngine.Vector2(0,4f),
                    Color = new Color (0f,0f,0f,0.5f),
                    Children = 
                    {
                        new FloatingButton
                        {
                            Label = "",
                            Color = Color.white,
                            Size = 0.5f,
                        },
                    }
                }
            );
        }
    }
}
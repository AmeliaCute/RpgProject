using System.Drawing;
using RpgProject.Framework.Graphics.Overlays;
using RpgProject.Framework.Graphics;
using Color = UnityEngine.Color;
using RpgProject.Framework.Graphics.Screens;
using RpgProject.Framework.Screens.Inventory;

namespace RpgProject.Framework.Graphics.Screens
{
    public class InventoryMenu
    {
        public InventoryMenu()
        {
            Drawable.Create(
                DrawableType.Foreground,
                new Container
                {
                    Width = 16f,
                    Height = 9f,
                    Color = new UnityEngine.Color32(0,0,0, 210),
                }
            );
            Drawable.Create(
                "Inventory.Container",
                new Container
                {
                    Width = 6.8f,
                    Height = 8.5f,
                    Offset = new UnityEngine.Vector2(-3.9f,-0.3f),
                    Color = new UnityEngine.Color32(40,40,40,255),
                }
            );
            Drawable.Create(
                DrawableType.Overlay,
                ItemHotBar.Menu
            );
        }
    }
}
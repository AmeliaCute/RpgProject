using System.Drawing;
using RpgProject.Framework.Graphics.Overlays;
using RpgProject.Framework.Graphics;
using Color = UnityEngine.Color;
using RpgProject.Framework.Graphics.Screens;

namespace RpgProject.Framework.Screens.Inventory
{
    public class ItemHotBar
    {
        public static Drawable Menu = new HorizontalMiddleGrid
        {
            Border = true,
            Width = 6.8f,
            Height = 0.5f,
            Offset = new UnityEngine.Vector2(-3.9f,4f),
            Color = new Color(0.25f,0.25f,0.25f,1f),
            Children = 
            {
                new FloatingButton
                {
                    Label = "", // All
                    Color = Color.white,
                    Size = 0.5f,
                },
                new FloatingButton
                {
                    Label = "", // Weapons
                    Color = Color.white,
                    Size = 0.5f,
                },
                    new FloatingButton
                {
                    Label = "", // Tools
                    Color = Color.white,
                    Size = 0.5f,
                },
                new FloatingButton
                {
                    Label = "", // Shield
                    Color = Color.white,
                    Size = 0.5f,
                },
                new FloatingButton
                {
                    Label = "", // Armor
                    Color = Color.white,
                    Size = 0.5f,
                },
                new FloatingButton
                {
                    Label = "", // Consumables
                    Color = Color.white,
                    Size = 0.5f,
                },
                new FloatingButton
                {
                    Label = "", // Quest
                    Color = Color.white,
                    Size = 0.5f,
                },
                new FloatingButton
                {
                    Label = "", // Furnitures
                    Color = Color.white,
                    Size = 0.5f,
                },
                new FloatingButton
                {
                    Label = "", // Others
                    Color = Color.white,
                    Size = 0.5f,
                },
            }
        };
    }
}
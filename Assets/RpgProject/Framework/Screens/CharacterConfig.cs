using System.Drawing;
using RpgProject.Framework.Graphics.Overlays;
using RpgProject.Framework.Graphics;
using Color = UnityEngine.Color;
using RpgProject.Framework.Graphics.Screens;

namespace RpgProject.Framework.Graphics.Screens
{
    public class HotbarOverlay
    {
        public HotbarOverlay()
        {
            Drawable.Create(
                DrawableType.Overlay,
                new HorizontalGrid
                {
                    Width = 16f,
                    Height = 0.5f,
                    Color = new Color(0.15f,0.15f,0.15f),
                    Offset = new UnityEngine.Vector2(0,4.25f),
                    Children =
                    {
                        new TabBarButton 
                        {
                            Size = 0.5f,
                            Color = Color.cyan,
                            Label = "",
                            Action = new OpenConfigurationScreen()
                        },
                        new Container
                        {
                            Width = 3.3f,
                            Height = 0.5f,
                            Color = Color.clear,
                            Children =
                            {
                                new Header
                                {
                                    Label = "Character creation",
                                    Height = 0.5f,
                                    Width = 3f,
                                    Offset = new UnityEngine.Vector2(0.025f,0)
                                }
                            }
                        },
                        new TabBarButton
                        {
                            Size = 0.5f,
                            Color = Color.white,
                            Label = "",
                        },
                        new TabBarButton
                        {
                            Size = 0.5f,
                            Color = Color.white,
                            Label = "",
                        },
                    }
                }
            );
        }
    }
}

class OpenConfigurationScreen : Action { public override void Start() { if(UnityEngine.GameObject.Find("game.config_Drawable") == null) new ConfigurationScreen(); else Drawable.Clear("game.config"); } }
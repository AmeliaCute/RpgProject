using System.Drawing;
using RpgProject.Framework.Graphics.Overlays;
using RpgProject.Framework.Graphics;
using Color = UnityEngine.Color;

namespace RpgProject.Framework.Graphics.Screens
{
    public class CharacterConfig
    {
        public CharacterConfig()
        {
            Drawable.Create(
                new Container
                {
                    Width = 16f,
                    Height = 9f,
                    Color = UnityEngine.Color.clear,
                    Children = {
                        new HorizontalGrid
                        {
                            Width = 16f,
                            Height = 0.5f,
                            Color = new UnityEngine.Color(0.2f, 0.2f, 0.2f),
                            Offset = new UnityEngine.Vector2(0,4.25f),
                            Children =
                            {
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
                                            Offset = new UnityEngine.Vector2(0.05f,0)
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
                    }
                }
            );
        }
    }
}
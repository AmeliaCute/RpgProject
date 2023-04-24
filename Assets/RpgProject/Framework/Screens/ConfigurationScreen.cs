using RpgProject.Framework.Graphics.Overlays;
using RpgProject.Framework.Graphics;
using Color = UnityEngine.Color;

namespace RpgProject.Framework.Graphics.Screens
{
    public class ConfigurationScreen
    {
        public ConfigurationScreen()
        {
            Drawable.Create(
                "game.config",
                new VerticalGrid
                {   
                    Height = 8.5f,
                    Width = 0.5f,
                    Offset = new UnityEngine.Vector2(-7.75f, -0.25f),
                    Color = new Color(0.15f,0.15f,0.15f),
                },
                new VerticalScrollableGrid
                {
                    Height = 8.5f,
                    Width = 3.5f,
                    Offset = new UnityEngine.Vector2(-5.75f, -0.25f),
                    Color = new Color(0.20f,0.20f,0.20f),
                    Gap = 0.1f,
                    Children = {
                        new Header 
                        {
                            Label = "Hello world!",
                            Height = 0.5f,
                            Width = 3f,
                        },
                        new RoundedButton
                        {
                            Label = "Pommes",
                            Size = 1.2f,
                            Color = new UnityEngine.Color(0,0,0),
                            Action = null,
                        },
                        new RoundedButton
                        {
                            Label = "Pommes",
                            Size = 1.2f,
                            Color = new UnityEngine.Color(0,0,0),
                            Action = null,
                        },
                        new RoundedButton
                        {
                            Label = "Pommes",
                            Size = 1.2f,
                            Color = new UnityEngine.Color(0,0,0),
                            Action = null,
                        },
                        new RoundedButton
                        {
                            Label = "Pommes",
                            Size = 1.2f,
                            Color = new UnityEngine.Color(0,0,0),
                            Action = null,
                        },
                        new RoundedButton
                        {
                            Label = "Pommes",
                            Size = 1.2f,
                            Color = new UnityEngine.Color(0,0,0),
                            Action = null,
                        },
                        new RoundedButton
                        {
                            Label = "Pommes",
                            Size = 1.2f,
                            Color = new UnityEngine.Color(0,0,0),
                            Action = null,
                        },
                        new RoundedButton
                        {
                            Label = "Pommes",
                            Size = 1.2f,
                            Color = new UnityEngine.Color(0,0,0),
                            Action = null,
                        },
                        new RoundedButton
                        {
                            Label = "Pommes",
                            Size = 1.2f,
                            Color = new UnityEngine.Color(0,0,0),
                            Action = null,
                        },
                        new RoundedButton
                        {
                            Label = "Pommes",
                            Size = 1.2f,
                            Color = new UnityEngine.Color(0,0,0),
                            Action = null,
                        },
                        new RoundedButton
                        {
                            Label = "Pommes",
                            Size = 1.2f,
                            Color = new UnityEngine.Color(0,0,0),
                            Action = null,
                        },
                        new RoundedButton
                        {
                            Label = "Pommes",
                            Size = 1.2f,
                            Color = new UnityEngine.Color(0,0,0),
                            Action = null,
                        },
                        new RoundedButton
                        {
                            Label = "Pommes",
                            Size = 1.2f,
                            Color = new UnityEngine.Color(0,0,0),
                            Action = null,
                        },

                        new RoundedButton
                        {
                            Label = "Pommes",
                            Size = 1.2f,
                            Color = new UnityEngine.Color(0,0,0),
                            Action = null,
                        },
                        new RoundedButton
                        {
                            Label = "Pommes",
                            Size = 1.2f,
                            Color = new UnityEngine.Color(0,0,0),
                            Action = null,
                        },
                        new RoundedButton
                        {
                            Label = "Pommes",
                            Size = 1.2f,
                            Color = new UnityEngine.Color(0,0,0),
                            Action = null,
                        },
                        new RoundedButton
                        {
                            Label = "Pommes",
                            Size = 1.2f,
                            Color = new UnityEngine.Color(0,0,0),
                            Action = null,
                        },
                        new RoundedButton
                        {
                            Label = "Pommes",
                            Size = 1.2f,
                            Color = new UnityEngine.Color(0,0,0),
                            Action = null,
                        },
                        new RoundedButton
                        {
                            Label = "Pommes",
                            Size = 1.2f,
                            Color = new UnityEngine.Color(0,0,0),
                            Action = null,
                        },
                        new RoundedButton
                        {
                            Label = "Pommes",
                            Size = 1.2f,
                            Color = new UnityEngine.Color(0,0,0),
                            Action = null,
                        },
                        new RoundedButton
                        {
                            Label = "Pommes",
                            Size = 1.2f,
                            Color = new UnityEngine.Color(0,0,0),
                            Action = null,
                        },
                        new RoundedButton
                        {
                            Label = "Pommes",
                            Size = 1.2f,
                            Color = new UnityEngine.Color(0,0,0),
                            Action = null,
                        },
                        new RoundedButton
                        {
                            Label = "Pommes",
                            Size = 1.2f,
                            Color = new UnityEngine.Color(0,0,0),
                            Action = null,
                        },
                        new RoundedButton
                        {
                            Label = "Pommes",
                            Size = 1.2f,
                            Color = new UnityEngine.Color(0,0,0),
                            Action = null,
                        },

                    }
                }
            );
        }
    }
}
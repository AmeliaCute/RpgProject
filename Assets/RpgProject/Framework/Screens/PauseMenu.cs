using System.Reflection.Emit;
using System.Net.Mime;
using RpgProject.Framework.Graphics.Rendering;
using RpgProject.Framework.Graphics.Overlays;
using UnityEngine;
using RpgProject.Framework.Resource;

namespace RpgProject.Framework.Graphics.Screens
{
    public class PauseMenu
    {
        public PauseMenu()
        {
            Drawable.Create(
                DrawableType.Background,
                new Container{
                    Width = 16f,
                    Height = 9f,
                    Color = new UnityEngine.Color32(0,0,0, 200),
                }
            );

            Drawable.Create(
                DrawableType.Overlay,
                new Container
                {
                    Width = 15.5f,
                    Height = 1f,
                    Border = true,
                    Offset = new UnityEngine.Vector2(0,3.8f),
                    Color = new UnityEngine.Color32(20,20,20, 255),
                    Children = {
                        new HorizontalGrid{
                            Color = new UnityEngine.Color32(20,20,20,255),
                            Width = 3.86f,
                            Height = .9f,
                            Offset = new UnityEngine.Vector2(-5.77f,0),
                            Children = 
                            {
                                new Container{
                                    Width = .9f,
                                    Height = .9f,
                                    Border = true,
                                    Color = UnityEngine.Color.white,
                                    Optional_ContainerSprite = Resources.Load<Sprite>("Sprites/User/Avatar/"+RpgClass.USER.Values.Avatar),
                                },
                                new VerticalGrid{
                                    Color = new UnityEngine.Color32(20,20,20,255),
                                    Width = 3.06f,
                                    Height = .8f,
                                    Children = {
                                        new Container
                                        {
                                            Width = 3.06f,
                                            Height = .25f,
                                            Color = new UnityEngine.Color32(20,20,20,255),
                                            Children = {
                                                new Text
                                                {
                                                    Label = RpgClass.USER.Values.DisplayName,
                                                    Color = new UnityEngine.Color32(255,255,255,255),
                                                    TextAnchor = TextAnchor.MiddleLeft,
                                                    Offset = new UnityEngine.Vector2(0.15f, 0f),
                                                }
                                            }
                                        },
                                        new Container
                                        {
                                            Width = 3.06f,
                                            Height = .14f,
                                            Color = new UnityEngine.Color32(20,20,20,255),
                                            Children = {
                                                new Text
                                                {
                                                    Label = "#"+RpgClass.USER.Values.Identifier,
                                                    Color = new UnityEngine.Color32(80,80,80,255),
                                                    TextAnchor = TextAnchor.MiddleLeft,
                                                    Offset = new UnityEngine.Vector2(0.15f, 0f),
                                                    LabelSize = 14
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        },
                    
                        // Level advancement
                        new HorizontalGrid
                        {
                            Width = 15.5f,
                            Height = .1f,
                            Color = new UnityEngine.Color32(20,20,20,255),
                            Offset = new UnityEngine.Vector2(0,.525f),
                            Children = {
                                new Container
                                {
                                    Color = new UnityEngine.Color32(158,134,255,255),
                                    Width = RpgClass.USER.NextLevelAdvancement() * 15.5f,
                                    Height = 0.1f,
                                }
                            }
                        },

                        new HorizontalMiddleGrid
                        {
                            Width = 5f,
                            Height = .30f,
                            Color = new UnityEngine.Color32(20,20,20,255),
                            Offset = new UnityEngine.Vector2(0,.25f),
                            Children = {
                                new Text
                                {
                                    Label = "Level "+RpgClass.USER.Values.Level,
                                    Color = new UnityEngine.Color32(158,134,255,255),
                                    LabelSize = 30
                                }
                            }
                        },

                        new HorizontalMiddleGrid {
                            Color = new UnityEngine.Color32(20,20,20,255),
                            Width = 5f,
                            Height = .14f,
                            Offset = new UnityEngine.Vector2(0,.05f),
                            Children = {
                                new Text
                                {
                                    Label = "("+RpgClass.USER.Values.Exp +"/"+RpgClass.USER.CalculateExpNextLevel()+"exp)",
                                    Color = new UnityEngine.Color32(158,134,255,255),
                                    LabelSize = 14
                                }
                            }
                        },

                        new HorizontalGrid{
                            Color = new UnityEngine.Color32(20,20,20,255),
                            Width = 2.7f,
                            Height = .9f,
                            Offset = new UnityEngine.Vector2(6.25f,0),
                            Children = {
                                new FloatingButton // Notifications
                                {
                                    Label = "",
                                    Size = .9f,
                                    Color = new UnityEngine.Color32(255,255,255,255),
                                    Action = new QuitGameButtonHandler()
                                },
                                new FloatingButton // Settings
                                {
                                    Label = "",
                                    Size = .9f,
                                    Color = new UnityEngine.Color32(255,255,255,255),
                                    Action = new QuitGameButtonHandler()
                                },
                                new FloatingButton // Quit
                                {
                                    Label = "",
                                    Size = .9f,
                                    Color = new UnityEngine.Color32(255,255,255,255),
                                    Action = new QuitGameButtonHandler()
                                }
                            }
                        }
                    }
                }
            );
        }
    }

    public class QuitGameButtonHandler : Action
    {
        public override void Start()
        {
            UnityEditor.EditorApplication.isPlaying = false;
            Application.Quit();
        }
    }
}

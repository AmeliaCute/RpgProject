using System.Reflection.Emit;
using System.Net.Mime;
using RpgProject.Framework.Graphics.Rendering;
using UnityEngine;

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
                    Color = new UnityEngine.Color32(0,0,0, 150),
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
                                    Width = 2.96f,
                                    Height = .9f,
                                    Children = {
                                        new Container
                                        {
                                            Width = 2.96f,
                                            Height = .26f,
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
                                            Width = 2.96f,
                                            Height = .15f,
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
                        }
                    }
                }
            );
        }
    }
}

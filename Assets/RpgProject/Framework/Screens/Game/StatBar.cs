using System.Drawing;
using RpgProject.Framework.Graphics;
using RpgProject.Framework.Graphics.Rendering;
using UnityEngine;

namespace RpgProject.Framework.Screens.Game
{
    public class StatBar
    {
        public StatBar()
        {
            Drawable.Create(
                "StatBar",
                new Container{
                    Width = 3f,
                    Height = 0.5f,
                    Border = true,
                    Offset = new UnityEngine.Vector2(0, -4f),
                    Color = new UnityEngine.Color32(20,20,20,255),
                    Children = {
                        new HorizontalGrid
                        {
                            Width = 2.9f,
                            Height = 0.5f,
                            Gap = 0.1f,
                            Color = new(20,20,20,255),
                            Children =
                            {
                                new Container {
                                    Width = .4f,
                                    Height = .4f,
                                    Border = true,
                                    Color = UnityEngine.Color.white,
                                    Optional_ContainerSprite = Resources.Load<Sprite>("Sprites/User/Avatar/"+RpgClass.USER.Values.Avatar),
                                },
                                new VerticalMiddleGrid
                                {
                                    Width = 2.5f,
                                    Height = 0.4f,
                                    Color = new(20,20,20,255),
                                    Gap = 0.035f,
                                    Children =
                                    {
                                        new HorizontalGrid
                                        {
                                            Width =2.5f,
                                            Height = 0.05f,
                                            Color = new(20,20,20,255),
                                            Children = {
                                                new Container
                                                {
                                                    Optional_Name = "statbar.endurance.overlay",
                                                    Width = Player.instance.endurance / Player.instance.maxEndurance *2.4f,
                                                    Height = 0.05f,
                                                    Color = new(75,75,225,255),
                                                },
                                            }
                                        },
                                        new HorizontalGrid
                                        {
                                            Width =2.5f,
                                            Height = 0.05f,
                                            Color = new(20,20,20,255),
                                            Children = {
                                                new Container
                                                {
                                                    Optional_Name = "statbar.health.overlay",
                                                    Width = Player.instance.health / Player.instance.maxHealth *2.4f,
                                                    Height = 0.05f,
                                                    Color = new(255,75,75,255),
                                                },
                                            }
                                        }
                                    }
                                }
                            }
                        },
                    }
                }
            );
        }

        public static void UpdateAll()
        {
            Drawable.Clear("StatBar");
            new StatBar();
        }
    }
}
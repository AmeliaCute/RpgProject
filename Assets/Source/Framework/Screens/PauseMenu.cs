using System.Collections;
using RpgProject.Framework.Resource;
using RpgProject.FrameworkV2.Overlays;
using UnityEditor;
using UnityEngine;

namespace RpgProject.FrameworkV2
{
    class PauseMenu
    {
        public Drawable Panel;

        public PauseMenu()
        {
            Panel = new Drawable(
                OnLoad(),
                OnEnd(),
                0,
                new(){ new Handlers.InputEvent(KeyCode.Escape, () => { Panel.End(); })},
                new VerticalGrid
                {
                    Identifier = "PauseMenu_PlayerInfo",
                    Size = new(4f, 2.7f),
                    Position = new(-5.35f, 2.9f),
                    Color = HexColor.convert(RpgClass.SETTINGS.Values.TabColor),
                    Padding = new(50, 0, 10, 0),
                    ChildsAlignement = UnityEngine.TextAnchor.UpperCenter,
                    BorderRadius = 35,
                    Spacing = 5,
                    Children = 
                    {
                        new MaskableSprite
                        {
                            Identifier = "PlayerInfo_Banner",
                            Size = new(3.4f, 1.35f),
                            Color = new(255,255,255,230),
                            Sprite = Resources.Load<Sprite>("Sprites/User/Banner/"+RpgClass.USER.Values.Banner),
                            Children = 
                            {
                                new HorizontalGrid
                                {
                                    Identifier = "PlayerInfo_Container",
                                    Size = new(3.4f, 1.35f),
                                    ChildsAlignement = TextAnchor.MiddleLeft,
                                    Padding = new(15,10,5,5),
                                    Spacing = 5,
                                    Children =
                                    {
                                        new MaskableSprite
                                        {
                                            Identifier = "PlayerInfo_Avatar",
                                            Size = new(1.1f,1.1f),
                                            BorderRadius = 30,
                                            Sprite = Resources.Load<Sprite>("Sprites/User/Avatar/"+RpgClass.USER.Values.AvatarUrl)
                                        },
                                        new VerticalGrid
                                        {
                                            Identifier = "PlayerInfo_Data",
                                            Size = new(2.2f, 1.05f),
                                            Color = new(0,0,0,0),
                                            ChildsAlignement = TextAnchor.UpperCenter,
                                            Children = 
                                            {
                                                new HorizontalGrid
                                                {
                                                    Identifier = "Data_DisplayName",
                                                    Size = new(2.2f, .35f),
                                                    Color = new(0,0,0,0),
                                                    ChildsAlignement = TextAnchor.MiddleLeft,
                                                    Children = 
                                                    {
                                                        new Textable
                                                        {
                                                            Identifier = "Icon",
                                                            Label = "", // https://fontawesome.com/icons/user-large?f=classic&s=solid
                                                            Font = ResourcesManager.FONT_AWESOME_SOLID,
                                                            Alignement = UnityEngine.TextAnchor.MiddleCenter,
                                                            
                                                            FontSize = 25, 
                                                            Size = new (.35f, .35f)
                                                        },
                                                        new T_Input
                                                        {
                                                            Identifier = "Display",
                                                            Label = RpgClass.USER.Values.DisplayName,
                                                            PlaceHolderLabel = RpgClass.USER.Values.DisplayName,
                                                            FontSize = 30,
                                                            Size = new (1.75f, .35f),
                                                            PlaceHolderColor = new(255,255,255,255),
                                                            EndEditEvent = (string x) => {
                                                                if(!string.IsNullOrWhiteSpace(x))
                                                                    RpgClass.USER.ChangeDisplayName(x);
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        },
                        new VerticalGrid 
                        {
                            Identifier = "PlayerInfo_LevelContainer",
                            Size = new(3.4f, .6f),
                            Children =
                            {
                                new HorizontalGrid
                                {
                                    Identifier = "Level_Infos",
                                    Size = new(3.4f, .25f),
                                    ChildsAlignement = TextAnchor.MiddleCenter,
                                    Children = 
                                    {
                                        new Textable 
                                        {
                                            Identifier = "Level",
                                            Size = new(1.65f, .25f),
                                            Color = new(0,0,0,255),
                                            Label = $"Level {RpgClass.USER.Values.Level}", // https://fontawesome.com/icons/angles-up?f=classic&s=solid
                                            Alignement = TextAnchor.MiddleLeft,
                                            Font = ResourcesManager.COMFORTAA_REGULAR,
                                            FontSize = 25,
                                        },
                                        new Textable 
                                        {
                                            Identifier = "Exp",
                                            Size = new(1.65f, .25f),
                                            Color = new(0,0,0,255),
                                            Label = $"Exp {RpgClass.USER.Values.Exp} / {RpgClass.USER.CalculateExpNextLevel()}", // https://fontawesome.com/icons/sparkles?f=classic&s=solid
                                            Alignement = TextAnchor.MiddleRight,
                                            Font = ResourcesManager.COMFORTAA_REGULAR,
                                            FontSize = 25,
                                        }
                                    }
                                },
                                new MaskableSprite
                                {
                                    Identifier = "Level_Completion_MASK",
                                    Size = new(3.4f, .1f),
                                    BorderRadius = 5,
                                    Color = HexColor.convert(RpgClass.SETTINGS.Values.BackgroundAltColor),
                                    Children = 
                                    {
                                        new HorizontalGrid
                                        {
                                            Identifier = "Lavel_Completion",
                                            Size = new(3.4f, .1f),
                                            ChildsAlignement = TextAnchor.UpperLeft,
                                            //Color = HexColor.convert(RpgClass.SETTINGS.Values.BackgroundAltColor),
                                            Children = 
                                            {
                                                new Spritable 
                                                {
                                                    Identifier = "Completion_Bar",
                                                    Color = new(20,150,50,255),
                                                    Size = new(RpgClass.USER.NextLevelAdvancement() * 3.4f < 0.05f ? 0.05f : RpgClass.USER.NextLevelAdvancement() * 3.4f, .1f),
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                },
                new Bordered
                {
                    Identifier = "PauseMenu_MainMenu_STYLE",
                    Size = new(3.6f, 1f),
                    Position = new(-5.15f, 1.55f),
                    Color = HexColor.convert(RpgClass.SETTINGS.Values.BackgroundAltColor),
                    BorderRadius = 35,
                },
                new VerticalGrid
                {
                    Identifier = "PauseMenu_MainMenu",
                    Size = new(4f, 5.9f),
                    Position = new(-5.35f, -1.3f),
                    Color = HexColor.convert(RpgClass.SETTINGS.Values.BackgroundAltColor),
                    Padding = new(55, 5, -25, 5),
                    ChildsAlignement = UnityEngine.TextAnchor.UpperCenter,
                    BorderRadius = 35,
                    Spacing = 8,
                    Children = {
                        PauseMenuButton.Create(
                            "", // https://fontawesome.com/icons/flask-round-potion?f=classic&s=solid
                            "Experiment",
                            () => {
                                Panel?.End();
                            }
                        ),
                        PauseMenuButton.Create(
                            "", // https://fontawesome.com/icons/backpack?f=classic&s=solid
                            "Inventory",
                            () => {
                                Panel?.End();
                            }
                        )
                    }
                },
                new VerticalGrid
                {
                    Identifier = "PauseMenu_Tab",
                    Size = new(.8f, 8.5f),
                    Position = new(-7.35f, 0),
                    Color = HexColor.convert(RpgClass.SETTINGS.Values.TabColor),
                    BorderRadius = 25,
                    ChildsAlignement = TextAnchor.MiddleCenter,
                    Children =
                    {
                        new VerticalGrid 
                        {
                            Identifier = "ExitMenu",
                            Size = new(.75f, 1.1f),
                            ChildsAlignement = TextAnchor.UpperCenter,
                            Padding = new(0,0,10,0),
                            Children = 
                            {
                                PauseMenuTabButton.Create(
                                    "", // https://fontawesome.com/icons/xmark?f=classic&s=solid
                                    () =>
                                    {
                                        Panel.End();
                                    }
                                )
                            }
                        },
                        new VerticalGrid 
                        {
                            Identifier = "Normal",
                            Size = new(.75f, 6.3f),
                            ChildsAlignement = TextAnchor.MiddleCenter,
                            Children =
                            {
                                PauseMenuTabButton.Create(
                                    "", // https://fontawesome.com/icons/gear?f=classic&s=solid
                                    null
                                ),
                                PauseMenuTabButton.Create(
                                    "", // https://fontawesome.com/icons/gear?f=classic&s=solid
                                    null
                                ),
                                PauseMenuTabButton.Create(
                                    "", // https://fontawesome.com/icons/gear?f=classic&s=solid
                                    null
                                )
                                ,PauseMenuTabButton.Create(
                                    "", // https://fontawesome.com/icons/gear?f=classic&s=solid
                                    null
                                ),
                                PauseMenuTabButton.Create(
                                    "", // https://fontawesome.com/icons/flask-round-potion?f=classic&s=solid
                                    null
                                ),
                                PauseMenuTabButton.Create(
                                    "", // https://fontawesome.com/icons/gear?f=classic&s=solid
                                    null
                                )
                            }
                        },
                        new VerticalGrid 
                        {
                            Identifier = "Important",
                            Size = new(.75f, 1.1f),
                            ChildsAlignement = TextAnchor.LowerCenter,
                            Padding = new(0,0,0,10),
                            Children = 
                            {
                                PauseMenuTabButton.Create(
                                    "", // https://fontawesome.com/icons/door-open?f=classic&s=solid
                                    () =>
                                    {
                                        Application.Quit();
                                    }
                                )
                            }
                        }
                    }
                }

            );
        }

        private IEnumerator OnLoad()
        {
            while(Panel == null)
                yield return null;
                
            IEnumerator fade = Panel.Fade(.2f,1.1f,.65f);
            IEnumerator left = Panel.Left(Screen.width*-.5f, Panel.RectTransform.anchoredPosition.x, .65f);

            while (left.MoveNext() && fade.MoveNext())
                yield return null;
            
            RpgClass.MODE_ETA = GAMEMODE.INTERFACE;
        }

        private IEnumerator OnEnd()
        {
            IEnumerator left = Panel.Left(Panel.RectTransform.anchoredPosition.x, Screen.width*-1, .85f);
            IEnumerator fade = Panel.Fade(1, 0, .25f);

            while (left.MoveNext() && fade.MoveNext())
                yield return null;

            GameObject.Destroy(Panel.Object);
            RpgClass.MODE_ETA = GAMEMODE.PLAYING;
        }
    }
}
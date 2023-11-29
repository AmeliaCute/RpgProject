using RpgProject.Framework.Resource;
using UnityEditor;
using UnityEngine;


namespace RpgProject.FrameworkV2.Overlays
{
    partial class PauseMenuPlayerInfo
    {
        public static DrawableObject Create()
        {
            return new VerticalGrid
            {
                Padding = new(8,8,8,8),
                Size = new(3.8f, 2f),
                Color = new(25,25,25,255),
                BorderRadius = 50,
                Children = 
                {
                    new MaskableSprite
                    {
                        Identifier = "PauseMenuPlayerInfo_MaskableSprite_Banner",
                        BorderRadius = 25,
                        Color = new(255,255,255,255),
                        Sprite = Resources.Load<Sprite>("Sprites/User/Banner/"+RpgClass.USER.Values.Banner),
                        Size = new(3.68f, 1),
                        Children = 
                        {
                            new HorizontalGrid
                            {
                                Identifier = "PauseMenuPlayerInfo_HorizontalGrid_PlayerData",
                                Size = new(3.73f, 1),
                                Padding = new(10,10,5,5),
                                Spacing = 5,
                                ChildsAlignement = TextAnchor.MiddleLeft,
                                Children = {
                                    new MaskableSprite 
                                    {
                                        Identifier = "Player_Avatar",
                                        Size = new(.9f,.9f),
                                        BorderRadius = 25,
                                        Sprite = Resources.Load<Sprite>("Sprites/User/Avatar/"+RpgClass.USER.Values.AvatarUrl),
                                        Color = new(255,255,255,255)
                                    },
                                    new VerticalGrid
                                    {
                                        Identifier = "Player_Usernames",
                                        Size = new(2.75f, .9f),
                                        Spacing = 2,
                                        Padding = new(10,5,5,0),
                                        ChildsAlignement = TextAnchor.UpperLeft,
                                        Children = 
                                        {
                                            new Textable
                                            {
                                                Identifier = "Player_Usernames_Displayname",
                                                Label = RpgClass.USER.Values.DisplayName,
                                                Font = ResourcesManager.COMFORTAA_BOLD,
                                                FontSize = 25,
                                                Size = new(2.6f, .25f)
                                            },
                                            new Textable
                                            {
                                                Identifier = "Player_Usernames_Identifier",
                                                Label = "#" + RpgClass.USER.Values.Identifier,
                                                Font = ResourcesManager.COMFORTAA_REGULAR,
                                                FontSize = 20,
                                                Size = new(2.6f, .2f)
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    },
                    new VerticalGrid
                    {
                        Identifier = "Player_Level",
                        Size = new(3.68f,.9f),
                        Spacing = 2,
                        Padding = new(5,5,12,12),
                        ChildsAlignement = TextAnchor.UpperCenter,
                        Children =
                        {
                            new HorizontalGrid
                            {
                                Identifier = "Player_Level_LevelsExp",
                                Size = new(3.68f, .2f),
                                Spacing = 0,
                                ChildsAlignement = TextAnchor.MiddleCenter,
                                Children = 
                                {
                                    new Textable 
                                    {
                                        Identifier = "Level",
                                        Size = new(1.8f, .2f),
                                        Label = $"Level {RpgClass.USER.Values.Level}", // https://fontawesome.com/icons/angles-up?f=classic&s=solid
                                        Alignement = TextAnchor.MiddleLeft,
                                        Font = ResourcesManager.COMFORTAA_REGULAR,
                                        FontSize = 16,
                                    },
                                    new Textable 
                                    {
                                        Identifier = "Exp",
                                        Size = new(1.8f, .2f),
                                        Label = $"Exp {RpgClass.USER.Values.Exp} / {RpgClass.USER.CalculateExpNextLevel()}", // https://fontawesome.com/icons/sparkles?f=classic&s=solid
                                        Alignement = TextAnchor.MiddleRight,
                                        Font = ResourcesManager.COMFORTAA_REGULAR,
                                        FontSize = 16,
                                    }
                                }
                            },
                            new Spritable
                            {
                                Identifier = "Player_Level_CompletionBar",
                                Size = new(3.68f, .1f),
                                Children = 
                                {
                                    new HorizontalGrid
                                    {
                                        Identifier = "Player_Level_Completion_Background",
                                        Size = new(3.68f, .1f),
                                        Spacing = 0,
                                        ChildsAlignement = TextAnchor.UpperLeft,
                                        Children = 
                                        {
                                            new Spritable 
                                            {
                                                Identifier = "Completion_Background",
                                                Color = new(80,80,80,255),
                                                Size = new(3.68f, .1f),
                                                Sprite = AssetDatabase.GetBuiltinExtraResource<Sprite>("UI/Skin/Background.psd"),
                                            }
                                        }
                                    },
                                    new HorizontalGrid
                                    {
                                        Identifier = "Player_Level_Completion",
                                        Size = new(3.68f, .1f),
                                        Spacing = 0,
                                        ChildsAlignement = TextAnchor.UpperLeft,
                                        Children = 
                                        {
                                            new Spritable 
                                            {
                                                Identifier = "Completion",
                                                Color = new(60,230,120,255),
                                                Size = new(RpgClass.USER.NextLevelAdvancement() * 3.68f < 0.05f ? 0.05f : RpgClass.USER.NextLevelAdvancement() * 3.68f, .1f),
                                                Sprite = AssetDatabase.GetBuiltinExtraResource<Sprite>("UI/Skin/Background.psd"),
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            };
        }

    }
}

using RpgProject.Framework.Resource;
using UnityEngine.Events;

namespace RpgProject.FrameworkV2.Overlays
{
    partial class ExperimentsButtonDouble
    {
        public static DrawableObject Create(string name, string button1, UnityAction action1, string button2, UnityAction action2)
        {
            return new HorizontalGrid
            {
                Identifier = "ExperimentsButtonDouble_Core_AUTO",
                Size = new(13f,.4f),
                BorderRadius = 25,
                Padding = new(5,5,4,4),
                Color = new(60,60,60,255),
                ChildsAlignement = UnityEngine.TextAnchor.MiddleCenter,
                Children = 
                {
                    new Textable
                    {
                        Identifier = "ExperimentTitle_AUTO",
                        Label = name,
                        FontSize = 25,
                        Font = ResourcesManager.COMFORTAA_REGULAR,
                        Color = new(255,255,255,255),
                        Alignement = UnityEngine.TextAnchor.MiddleLeft,
                        Size = new(9.8f, .34f),
                    },
                    new HorizontalGrid
                    {
                        Identifier = "ExperimentsButtonDouble_Buttons_AUTO",
                        Size = new (3,.34f),
                        Spacing = 10,
                        ChildsAlignement = UnityEngine.TextAnchor.MiddleRight,
                        Children =
                        {
                            new Button 
                            {
                                Identifier = "Button_1",
                                Size = new(1.45f, .34f),
                                //Sprite = ResourcesManager.BUTTON_ROUNDED_WHITE_SQUARE,
                                Color = new(50,50,50,255),
                                OnClickActions = action1,
                                Children = 
                                {
                                    new Textable
                                    {
                                        Identifier = "Button_1_Info",
                                        Label = button1,
                                        FontSize = 20,
                                        Font = ResourcesManager.COMFORTAA_REGULAR,
                                        Color = new(255,255,255,255),
                                        Alignement = UnityEngine.TextAnchor.MiddleCenter,
                                        Size = new(1.45f, .34f),
                                    },
                                }
                            },
                            new Button 
                            {
                                Identifier = "Button_2",
                                Size = new(1.45f, .34f),
                                //Sprite = ResourcesManager.BUTTON_ROUNDED_WHITE_SQUARE,
                                Color = new(50,50,50,255),
                                OnClickActions = action2,
                                Children = 
                                {
                                    new Textable
                                    {
                                        Identifier = "Button_2_Info",
                                        Label = button2,
                                        FontSize = 20,
                                        Font = ResourcesManager.COMFORTAA_REGULAR,
                                        Color = new(255,255,255,255),
                                        Alignement = UnityEngine.TextAnchor.MiddleCenter,
                                        Size = new(1.45f, .34f),
                                    },
                                }
                            }
                        }
                    }
                }
            };
        }
    }
}
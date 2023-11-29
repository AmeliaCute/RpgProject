using System.Drawing;
using System.Collections.Generic;
using RpgProject.Framework.Resource;
using RpgProject.FrameworkV2;
using UnityEngine.Events;

namespace RpgProject.FrameworkV2.Overlays
{
    partial class PauseMenuButton
    {
        public static DrawableObject Create(string icon, string description, UnityAction action)
        {
            return new Button
            {
                Identifier = "PauseMenuButton_Core_AUTO",
                Size = new(3.2f, .5f),
                Color = HexColor.convert(RpgClass.SETTINGS.Values.BackgroundColor),
                HoverColor = HexColor.convert(RpgClass.SETTINGS.Values.ButtonColor),
                OnClickActions = action,
                BorderRadius = 25,
                Children = {
                    new HorizontalGrid
                    {
                        Identifier = "ButtonPauseMenu_Core_HorizontalGrid",
                        Size = new(3.2f, .5f),
                        ChildsAlignement = UnityEngine.TextAnchor.MiddleLeft,
                        Spacing = 10,
                        Padding = new(5,3,3,3),
                        Children = {
                            new Textable
                            {
                                Identifier = "ButtonPauseMenu_Core_HorizontalGrid_Icon",
                                Label = icon,
                                Font = ResourcesManager.FONT_AWESOME_SOLID,
                                Alignement = UnityEngine.TextAnchor.MiddleCenter,
                                FontSize = 35, 
                                Size = new (.45f, .45f)
                            },
                            new Textable
                            {
                                Identifier = "ButtonPauseMenu_Core_HorizontalGrid_Description",
                                Label = description,
                                Font = ResourcesManager.COMFORTAA_REGULAR,
                                FontSize = 30,
                                Size = new (2.5f, .45f)
                            }
                        }
                    }
                }
            };
        }
    }
}
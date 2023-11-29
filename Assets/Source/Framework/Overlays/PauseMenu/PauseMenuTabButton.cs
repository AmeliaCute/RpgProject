using RpgProject.Framework.Resource;
using RpgProject.FrameworkV2;
using UnityEngine.Events;

namespace RpgProject.FrameworkV2.Overlays
{
    partial class PauseMenuTabButton
    {
        public static DrawableObject Create(string icon, UnityAction action)
        {
            return new Button
            {
                Identifier = "PauseMenuTabButton_Core_AUTO",
                Size = new(.70f, .70f),
                BorderRadius = 20,
                Color = HexColor.convert(RpgClass.SETTINGS.Values.TabColor),
                HoverColor = HexColor.convert(RpgClass.SETTINGS.Values.TabAltColor),
                OnClickActions = action,
                Children = 
                {
                    new Textable
                    {
                        Identifier = "Icon",
                        Label = icon,
                        Font = ResourcesManager.FONT_AWESOME_SOLID,
                        Alignement = UnityEngine.TextAnchor.MiddleCenter,
                        FontSize = 35,
                        Color = new(0,0,0,255),
                        Size = new(.70f, .70f)
                    }
                }
            };
        }
    }
}
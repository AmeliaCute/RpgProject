using RpgProject.Framework.Resource;
using UnityEngine.Events;

namespace RpgProject.FrameworkV2.Overlays
{
    partial class InventoryItemButton
    {
        public static DrawableObject Create(ItemComponent item, UnityAction action)
        {
            if (item.item.getIcon() == null)
                RpgClass.LOGGER.Error("Sprite is null for item: " + item.item.getName());
            

            return new Button 
            {
                Size = new(.95f,.95f),
                //Sprite = ResourcesManager.BUTTON_ROUNDED_WHITE_SQUARE,
                Color = new(50,50,50,150),
                OnClickActions = action,
                Children = 
                {
                    new Spritable 
                    {
                        Size = new(.7f,.7f),
                        Color = new(255,255,255,255),
                        Sprite = item.item.getIcon(),
                    },
                    new Textable
                    {
                        Alignement = UnityEngine.TextAnchor.LowerRight,
                        Size = new(.8f,.8f),
                        FontSize = 14,
                        Color = new(255,255,255,255),
                        Label = $"{item.quantity}"
                    }
                }
            };
        }
    }
}
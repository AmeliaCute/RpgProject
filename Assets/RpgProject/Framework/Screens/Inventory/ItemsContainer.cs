using System.Collections.Generic;
using RpgProject.Framework.Graphics;
using RpgProject.Framework.Graphics.Overlays;
using RpgProject.Framework.Graphics.Screens;
using RpgProject.Framework.Graphics.Rendering;
using Color = UnityEngine.Color;
using UnityEngine;
using RpgProject.Framework.Resource;

namespace RpgProject.Framework.Screens.Inventory
{
    public class ItemsContainer
    {
        public ItemsContainer(List<ItemComponent> items)
        {
            Drawable.Create(
                "Inventory.Container",
                new VerticalScrollableGrid
                {
                    FadeDuration = 500,
                    Width = 6.8f,
                    Height = 8.5f,
                    Offset = new UnityEngine.Vector2(-3.9f,-0.3f),
                    Color = new UnityEngine.Color32(40,40,40,255),
                    Children = RenderItems(new List<ItemComponent> { 
                        new ItemComponent(Items.DEBUG_ITEM, Items.DEBUG_ITEM.getStackSize()), 
                        new ItemComponent(Items.WOODEN_STICK, 1), 
                        new ItemComponent(Items.DEBUG_SWORD, 1)

                    })
                }
            );

            Drawable.Create(
                DrawableType.Foreground,
                ItemHotBar.Menu
            );
        }

        public List<Drawable> RenderItems(List<ItemComponent> items)
        {
            List<Drawable> Children = new List<Drawable>() { new Container { Width = 0.1f, Height = 0.3f, Color = Color.clear } };
            for (int i = 0; i < Mathf.Ceil(items.Count / 7f)+0.1f; ++i)
            {
                List<Drawable> row = new List<Drawable>();
                for (int j = 0; j < 6; ++j)
                {
                    int index = i * 6 + j;
                    if (index < items.Count && items[index] != null)
                    {
                        row.Add(
                            new BorderRoundedButton
                            {
                                Size = new UnityEngine.Vector2(1f, 1f),
                                Color = new Color(0.1f,0.1f,0.1f),
                                Action = new InventorySelector(items[index]),
                                Children = 
                                {
                                    // Glowing effect 
                                    new Image { Sprite = ResourcesManager.GLOW_TEXTURE_ALT, Color = items[index].getItem().getRarityColor(), Size = 1f },
                                    new Image {  Sprite = items[index].getItem().getIcon(), Color = Color.white, Size = 0.75f },
                                    new Text { Label = items[index].getQuantity().ToString(), TextAnchor = TextAnchor.MiddleLeft, Offset = new UnityEngine.Vector2(0, -0.35f), Color = Color.white, LabelSize = 20 }
                                }
                            }
                        );
                    }
                }

                Children.Add(
                    new HorizontalGrid
                    {
                        Gap = 0.2f,
                        Color = new UnityEngine.Color32(40, 40, 40, 255),
                        Width = 6f,
                        Height = 1.05f,
                        Children = row
                    }
                );
            }

            return Children;
        }
    }
}
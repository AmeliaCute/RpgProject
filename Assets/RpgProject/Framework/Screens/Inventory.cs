using System.Drawing;
using RpgProject.Framework.Graphics.Overlays;
using RpgProject.Framework.Graphics;
using Color = UnityEngine.Color;
using RpgProject.Framework.Graphics.Screens;
using RpgProject.Framework.Graphics.Rendering;
using RpgProject.Framework.Screens.Inventory;
using RpgProject.Objects;
using System.Collections.Generic;
using UnityEngine;

namespace RpgProject.Framework.Graphics.Screens
{
    public class InventoryMenu
    {
        public static ItemComponent selected;
        public InventoryMenu()
        {
            Drawable.Create(
                DrawableType.Background,
                new Container
                {
                    Width = 16f,
                    Height = 9f,
                    Color = new UnityEngine.Color32(0,0,0, 210),
                }
            );
            Drawable.Create(
                "Inventory.Container",
                new VerticalScrollableGrid
                {
                    Width = 6.8f,
                    Height = 8.5f,
                    Offset = new UnityEngine.Vector2(-3.9f,-0.3f),
                    Color = new UnityEngine.Color32(40,40,40,255),
                    Children = RenderItems(new List<ItemComponent> { new ItemComponent(Items.DEBUG_ITEM, Items.DEBUG_ITEM.getStackSize()), new ItemComponent(Items.DEBUG_ITEM, 3), new ItemComponent(Items.WOODEN_STICK, 1), new ItemComponent(Items.WOODEN_STICK, 1), new ItemComponent(Items.WOODEN_STICK, 1), new ItemComponent(Items.WOODEN_STICK, 1), new ItemComponent(Items.WOODEN_STICK, 1), new ItemComponent(Items.WOODEN_STICK, 1), new ItemComponent(Items.WOODEN_STICK, 1), new ItemComponent(Items.WOODEN_STICK, 1), new ItemComponent(Items.WOODEN_STICK, 5), new ItemComponent(Items.WOODEN_STICK, 1), new ItemComponent(Items.WOODEN_STICK, 1), new ItemComponent(Items.WOODEN_STICK, 1)})
                }
            );

            Drawable.Create(
                DrawableType.Foreground,
                ItemHotBar.Menu
            );
        }

        public static void Selector(ItemComponent item)
        {
            selected = item;
            RpgClass.RPGLOGGER.Warning("Selected: " + selected.getItem().getName() + "./" + selected.quantity);
            Drawable.Clear("Inventory.Selector.Container");
            Drawable.Create(
                "Inventory.Selector.Container",
                new Container
                {
                    Width = 6f,
                    Height = 1.5f,
                    Offset = new UnityEngine.Vector2(4.8f, -3.5f),
                    Color = new UnityEngine.Color32(40,40,40,235),
                    Border = true,
                    Children = 
                    {
                        new HorizontalGrid{
                            Color = Color.clear,
                            Width = 6f,
                            Height = 1.5f,
                            Children = 
                            {
                                new Container { Width = 0.25f, Height = 0.3f, Color = Color.clear }, // Empty space
                                new Container
                                {
                                    Color = Color.clear,
                                    Width = 1f,
                                    Height = 1f,
                                    Children = 
                                    {
                                        new Image {  Sprite = item.getItem().getIcon(), Color = Color.white, Size = 0.1f },
                                        new Text { Label = item.getQuantity().ToString(), Offset = new UnityEngine.Vector2(-0.5f, -0.5f), Color = Color.white, LabelSize = 20 }
                                    }
                                },
                                new Container { Width = 0.25f, Height = 0.3f, Color = Color.clear }, // Empty space
                                new VerticalGrid{
                                    Color = Color.clear,
                                    Width = 5f,
                                    Height = 0.5f,
                                    Gap = 0.1f,
                                    Children =
                                    {
                                        new Text { Label = item.getItem().getName(), TextAnchor = TextAnchor.MiddleLeft, Color = Color.white, LabelSize = 25 },
                                        new VerticalScrollableGrid {
                                            Color = new Color32(0,0,0,1),
                                            Width = 5f,
                                            Height = 0.7f,
                                            Children = 
                                            {
                                                new Container { Width = 0.35f, Height = 0.1f, Color = Color.clear }, // Empty space
                                                // TODO STATES
                                                new Text { Label = item.getItem().getDescription(), TextAnchor = TextAnchor.MiddleLeft, Color = Color.white, LabelSize = 20 },
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
                                    new Image {  Sprite = items[index].getItem().getIcon(), Color = Color.white, Size = 0.10f },
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

public class InventorySelector : Action
{
    private ItemComponent x;
    public InventorySelector(ItemComponent x)
    {
        this.x = x;
    }
    public override void Start()
    {
        throw new System.NotImplementedException();
    }

    public override void OnMouseEnter()
    {
        base.OnMouseEnter();
        InventoryMenu.Selector(x);
    }
}
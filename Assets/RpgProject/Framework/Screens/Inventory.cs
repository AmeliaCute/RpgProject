using RpgProject.Framework.Graphics.Overlays;
using Color = UnityEngine.Color;
using RpgProject.Framework.Graphics.Screens;
using RpgProject.Framework.Graphics.Rendering;
using RpgProject.Framework.Screens.Inventory;
using System.Collections.Generic;
using UnityEngine;
using RpgProject.Framework.Resource;
using RpgProject.Objects;
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

        /// <summary>
        /// This function creates a graphical user interface for selecting an item in an inventory.
        /// </summary>
        public static void Selector(ItemComponent item)
        {
            if (selected == item) return;
            selected = item;
            RpgClass.LOGGER.Warning("Selected: " + selected.getItem().getName() + "./" + selected.quantity);
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
                                new Container { Width = 0.05f, Height = 1.5f, Color = item.getItem().getRarityColor() },
                                
                                // Spacing 
                                new Container { Width = 0.25f, Height = 0.2f, Color = Color.clear },

                                new Container
                                {
                                    Color = Color.clear,
                                    Width = 1f,
                                    Height = 1f,
                                    Children = 
                                    {
                                        new Image {  Sprite = item.getItem().getIcon(), Color = Color.white, Size = 0.95f },
                                        new Text { Label = item.getQuantity().ToString(), Offset = new UnityEngine.Vector2(-0.5f, -0.5f), Color = Color.white, LabelSize = 20 }
                                    }
                                },

                                // Spacing
                                new Container { Width = 0.25f, Height = 0.3f, Color = Color.clear },

                                new VerticalGrid
                                {
                                    Color = Color.clear,
                                    Width = 4.75f,
                                    Height = 0.5f,
                                    Gap = 0.1f,
                                    Children =
                                    {
                                        new Text { Label = item.getItem().getName(), TextAnchor = TextAnchor.MiddleLeft, Color = Color.white, LabelSize = 25 },
                                        new VerticalScrollableGrid {
                                            Color = new Color32(0,0,0,1),
                                            Width = 4.75f,
                                            Height = 0.5f,
                                            Children = 
                                            {
                                                // Spacing
                                                new Container { Width = 0.35f, Height = 0.1f, Color = Color.clear },
                                                
                                                RenderSelectorStates(),

                                                // Spacing
                                                new Container { Width = 0.35f, Height = 0.1f, Color = Color.clear }, 

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

        public static Drawable RenderSelectorStates()
        {
            var Children = new Container { Width = 4.75f, Height = 0.15f, Color = Color.clear };
            //Basic states:
            var SelectedStates = new List<Drawable>();

            Children.Children.Add(
                new HorizontalScrollableGrid 
                { 
                    Width = 4.75f, Height = 0.15f, Color = new Color32(0,0,0,1), Gap = 0.08f, Children = CheckSelectorStates()
                }
            );

            return Children;
        }

        /// <summary>
        /// The function returns a list of Drawable objects based on the state of a selected item, with
        /// different states displayed depending on the type of item.
        /// </summary>
        public static List<Drawable> CheckSelectorStates()
        {
            var Children = new List<Drawable>();

            Children.Add( new Container { Width = 0.335f, Height = 0.15f, Color = Color.clear } ); // Add a space at the begin of the grid
            
            Children.Add(State("", selected.getItem().getRarityColor(), selected.getItem().getRarity().ToString())); // Can be delete cause something else is used to show rarity
            Children.Add(State("", Color.white, selected.getItem().getPrice().ToString()));

            switch(selected.getItem().type)
            {   
                case "weapon":
                    var _we_item = (Weapon) selected.getItem();
                    Children.Add(State("", new Color32(255,56,59,255),_we_item.getDamage().ToString()));
                    Children.Add(State("", Color.white,_we_item.getReloadTime().ToString()+"s"));
                    break;
                case "armor":
                    var _ar_item = (Armor) selected.getItem();
                    Children.Add(State("", Color.white,_ar_item.getSlot().ToString()));
                    Children.Add(State("", new Color32(168,56,59,255),_ar_item.getMagicResistance().ToString()));
                    Children.Add(State("", new Color32(255,56,59,255),_ar_item.getPhysiqueResistance().ToString()));
                    break; 
            }


            return Children;
        }

        public static Drawable State(string icon, Color32 color, string state)
        {
            return new HorizontalGrid 
            { 
                Width = 0.8f, Height = 0.15f, Color = Color.clear, Gap = 0.2f,
                Children = 
                {
                    new Text { Label = icon, TextAnchor = TextAnchor.MiddleLeft, Color = color, LabelSize = 15, LabelFont = ResourcesManager.FONT_AWESOME_SOLID},
                    new Text { Label = state.ToLower(), TextAnchor = TextAnchor.MiddleLeft, Color = color, LabelSize = 15}
                }
            };
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
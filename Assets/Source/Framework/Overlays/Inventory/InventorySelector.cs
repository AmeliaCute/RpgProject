using RpgProject.Framework.Resource;
using RpgProject.FrameworkV2;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace RpgProject.FrameworkV2.Overlays
{

    partial class InventoryItemSelector : DrawableObject
    {
        public ItemComponent Item { get; set; } = null;

        private VerticalGrid DataDetails { get; set; } = null;
        private Textable DataHeader { get; set; } = null;

        public override GameObject Create()
        {
            Object = new();
            Attach(
                new HorizontalGrid
                {
                    Identifier = "InventorySelector_Container",
                    Size = new(5f, 8),
                    Position = this.Position,
                    Spacing = -40,
                    Children = 
                    {
                        InitDataContainer(),
                        new VerticalGrid
                        {
                            Identifier = "InventorySelector_Categories",
                            Size = new(.7f,8),
                            BorderRadius = 50,
                            Color = new(255,255,255,255)
                        }
                    }
                }
            );

            UpdateHeader(Item?.getItem().getName());
            UpdateDetails(Item);

            return Object;
        }

        private VerticalGrid InitDataContainer()
        {
            DataHeader = new Textable { Identifier = "Data_Header", Alignement = TextAnchor.MiddleLeft, Size = new(3.8f, .3f), Color = new(255,255,255,255), Label = "Oops", FontSize = 30, };
            DataDetails = new VerticalGrid { Identifier = "Data_Details", Size = new(3.8f, 7.25f), Spacing = 10, ChildsAlignement = TextAnchor.MiddleCenter, Children =  {
                new Spritable { Identifier = "Data_OopsiStickerFun", Size = new(1.5f,1.5f), Color = new(255,255,255,255), Sprite = ResourcesManager.STICKERS_CG_THINKING }, 
                new Textable { Identifier = "Data_OopsiDetails", Alignement = TextAnchor.MiddleCenter, Size = new(3.8f, .5f), Color = new(180,180,180,255), Label = "No item :c", FontSize = 50 }
            }};

            return new VerticalGrid
            {
                Identifier = "Data_Container",
                Size = new(4.3f, 8),
                Padding = new(20,50,20,20),
                BorderRadius = 50,
                Color = new(5,5,5,255),
                Children = 
                {
                    DataHeader,
                    DataDetails,
                }
            };
        }

        public void UpdateHeader(string newText)
        {
            if(newText != null)
                DataHeader?.UpdateLabel(newText);
            else 
                RpgClass.LOGGER.Error("UpdateHeader <- InventorySelector: string is null.");
        }

        public void UpdateDetails(ItemComponent newItem)
        {
            if(newItem != null)
            {
                foreach(DrawableObject child in DataDetails.Children)
                    child?.End();

                Attach(
                    new HorizontalGrid
                    {
                        Identifier = "Data_SubHeader",
                        Size = new(3.8f, 1.9f),
                        ChildsAlignement = TextAnchor.MiddleCenter,
                        Children = 
                        {
                            new Spritable
                            {
                                Identifier = "Item_Sprite",
                                Size = new(1.9f,1.9f),
                                Sprite = newItem.getItem().getIcon(),
                                Color = new(255,255,255,255)
                            },
                            new Scrollable
                            {
                                Identifier = "Item_Attributs",
                                Size = new(1.9f,1.9f),
                            }
                        }
                    }
                );
            }
            else 
                RpgClass.LOGGER.Error("UpdateDetails <- InventorySelector: ItemComponent is null.");
        }
    }
}
using System.IO;
using System.Collections.Generic;
using RpgProject.Framework.Resource;
using System;
using UnityEngine;
using System.Linq;
using RpgProject.Game.Structure;
namespace RpgProject.Game.Data
{
    public class Inventory : DataStructure
    {
        public InventoryData Values;

        public Inventory(string saveDir, string saveName)
        {
            LOCAL_SAVE_DIR = !string.IsNullOrEmpty(saveDir) ? saveDir : Path.Combine(Application.persistentDataPath, "Local/save");
            LOCAL_SAVE_NAME = !string.IsNullOrEmpty(saveName) ? saveName : "data_1.bin";
            Values = new InventoryData();

            Initialize();
        }

        public void Initialize()
        {
            InventoryData inventory = new();

            try
            {
                inventory = Binaries.Read<InventoryData>(Path.Combine(LOCAL_SAVE_DIR,LOCAL_SAVE_NAME));
            }
            catch 
            {
                if(!Directory.Exists(Path.Combine(LOCAL_SAVE_DIR)))
                    Directory.CreateDirectory(Path.Combine(LOCAL_SAVE_DIR));
                File.Create(Path.Combine(LOCAL_SAVE_DIR, LOCAL_SAVE_NAME)).Close();
            }

            // INITALIZING VALUES
            Values.Capacity = Load(inventory.Capacity, 50);
            Values.Money = Load(inventory.Money, 100);
            Values.Items = Load(inventory.Items, 
                new List<ItemComponent>()
                {
                    new ItemComponent(Items.DEBUG_SWORD, 1),
                    new ItemComponent(Items.DEBUG_ITEM, 128),
                    new ItemComponent(Items.DEBUG_ITEM, 128),
                    new ItemComponent(Items.DEBUG_ITEM, 128),
                    new ItemComponent(Items.DEBUG_ITEM, 128),
                    new ItemComponent(Items.DEBUG_ITEM, 128),
                    new ItemComponent(Items.DEBUG_ITEM, 128),
                    new ItemComponent(Items.DEBUG_ITEM, 128),
                    new ItemComponent(Items.DEBUG_ITEM, 128),
                    new ItemComponent(Items.DEBUG_ITEM, 128),
                    new ItemComponent(Items.DEBUG_ITEM, 128),
                    new ItemComponent(Items.DEBUG_ITEM, 128),
                    new ItemComponent(Items.DEBUG_ITEM, 128),
                    new ItemComponent(Items.DEBUG_ITEM, 128),
                    new ItemComponent(Items.DEBUG_ITEM, 128),
                    new ItemComponent(Items.DEBUG_ITEM, 128),
                    new ItemComponent(Items.DEBUG_ITEM, 128),
                    new ItemComponent(Items.DEBUG_ITEM, 128),
                    new ItemComponent(Items.DEBUG_ITEM, 128),
                    new ItemComponent(Items.DEBUG_ITEM, 128),
                    new ItemComponent(Items.DEBUG_ITEM, 128),
                }
            );

            Save(Values);
        }
        public void AddMoney(long x)
        {
            Values.Money += x;
        }

        public void RemoveMoney(long x)
        {
            Values.Money -= Values.Money - x < 0 ? Values.Money : x;
        }

        //! probably need a rework
        public bool AddItem(ItemComponent item)
        {
            if(Values.Items.Find(o => o.item.getName().Equals(item.item.getName())) == null && Values.Capacity > Values.Items.Count)
            {  
                Values.Items.Add(item);
                return true;
            }

            for(int i = 0; i < Values.Items.Count; ++i)
            {
                if (Values.Items[i].item == item.item && Values.Items[i].quantity <= Values.Items[i].item.stackSize - item.quantity)
                {
                    Values.Items[i].addQuantity(item.quantity);
                    return true;
                }
            }

            return false;
        }

        public bool RemoveItem(ItemComponent itemToRemove, int quantityToRemove)
        {
            ItemComponent existingItem = Values.Items.FirstOrDefault(o => o.item.getName().Equals(itemToRemove.item.getName()));

            if (existingItem != null)
            {
                if (existingItem.quantity >= quantityToRemove)
                {
                    existingItem.quantity -= quantityToRemove;

                    if (existingItem.quantity == 0)
                        Values.Items.Remove(existingItem);

                    return true;
                }
            }

            return false;
        }

    }

    [Serializable]
    public class InventoryData
    {
        // Indicate the capacity of the inventory
        public int Capacity;

        public long Money;
        public List<ItemComponent> Items;
    }
}
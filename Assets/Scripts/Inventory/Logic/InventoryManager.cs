using System.Collections.Generic;
using UnityEngine;
using Scripts.Inventory.Data;
using Scripts.Utilities;

namespace Scripts.Inventory.Logic
{
    /// <summary>
    /// 背包数据管理类
    /// </summary>
    public class InventoryManager : Singleton<InventoryManager>
    {
        [SerializeField] private ItemDataList_SO itemData;
        [SerializeField]
        private List<ItemName> itemList = new List<ItemName>();

        private void OnEnable()
        {
            EventHandler.ItemUsedEvent += OnItemUsedEvent;
            EventHandler.ChangeItemEvent += OnChangeItemEvent;
            EventHandler.AfterSceneUnloadEvent += OnAfterSceneUnloadEvent;
            EventHandler.StartNewGameEvent += OnStartNewGameEvent;
        }

        private void OnDisable()
        {
            EventHandler.ItemUsedEvent -= OnItemUsedEvent;
            EventHandler.ChangeItemEvent -= OnChangeItemEvent;
            EventHandler.AfterSceneUnloadEvent -= OnAfterSceneUnloadEvent;
            EventHandler.StartNewGameEvent -= OnStartNewGameEvent;
        }

        private void OnItemUsedEvent(ItemName itemName)
        {
            var index = GetItemIndex(itemName);
            itemList.RemoveAt(index);

            // TODO:单一使用
            if (itemList.Count == 0)
            {
                EventHandler.CallUpdateUIEvent(null, -1);
            }
            //else
            //{
            //    EventHandler.CallUpdateUIEvent(null, -1);
            //}
        }

        private void OnChangeItemEvent(int index)
        {
            if (index >= 0 && index < itemList.Count)
            {
                ItemDetails item = itemData.GetItemDetails(itemList[index]);
                EventHandler.CallUpdateUIEvent(item,index);
            }
        }

        private void OnAfterSceneUnloadEvent()
        {
            if (itemList.Count == 0)
            {
                EventHandler.CallUpdateUIEvent(null, -1);
            }
            else
            {
                for (int i = 0; i < itemList.Count; i++)
                {
                    EventHandler.CallUpdateUIEvent(itemData.GetItemDetails(itemList[i]), i);
                }
            }
        }

        private void OnStartNewGameEvent(int gameWeek)
        {
            itemList.Clear();
        }

        public void AddItem(ItemName itemName)
        {
            if (!itemList.Contains(itemName))
            {
                itemList.Add(itemName);

                // UI显示
                EventHandler.CallUpdateUIEvent(itemData.GetItemDetails(itemName), itemList.Count - 1);
            }
        }

        private int GetItemIndex(ItemName itemName)
        {
            for (int i = 0; i < itemList.Count; i++)
            {
                if (itemList[i] == itemName)
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
using System.Collections.Generic;
using Scripts.Inventory.Data;
using Scripts.Inventory.Logic;
using Scripts.Utilities;

namespace Scripts.Manager
{
    /// <summary>
    /// 对象管理类
    /// 主要负责控制场景切换时候场景内物品的状态以及UI的状态
    /// </summary>
    public class ObjectManager : Singleton<ObjectManager>
    {
        /// <summary>
        /// 物品名称
        /// </summary>
        public Dictionary<ItemName,bool> itemAvailableDict = new Dictionary<ItemName, bool>();
        /// <summary>
        /// 物品状态
        /// </summary>
        public Dictionary<string,bool> interactiveStateDict = new Dictionary<string, bool>();

        private void OnEnable()
        {
            EventHandler.BeforeSceneUnloadEvent += OnBeforeSceneUnloadEvent;
            EventHandler.AfterSceneUnloadEvent += OnAfterSceneUnloadEvent;
            EventHandler.UpdateUIEvent += OnUpdateUIEvent;
            EventHandler.StartNewGameEvent += OnStartNewGameEvent;
        }

        private void OnDisable()
        {
            EventHandler.BeforeSceneUnloadEvent -= OnBeforeSceneUnloadEvent;
            EventHandler.AfterSceneUnloadEvent -= OnAfterSceneUnloadEvent;
            EventHandler.UpdateUIEvent -= OnUpdateUIEvent;
            EventHandler.StartNewGameEvent -= OnStartNewGameEvent;
        }

        private void OnBeforeSceneUnloadEvent()
        {
            foreach (var item in FindObjectsOfType<Item>())
            {
                if (!itemAvailableDict.ContainsKey(item.itemName))
                {
                    itemAvailableDict.Add(item.itemName, true);
                }
            }

            foreach (var item in FindObjectsOfType<Interactive.Interactive>())
            {
                if (interactiveStateDict.ContainsKey(item.name))
                {
                    interactiveStateDict[item.name] = item.isDone;
                }
                else
                {
                    interactiveStateDict.Add(item.name, item.isDone);
                }
            }
        }

        private void OnAfterSceneUnloadEvent()
        {
            foreach (var item in FindObjectsOfType<Item>())
            {
                if (!itemAvailableDict.ContainsKey(item.itemName))
                {
                    itemAvailableDict.Add(item.itemName, true);
                }
                else
                {
                    item.gameObject.SetActive(itemAvailableDict[item.itemName]);
                }
            }

            foreach (var item in FindObjectsOfType<Interactive.Interactive>())
            {
                if (interactiveStateDict.ContainsKey(item.name))
                {
                    item.isDone = interactiveStateDict[item.name];
                }
                else
                {
                    interactiveStateDict.Add(item.name, item.isDone);
                }
            }
        }

        /// <summary>
        /// 拾取物品时更新
        /// </summary>
        /// <param name="itemDetails"></param>
        /// <param name="arg2"></param>
        private void OnUpdateUIEvent(ItemDetails itemDetails, int arg2)
        {
            if (itemDetails != null)
            {
                itemAvailableDict[itemDetails.itemName] = false;
            }
        }

        private void OnStartNewGameEvent(int gameWeek)
        {
            itemAvailableDict.Clear();
            interactiveStateDict.Clear();
        }
    }
}
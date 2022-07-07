using System.Collections.Generic;
using Scripts.Utilities;
using UnityEngine;

namespace Scripts.Inventory.Data
{
    /// <summary>
    /// 道具信息详情
    /// </summary>
    [CreateAssetMenu(fileName = "ItemDataList_SO", menuName = "Inventory/ItemDataList_SO")]
    public class ItemDataList_SO : ScriptableObject
    {
        public List<ItemDetails> itemDetailsesList;

        public ItemDetails GetItemDetails(ItemName itemName)
        {
            return itemDetailsesList.Find(i => i.itemName == itemName);
        }
    }

    /// <summary>
    /// 详情内容（类）
    /// </summary>
    [System.Serializable]
    public class ItemDetails
    {
        public ItemName itemName;
        public Sprite itemSprite;
        //public string 
    }
}
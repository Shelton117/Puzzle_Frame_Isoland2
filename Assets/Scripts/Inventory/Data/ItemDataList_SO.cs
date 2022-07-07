using System.Collections.Generic;
using Scripts.Utilities;
using UnityEngine;

namespace Scripts.Inventory.Data
{
    /// <summary>
    /// ������Ϣ����
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
    /// �������ݣ��ࣩ
    /// </summary>
    [System.Serializable]
    public class ItemDetails
    {
        public ItemName itemName;
        public Sprite itemSprite;
        //public string 
    }
}
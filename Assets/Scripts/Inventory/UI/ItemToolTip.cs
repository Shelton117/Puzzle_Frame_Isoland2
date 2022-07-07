using Scripts.Utilities;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts.Inventory.UI
{
    /// <summary>
    /// 物品栏tip逻辑
    /// </summary>
    public class ItemToolTip : MonoBehaviour
    {
        [SerializeField] private Text itemNameText;

        public void UpdateItemName(ItemName itemName)
        {
            switch (itemName)
            {
                case ItemName.Key:
                    itemNameText.text = "信箱钥匙";
                    break;
                case ItemName.Ticket:
                    itemNameText.text = "一张船票";
                    break;
                default:
                    itemNameText.text = "";
                    break;
            }

            //itemNameText.text = itemName switch
            //{
            //    ItemName.Key => "信箱钥匙",
            //    ItemName.Ticket => "一张船票",
            //    _ => ""
            //};
        }
    }
}
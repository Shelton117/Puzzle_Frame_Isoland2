using Scripts.Utilities;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts.Inventory.UI
{
    /// <summary>
    /// ��Ʒ��tip�߼�
    /// </summary>
    public class ItemToolTip : MonoBehaviour
    {
        [SerializeField] private Text itemNameText;

        public void UpdateItemName(ItemName itemName)
        {
            switch (itemName)
            {
                case ItemName.Key:
                    itemNameText.text = "����Կ��";
                    break;
                case ItemName.Ticket:
                    itemNameText.text = "һ�Ŵ�Ʊ";
                    break;
                default:
                    itemNameText.text = "";
                    break;
            }

            //itemNameText.text = itemName switch
            //{
            //    ItemName.Key => "����Կ��",
            //    ItemName.Ticket => "һ�Ŵ�Ʊ",
            //    _ => ""
            //};
        }
    }
}
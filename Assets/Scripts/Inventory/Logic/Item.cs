using Scripts.Utilities;
using UnityEngine;

namespace Scripts.Inventory.Logic
{
    /// <summary>
    /// ��Ʒ��
    /// ���յ���¼����ڳ���������
    /// </summary>
    public class Item : MonoBehaviour
    {
        public ItemName itemName;

        public void ItemClicked()
        {
            // ���뱳����������Ʒ
            InventoryManager.Instance.AddItem(itemName);

            gameObject.SetActive(false);
        }
    }
}
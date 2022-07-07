using Scripts.Utilities;
using UnityEngine;

namespace Scripts.Inventory.Logic
{
    /// <summary>
    /// 物品类
    /// 接收点击事件并在场景中隐藏
    /// </summary>
    public class Item : MonoBehaviour
    {
        public ItemName itemName;

        public void ItemClicked()
        {
            // 进入背包后隐藏物品
            InventoryManager.Instance.AddItem(itemName);

            gameObject.SetActive(false);
        }
    }
}
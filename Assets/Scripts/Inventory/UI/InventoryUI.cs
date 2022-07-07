using Scripts.Inventory.Data;
using Scripts.Utilities;
using UnityEngine;
using UnityEngine.UI;

namespace Inventory.UI
{
    /// <summary>
    /// 物品栏UI逻辑
    /// </summary>
    public class InventoryUI : MonoBehaviour
    {
        [SerializeField] private Button leftButton;
        [SerializeField] private Button rightButton;
        [SerializeField] private SlotUI slotUI;

        /// <summary>
        /// 当前物品的序号
        /// </summary>
        [SerializeField] private int currentIndex;

        private void OnEnable()
        {
            EventHandler.UpdateUIEvent += OnUpdateUIEvent;
        }

        private void OnDisable()
        {
            EventHandler.UpdateUIEvent -= OnUpdateUIEvent;
        }

        /// <summary>
        /// 更新UI信息
        /// </summary>
        /// <param name="itemDetails">物品详情</param>
        /// <param name="index">背包中的位置</param>
        private void OnUpdateUIEvent(ItemDetails itemDetails, int index)
        {
            if (itemDetails == null)
            {
                slotUI.SetEmpty();
                currentIndex = -1;

                leftButton.interactable = false;
                rightButton.interactable = false;
            }
            else
            {
                currentIndex = index;
                slotUI.SetItem(itemDetails);

                if (index > 0)
                {
                    leftButton.interactable = true;
                }

                if (index == -1)
                {
                    leftButton.interactable = false;
                    rightButton.interactable = false;
                }
            }
        }

        /// <summary>
        /// 左右按钮事件
        /// </summary>
        /// <param name="amount"></param>
        public void SwitchItem(int amount)
        {
            var index = currentIndex + amount;

            if (index < currentIndex)
            {
                leftButton.interactable = false;
                rightButton.interactable = true;
            }
            else if (index > currentIndex)
            {
                leftButton.interactable = true;
                rightButton.interactable = false;
            }
            else
            {
                leftButton.interactable = true;
                rightButton.interactable = true;
            }

            EventHandler.CallChangeItemEvent(index);
        }
    }
}
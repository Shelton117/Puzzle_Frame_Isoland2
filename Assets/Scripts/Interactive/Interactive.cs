using Scripts.Utilities;
using UnityEngine;

namespace Scripts.Interactive
{
    /// <summary>
    /// 互动基类
    /// </summary>
    public class Interactive : MonoBehaviour
    {
        [SerializeField] protected ItemName requireItem;

        public bool isDone;

        public void CheckItem(ItemName itemName)
        {
            if (itemName == requireItem && !isDone)
            {
                isDone = true;

                // 使用物品
                OnClickAction();
                EventHandler.CallItemUsedEvent(itemName);
            }
        }

        /// <summary>
        /// 默认是正确的物品
        /// </summary>
        protected virtual void OnClickAction()
        {

        }

        /// <summary>
        /// 没有物体时发生互动调用的函数
        /// </summary>
        public virtual void EmptyClicked()
        {
            Debug.Log("Empty");
        }
    }
}


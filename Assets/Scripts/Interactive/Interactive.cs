using Scripts.Utilities;
using UnityEngine;

namespace Scripts.Interactive
{
    /// <summary>
    /// ��������
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

                // ʹ����Ʒ
                OnClickAction();
                EventHandler.CallItemUsedEvent(itemName);
            }
        }

        /// <summary>
        /// Ĭ������ȷ����Ʒ
        /// </summary>
        protected virtual void OnClickAction()
        {

        }

        /// <summary>
        /// û������ʱ�����������õĺ���
        /// </summary>
        public virtual void EmptyClicked()
        {
            Debug.Log("Empty");
        }
    }
}


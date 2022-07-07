using Scripts.Inventory.Data;
using Scripts.Inventory.UI;
using Scripts.Utilities;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace Inventory.UI
{
    /// <summary>
    /// µÀ¾ßÀ¸Âß¼­
    /// </summary>
    public class SlotUI : MonoBehaviour,IPointerClickHandler,IPointerEnterHandler,IPointerExitHandler
    {
        [SerializeField] private Image itemImage;
        [SerializeField] private ItemToolTip itemToolTip;
        private ItemDetails currentItem;
        private bool isSelect;

        public void SetItem(ItemDetails itemDetails)
        {
            currentItem = itemDetails;

            gameObject.SetActive(true);

            itemImage.sprite = currentItem.itemSprite;
            itemImage.SetNativeSize();
        }

        public void SetEmpty()
        {
            gameObject.SetActive(false);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            itemToolTip.gameObject.SetActive(false);
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (gameObject.activeInHierarchy)
            {
                itemToolTip.gameObject.SetActive(true);
                itemToolTip.UpdateItemName(currentItem.itemName);
            }
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            isSelect = !isSelect;
            EventHandler.CallItemSelectEvent(currentItem, isSelect);
        }
    }
}

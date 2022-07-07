using Scripts.Inventory.Data;
using Scripts.Inventory.Logic;
using Scripts.Transition;
using Scripts.Utilities;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Scripts.Cursor
{
    /// <summary>
    /// 点击相关manager
    /// </summary>
    public class CursorManager : Singleton<CursorManager>
    {
        private Vector3 mouseWorldPos => Camera.main.ScreenToWorldPoint(
            new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));

        [SerializeField] private RectTransform Hand;

        private ItemName currentItem;
        private bool canClick;
        private bool holdItem;

        private void Update()
        {
            canClick = ObjectAtMousePos();

            if (Hand.gameObject.activeInHierarchy)
            {
                Hand.position = Input.mousePosition;
            }

            if (InteractWithUI()) return;

            if (canClick && Input.GetMouseButtonDown(0))
            {
                // 检测鼠标互动情况
                ClickAction(ObjectAtMousePos().gameObject);
            }
        }

        private void OnEnable()
        {
            EventHandler.ItemSelectEvent += OnItemSelectEvent;
            EventHandler.ItemUsedEvent += OnItemUsedEvent;
        }

        private void OnDisable()
        {
            EventHandler.ItemSelectEvent -= OnItemSelectEvent;
            EventHandler.ItemUsedEvent -= OnItemUsedEvent;
        }

        /// <summary>
        /// 检测鼠标点击范围内的碰撞体
        /// </summary>
        /// <returns></returns>
        private Collider2D ObjectAtMousePos()
        {
            return Physics2D.OverlapPoint(mouseWorldPos);
        }

        private void OnItemSelectEvent(ItemDetails itemDetails, bool isSelected)
        {
            holdItem = isSelected;

            if (isSelected)
            {
                currentItem = itemDetails.itemName;
            }

            Hand.gameObject.SetActive(isSelected);
        }

        private void OnItemUsedEvent(ItemName itemName)
        {
            currentItem = ItemName.None;
            holdItem = false;
            Hand.gameObject.SetActive(false);
        }

        private void ClickAction(GameObject clickGameObject)
        {
            switch (clickGameObject.tag)
            {
                case "Teleport":
                    var teleport = clickGameObject.GetComponent<Teleport>();
                    teleport?.Teleport_2_Scene();
                    break;
                case "Item":
                    var item = clickGameObject.GetComponent<Item>();
                    item?.ItemClicked();
                    break;
                case "Interactive":
                    var interactive = clickGameObject.GetComponent<Interactive.Interactive>();
                    if (holdItem)
                    {
                        interactive?.CheckItem(currentItem);
                    }
                    else
                    {
                        interactive?.EmptyClicked();
                    }
                    break;
            }
        }

        private bool InteractWithUI()
        {
            if (EventSystem.current != null && EventSystem.current.IsPointerOverGameObject())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

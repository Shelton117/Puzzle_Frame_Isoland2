using Scripts.Utilities;
using UnityEngine;

namespace Scripts.Interactive
{
    /// <summary>
    /// 可互动物品——邮箱
    /// </summary>
    public class MailBox : Interactive
    {
        private SpriteRenderer spriteRenderer;
        private BoxCollider2D coll;

        [SerializeField] private Sprite openSprite;

        private void Awake()
        {
            spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
            coll = gameObject.GetComponent<BoxCollider2D>();
        }

        private void OnEnable()
        {
            EventHandler.AfterSceneUnloadEvent += OnAfterSceneUnloadEvent;
        }

        private void OnDisable()
        {
            EventHandler.AfterSceneUnloadEvent -= OnAfterSceneUnloadEvent;
        }

        private void OnAfterSceneUnloadEvent()
        {
            if (isDone)
            {
                spriteRenderer.sprite = openSprite;
                coll.enabled = false;
            }
            else
            {
                transform.GetChild(0).gameObject.SetActive(false);
            }
        }

        protected override void OnClickAction()
        {
            spriteRenderer.sprite = openSprite;
            transform.GetChild(0).gameObject.SetActive(true);
        }
    }
}
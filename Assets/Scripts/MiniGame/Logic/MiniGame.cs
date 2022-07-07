using UnityEngine;
using UnityEngine.Events;

namespace Scripts.MiniGame.Logic
{
    public class MiniGame : MonoBehaviour
    {
        [SerializeField] private UnityEvent OnGameFinish;
        [SceneName] public string gameName;
        public bool isPass;

        public void UpdateMiniGameState()
        {
            if (isPass)
            {
                GetComponent<Collider2D>().enabled = false;
                GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
                OnGameFinish?.Invoke();
            }
        }
    }
}
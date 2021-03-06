using System.Collections;
using Scripts.Utilities;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scripts.Transition
{
    public class TransitionManager : Singleton<TransitionManager>
    {
        [SceneName] public string startScene;
        /// <summary>
        /// 淡入淡出主体（黑色panel遮罩）
        /// </summary>
        [SerializeField] private CanvasGroup fadeCanvasGroup;
        /// <summary>
        /// 淡入淡出持续时间
        /// </summary>
        [SerializeField] private float fadeDuration;
        /// <summary>
        /// 变色（启用遮罩）
        /// </summary>
        private bool isFade;
        /// <summary>
        /// 
        /// </summary>
        private bool canTtransition;

        /// <summary>
        /// 开始时加载的场景
        /// </summary>
        private void Start()
        {
            //StartCoroutine(Transition2Scene(string.Empty, startScene));
        }

        private void OnEnable()
        {
            EventHandler.GameStateChangeEvent += OnGameStateChangeEvent;
            EventHandler.StartNewGameEvent += OnStartNewGameEvent;
        }

        private void OnDisable()
        {
            EventHandler.GameStateChangeEvent -= OnGameStateChangeEvent;
            EventHandler.StartNewGameEvent -= OnStartNewGameEvent;
        }

        private void OnGameStateChangeEvent(GameState gameState)
        {
            canTtransition = gameState == GameState.Play;
        }

        private void OnStartNewGameEvent(int gameWeek)
        {
            StartCoroutine(Transition2Scene("Menu", startScene));
        }

        public void Transition(string from, string to)
        {
            if (!isFade && canTtransition)
            {
                StartCoroutine(Transition2Scene(from, to));
            }
        }

        /// <summary>
        /// 变换场景
        /// </summary>
        /// <param name="from">从哪个场景来</param>
        /// <param name="to">到哪个场景去</param>
        /// <returns></returns>
        private IEnumerator Transition2Scene(string from, string to)
        {
            yield return Fade(1);

            if (from != string.Empty)
            {
                EventHandler.CallBeforeSceneUnloadEvent();
                yield return SceneManager.UnloadSceneAsync(from);
            }
            
            yield return SceneManager.LoadSceneAsync(to, LoadSceneMode.Additive);

            // 找到新加载的场景（不考虑UI时）
            // TODO：优化场景获取
            Scene newScene = SceneManager.GetSceneAt(SceneManager.sceneCount - 1);
            SceneManager.SetActiveScene(newScene);
            EventHandler.CallAfterSceneUnloadEvent();
            yield return Fade(0);
        }

        /// <summary>
        /// 淡入淡出效果
        /// </summary>
        /// <param name="targetAlpha">渐变panel的阿拉法值</param>
        /// <returns></returns>
        private IEnumerator Fade(float targetAlpha)
        {
            isFade = true;
            fadeCanvasGroup.blocksRaycasts = true;

            float speed = Mathf.Abs(fadeCanvasGroup.alpha - fadeDuration) / fadeDuration;
            while (!Mathf.Approximately(fadeCanvasGroup.alpha, targetAlpha))
            {
                fadeCanvasGroup.alpha = Mathf.MoveTowards(fadeCanvasGroup.alpha, targetAlpha, speed * Time.deltaTime);
                yield return null;
            }

            fadeCanvasGroup.blocksRaycasts = false;
            isFade = false;
        }
    }
}
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
        /// ���뵭�����壨��ɫpanel���֣�
        /// </summary>
        [SerializeField] private CanvasGroup fadeCanvasGroup;
        /// <summary>
        /// ���뵭������ʱ��
        /// </summary>
        [SerializeField] private float fadeDuration;
        /// <summary>
        /// ��ɫ���������֣�
        /// </summary>
        private bool isFade;
        /// <summary>
        /// 
        /// </summary>
        private bool canTtransition;

        /// <summary>
        /// ��ʼʱ���صĳ���
        /// </summary>
        private void Start()
        {
            //StartCoroutine(Transition2Scene(string.Empty, startScene));
        }

        private void OnEnable()
        {
            EventHandler.GameStateChangeEvent += ObGameStateChangeEvent;
        }

        private void OnDisable()
        {
            EventHandler.GameStateChangeEvent -= ObGameStateChangeEvent;
        }

        private void ObGameStateChangeEvent(GameState gameState)
        {
            canTtransition = gameState == GameState.Play;
        }

        public void Transition(string from, string to)
        {
            if (!isFade && canTtransition)
            {
                StartCoroutine(Transition2Scene(from, to));
            }
        }

        /// <summary>
        /// �任����
        /// </summary>
        /// <param name="from">���ĸ�������</param>
        /// <param name="to">���ĸ�����ȥ</param>
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

            // �ҵ��¼��صĳ�����������UIʱ��
            // TODO���Ż�������ȡ
            Scene newScene = SceneManager.GetSceneAt(SceneManager.sceneCount - 1);
            SceneManager.SetActiveScene(newScene);
            EventHandler.CallAfterSceneUnloadEvent();
            yield return Fade(0);
        }

        /// <summary>
        /// ���뵭��Ч��
        /// </summary>
        /// <param name="targetAlpha">����panel�İ�����ֵ</param>
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
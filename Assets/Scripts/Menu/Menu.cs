using Scripts.Transition;
using Scripts.Utilities;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scripts.Menu
{
    public class Menu : MonoBehaviour
    {
        public void QuitGame()
        {
            Application.Quit();
        }

        public void Continue()
        {
            // TODO：加载游戏进度
        }

        public void GoBackMenu()
        {
            var currentScene = SceneManager.GetActiveScene().name;
            TransitionManager.Instance.Transition(currentScene, "Menu");

            // TODO：保存游戏进度
        }

        public void StartGameWeek(int gameWeek)
        {
            EventHandler.CallStartNewGameEvent(gameWeek);
        }
    }
}
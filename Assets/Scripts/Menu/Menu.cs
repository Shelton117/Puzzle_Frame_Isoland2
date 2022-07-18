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
            // TODO��������Ϸ����
        }

        public void GoBackMenu()
        {
            var currentScene = SceneManager.GetActiveScene().name;
            TransitionManager.Instance.Transition(currentScene, "Menu");

            // TODO��������Ϸ����
        }

        public void StartGameWeek(int gameWeek)
        {
            EventHandler.CallStartNewGameEvent(gameWeek);
        }
    }
}
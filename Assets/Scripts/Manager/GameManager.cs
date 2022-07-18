using System.Collections.Generic;
using Scripts.MiniGame.Logic;
using Scripts.Utilities;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scripts.Manager
{
    public class GameManager : MonoBehaviour
    {
        private Dictionary<string, bool> miniGameStateDict = new Dictionary<string, bool>();
        private GameController currentGame;
        private int gameWeek;
        
        void Start()
        {
            SceneManager.LoadScene("Menu", LoadSceneMode.Additive);
            EventHandler.CallGameStateChangeEvent(GameState.Play);
        }

        private void OnEnable()
        {
            EventHandler.AfterSceneUnloadEvent += OnAfterSceneUnloadEvent;
            EventHandler.GamePassEvent += OnGamePassEvent;
            EventHandler.StartNewGameEvent += OnStartNewGameEvent;
        }

        private void OnDisable()
        {
            EventHandler.AfterSceneUnloadEvent -= OnAfterSceneUnloadEvent;
            EventHandler.GamePassEvent -= OnGamePassEvent;
            EventHandler.StartNewGameEvent -= OnStartNewGameEvent;
        }

        private void OnAfterSceneUnloadEvent()
        {
            foreach (var miniGame in FindObjectsOfType<MiniGame.Logic.MiniGame>())
            {
                if (miniGameStateDict.TryGetValue(miniGame.gameName, out bool isPass))
                {
                    miniGame.isPass = isPass;
                    miniGame.UpdateMiniGameState();
                }
            }

            currentGame = FindObjectOfType<GameController>();
            currentGame?.SetGameWeekData(gameWeek);
        }

        private void OnGamePassEvent(string gameName)
        {
            miniGameStateDict[gameName] = true;
        }

        private void OnStartNewGameEvent(int gameWeek)
        {
            this.gameWeek = gameWeek;
        }
    }
}
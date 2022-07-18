using System;
using Scripts.Inventory.Data;

namespace Scripts.Utilities
{
    /// <summary>
    /// 事件处理
    /// 注册监听事件
    /// </summary>
    public static class EventHandler
    {
        public static event Action<ItemDetails, int> UpdateUIEvent;

        public static void CallUpdateUIEvent(ItemDetails itemDetails, int index)
        {
            UpdateUIEvent?.Invoke(itemDetails, index);
        }

        public static event Action BeforeSceneUnloadEvent;
        public static void CallBeforeSceneUnloadEvent()
        {
            BeforeSceneUnloadEvent?.Invoke();
        }

        public static event Action AfterSceneUnloadEvent;
        public static void CallAfterSceneUnloadEvent()
        {
            AfterSceneUnloadEvent?.Invoke();
        }

        public static Action<ItemDetails, bool> ItemSelectEvent;
        public static void CallItemSelectEvent(ItemDetails itemDetails, bool isSelected)
        {
            ItemSelectEvent?.Invoke(itemDetails, isSelected);
        }

        public static Action<ItemName> ItemUsedEvent;
        public static void CallItemUsedEvent(ItemName itemName)
        {
            ItemUsedEvent?.Invoke(itemName);
        }

        public static Action<int> ChangeItemEvent;
        public static void CallChangeItemEvent(int index)
        {
            ChangeItemEvent?.Invoke(index);
        }

        public static Action<string> ShowDialogueEvent;
        public static void CallShowDialogueEvent(string dialogue)
        {
            ShowDialogueEvent?.Invoke(dialogue);
        }

        public static Action<GameState> GameStateChangeEvent;
        public static void CallGameStateChangeEvent(GameState gameState)
        {
            GameStateChangeEvent?.Invoke(gameState);
        }

        public static Action CheckGameStateEvent;
        public static void CallCheckGameStateEvent()
        {
            CheckGameStateEvent?.Invoke();
        }

        public static Action<string> GamePassEvent;
        public static void CallGamePassEvent(string miniGame)
        {
            GamePassEvent?.Invoke(miniGame);
        }

        public static event Action<int> StartNewGameEvent;
        public static void CallStartNewGameEvent(int gameWeek)
        {
            StartNewGameEvent?.Invoke(gameWeek);
        }
    }
}
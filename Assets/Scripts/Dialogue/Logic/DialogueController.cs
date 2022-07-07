using System.Collections;
using System.Collections.Generic;
using Scripts.Dialogue.Data;
using Scripts.Utilities;
using UnityEngine;

namespace Scripts.Dialogue.Logic
{
    public class DialogueController : MonoBehaviour
    {
        [SerializeField] private DialogueData_SO dialogueEmpty;
        [SerializeField] private DialogueData_SO dialogueFinish;

        private bool isTalking;

        private Stack<string> dialogueEmptyStack;
        private Stack<string> dialogueFinishStack;

        private void Awake()
        {
            FillDialogueStack();
        }

        private void FillDialogueStack()
        {
            dialogueEmptyStack = new Stack<string>();
            dialogueFinishStack = new Stack<string>();

            for (int i = 0; i < dialogueEmpty.dialogueList.Count; i++)
            {
                dialogueEmptyStack.Push(dialogueEmpty.dialogueList[i]);
            }

            for (int i = 0; i < dialogueFinish.dialogueList.Count; i++)
            {
                dialogueFinishStack.Push(dialogueFinish.dialogueList[i]);
            }
        }

        public void ShowDialogueEmpty()
        {
            if (!isTalking)
            {
                StartCoroutine(DialogueRoutine(dialogueEmptyStack));
            }
        }

        public void ShowDialogueFinish()
        {
            if (!isTalking)
            {
                StartCoroutine(DialogueRoutine(dialogueFinishStack));
            }
        }

        private IEnumerator DialogueRoutine(Stack<string> data)
        {
            isTalking = true;

            if (data.TryPop(out string result))
            {
                EventHandler.CallShowDialogueEvent(result);
                yield return null;
                isTalking = false;
                EventHandler.CallGameStateChangeEvent(GameState.Pause);
            }
            else
            {
                EventHandler.CallShowDialogueEvent(string.Empty);
                FillDialogueStack();
                isTalking = false;
                EventHandler.CallGameStateChangeEvent(GameState.Play);
            }
        }
    }
}
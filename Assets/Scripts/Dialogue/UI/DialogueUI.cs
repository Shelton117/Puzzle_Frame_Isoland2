using System;
using UnityEngine;
using UnityEngine.UI;
using EventHandler = Scripts.Utilities.EventHandler;

namespace Dialogue.UI
{
    public class DialogueUI : MonoBehaviour
    {
        [SerializeField]
        private GameObject panel;
        [SerializeField]
        private Text dialogueText;

        private void OnEnable()
        {
            EventHandler.ShowDialogueEvent += ShowDialogue;
        }

        private void OnDisable()
        {
            EventHandler.ShowDialogueEvent -= ShowDialogue;
        }

        private void ShowDialogue(string dialogue)
        {
            if (dialogue != String.Empty)
            {
                panel.SetActive(true);
            }
            else
            {
                panel.SetActive(false);
            }

            dialogueText.text = dialogue;
        }
    }
}
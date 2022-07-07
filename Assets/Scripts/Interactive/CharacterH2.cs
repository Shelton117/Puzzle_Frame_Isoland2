using Scripts.Dialogue.Logic;
using UnityEngine;

namespace Scripts.Interactive
{
    [RequireComponent(typeof(DialogueController))]
    public class CharacterH2 : Interactive
    {
        private DialogueController dialogueController;

        private void Awake()
        {
            dialogueController = GetComponent<DialogueController>();
        }

        public override void EmptyClicked()
        {
            if (isDone)
            {
                dialogueController.ShowDialogueFinish();
            }
            else
            {
                dialogueController.ShowDialogueEmpty();
            }
        }

        protected override void OnClickAction()
        {
            dialogueController.ShowDialogueFinish();
        }
    }
}
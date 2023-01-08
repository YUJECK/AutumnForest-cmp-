using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace AutumnForest.DialogueSystem
{
    public class DialogueManager : MonoBehaviour
    {
        public event Action<Dialogue> OnConversationStarted;
        public event Action<Dialogue> OnNextPhrase;
        public event Action<Dialogue> OnConversationEnds;

        private Dialogue currentDialogue;

        private void Awake ()
        {
            Dialogue[] allDialogues = FindObjectsOfType<Dialogue>();
            
            foreach (Dialogue dialogue in allDialogues)
                dialogue.OnConversationStarted.AddListener(StartDialogue);

            GlobalServiceLocator.GetService<PlayerInput>().Player.Dialogue.Disable();
        }

        private void StartDialogue(Dialogue dialogue)
        {
            if (currentDialogue != null)
                EndDialogue(); 
            
            currentDialogue = dialogue;
            cloud.SetActive(true);
            GlobalServiceLocator.GetService<PlayerInput>().Player.Dialogue.performed += DialogueInput;
            currentDialogue.OnNextPhrase.AddListener(ShowPhrase);
            currentDialogue.OnConversationEnds.AddListener(EndDialogue);

            GlobalServiceLocator.GetService<PlayerInput>().Player.Dialogue.Enable();
        }
        private void EndDialogue()
        {
            if(currentDialogue != null)
            {
                currentDialogue.OnNextPhrase.RemoveListener(ShowPhrase);
                currentDialogue.OnConversationEnds.RemoveListener(EndDialogue);
                currentDialogue = null;
                cloud.SetActive(false);

                GlobalServiceLocator.GetService<PlayerInput>().Player.Dialogue.Disable();
            }
        }
        
        private void DialogueInput(UnityEngine.InputSystem.InputAction.CallbackContext obj) => currentDialogue.NextPhrase();
        

        private IEnumerator ShowText(string text)
        {
            dialogueText.text = "";

            foreach(char letter in text)
            {
                dialogueText.text = dialogueText.text + letter;
                yield return new WaitForSeconds(0.05f);
            }
        }

    }
}
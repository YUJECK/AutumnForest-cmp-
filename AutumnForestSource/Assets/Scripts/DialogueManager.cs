using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace AutumnForest
{
    public class DialogueManager : MonoBehaviour
    {
        [SerializeField] private GameObject cloud;
        [SerializeField] private Text dialogueText;
        [SerializeField] private Text dialogueName;

        private Dialogue currentDialogue;
        private Coroutine showText;

        private void StartDialogue(Dialogue dialogue)
        {
            if (currentDialogue == null)
            {
                currentDialogue = dialogue;
                cloud.SetActive(true);
                currentDialogue.OnNextPhrase.AddListener(ShowPhrase);
                currentDialogue.OnConversationEnds.AddListener(EndDialogue);
            }
            else { /*Some logic*/ } 
        }
        private void EndDialogue()
        {
            if(currentDialogue != null)
            {
                currentDialogue.OnNextPhrase.RemoveListener(ShowPhrase);
                currentDialogue.OnConversationEnds.RemoveListener(EndDialogue);
                currentDialogue = null;
                cloud.SetActive(false);
            }
        }
        private void ShowPhrase(string phrase, string name)
        {
            dialogueName.text = name;
            
            if (showText != null) StopCoroutine(showText);
            showText = StartCoroutine(ShowText(phrase));
        }
        private IEnumerator ShowText(string text)
        {
            dialogueText.text = "";

            foreach(char letter in text)
            {
                dialogueText.text = dialogueText.text + letter;
                yield return new WaitForSeconds(0.05f);
            }
        }

        //unity methods
        private void Start()
        {
            Dialogue[] allDialogues = FindObjectsOfType<Dialogue>();
            
            foreach (Dialogue dialogue in allDialogues)
                dialogue.OnConversationStarts.AddListener(StartDialogue);
        }
    }
}

using UnityEngine;

namespace AutumnForest.DialogueSystem
{
    [RequireComponent(typeof(InteractionField))]
    [RequireComponent(typeof(Dialogue))]
    public class DialogueTriggerArea : MonoBehaviour
    {
        private InteractionField interactionField;
        private Dialogue dialogue;

        private void Awake()
        {
            //get components
            interactionField = GetComponent<InteractionField>();
            dialogue = GetComponent<Dialogue>();
        }
        private void Start()
        {
            //adding listeners to events
            interactionField.OnTriggerEnter.OnEnter.AddListener(delegate { dialogue.StartConversation(); });
            interactionField.OnTriggerExit.OnExit.AddListener(delegate { dialogue.EndConversation(); });
            interactionField.OnKeyDown.OnKeyDown.AddListener(delegate { dialogue.NextPhrase(); });
        }
    }
}
using UnityEngine;

namespace AutumnForest.DialogueSystem
{
    [RequireComponent(typeof(InteractionField))]
    [RequireComponent(typeof(Dialogue))]
    public class DialogueTriggerArea : MonoBehaviour
    {
        void Awake()
        {
            //get components
            InteractionField interactionField = GetComponent<InteractionField>();
            Dialogue dialogue = GetComponent<Dialogue>();
            //adding listeners to events
            interactionField.OnTriggerEnter.OnEnter.AddListener(delegate { dialogue.StartConversation(); });
            interactionField.OnTriggerExit.OnExit.AddListener(delegate { dialogue.EndConversation(); });
            interactionField.OnKeyDown.OnKeyDown.AddListener(delegate { dialogue.NextPhrase(); });
        }
    }
}
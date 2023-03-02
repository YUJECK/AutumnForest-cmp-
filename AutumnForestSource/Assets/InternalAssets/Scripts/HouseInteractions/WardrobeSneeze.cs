using AutumnForest.DialogueSystem;
using UnityEngine;

namespace AutumnForest
{
    [DisallowMultipleComponent()]
    [RequireComponent(typeof(Dialogue))]
    [RequireComponent(typeof(Collider2D))]
    public sealed class WardrobeSneeze : MonoBehaviour
    {
        private Dialogue sneezeDialogue;


        private void Awake()
        {
            sneezeDialogue = GetComponent<Dialogue>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.CompareTag(TagHelper.PlayerTag))
            {
                GlobalServiceLocator.GetService<PlayerMovable>().Disable();
            
                sneezeDialogue.OnDialogueEnded += OnDialogueEnded;
                sneezeDialogue.StartDialogue();
            }
        }

        private void OnDialogueEnded(Dialogue obj)
        {
            GlobalServiceLocator.GetService<PlayerMovable>().Enable();
            obj.OnDialogueEnded -= OnDialogueEnded;
        }
    }
}
using UnityEngine;

namespace AutumnForest.DialogueSystem
{
    [RequireComponent(typeof(Dialogue))]
    public sealed class PassiveDialogue : MonoBehaviour
    {
        public Dialogue Dialogue { get; private set; }

        private void Awake()
        {
            Dialogue = GetComponent<Dialogue>();

            Dialogue.OnDialogueEnded += OnDialogueEnded;
            Dialogue.OnDialogueStarted += OnDialogueStarted;
        }

        public void Enable() => GlobalServiceLocator.GetService<PlayerInput>().Inputs.Dialogue.performed += DialogueInput;
        public void Disable() => GlobalServiceLocator.GetService<PlayerInput>().Inputs.Dialogue.performed -= DialogueInput;

        private void OnDialogueStarted(Dialogue obj) => Enable();
        private void OnDialogueEnded(Dialogue obj) => Disable();

        private void DialogueInput(UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            if (!Dialogue.IsCurrentlyActive) Dialogue.StartDialogue();
            else Dialogue.NextPhrase();
        }
    }
}
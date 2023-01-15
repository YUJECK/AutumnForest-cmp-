using AutumnForest.BossFight.Raccoon;
using AutumnForest.Helpers;
using UnityEngine;

namespace AutumnForest.DialogueSystem
{
    public sealed class PassiveDialogue : MonoBehaviour, ICreatureComponent
    {
        public Dialogue Dialogue { get; private set; } 

        private void OnEnable() => GlobalServiceLocator.GetService<PlayerInput>().Inputs.Dialogue.performed += DialogueInput;
        private void OnDisable() => GlobalServiceLocator.GetService<PlayerInput>().Inputs.Dialogue.performed -= DialogueInput;
        private void Awake() => Dialogue = GetComponent<Dialogue>();

        private void DialogueInput(UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            if (!Dialogue.IsCurrentlyActive) Dialogue.StartDialogue();
            else Dialogue.NextPhrase();
        }
    }
}
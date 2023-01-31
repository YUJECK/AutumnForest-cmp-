using AutumnForest.DialogueSystem;
using UnityEngine;

namespace AutumnForest.NPC
{
    [RequireComponent(typeof(Animator))]
    public class OwlAnimator : MonoBehaviour
    {
        private Animator creatureAnimator;
        [SerializeField] private InteractiveDialogue interactiveDialogue;

        [SerializeField] private string owlComeOutAnimation = "OwlComingOut";
        [SerializeField] private string owlComeInAnimation = "OwlComingIn";

        private void Awake()
        {
            creatureAnimator = GetComponent<Animator>();
        }
        private void OnEnable()
        {
            interactiveDialogue.Dialogue.OnDialogueStarted += OwlComeOut;
            interactiveDialogue.Dialogue.OnDialogueEnded += OwlComeIn;
        }
        private void OnDisable()
        {
            interactiveDialogue.Dialogue.OnDialogueStarted -= OwlComeOut;
            interactiveDialogue.Dialogue.OnDialogueEnded -= OwlComeIn;
        }

        private void OwlComeIn(Dialogue obj) => creatureAnimator.Play(owlComeInAnimation);
        private void OwlComeOut(Dialogue obj) => creatureAnimator.Play(owlComeOutAnimation);
    }
}
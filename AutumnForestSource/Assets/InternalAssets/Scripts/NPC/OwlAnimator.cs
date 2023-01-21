using AutumnForest.DialogueSystem;
using UnityEngine;

namespace AutumnForest.NPC
{
    [RequireComponent(typeof(CreatureAnimator))]
    public class OwlAnimator : MonoBehaviour
    {
        private CreatureAnimator creatureAnimator;
        [SerializeField] private InteractiveDialogue interactiveDialogue;

        [SerializeField] private string owlComeOutAnimation = "OwlComingOut";
        [SerializeField] private string owlComeInAnimation = "OwlComingIn";

        private void Awake()
        {
            creatureAnimator = GetComponent<CreatureAnimator>();
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

        private void OwlComeIn(Dialogue obj) => creatureAnimator.PlayAnimation(owlComeInAnimation);
        private void OwlComeOut(Dialogue obj) => creatureAnimator.PlayAnimation(owlComeOutAnimation);
    }
}
using UnityEngine;

namespace AutumnForest.DialogueSystem
{
    [RequireComponent(typeof(DialogueWindowUI))]
    public sealed class DialogueWindowAnimator : MonoBehaviour
    {


        private void Awake()
        {
            animator = GetComponent<Animator>();

            UIWindow dialogueWindow = GetComponent<UIWindow>();

            dialogueWindow.OnWindowEnabled += OnWindowEnabled;
            dialogueWindow.OnWindowDisabled += OnWindowDisabled;
        }   

        private void OnWindowEnabled()
        {
            animator.Play(windowEnableAnimationName);
        }

        private void OnWindowDisabled()
        {
            animator.Play(windowDisableAnimationName);
        }
    }
}
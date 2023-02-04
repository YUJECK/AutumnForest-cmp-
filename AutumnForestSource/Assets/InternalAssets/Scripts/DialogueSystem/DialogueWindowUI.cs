using Cysharp.Threading.Tasks;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace AutumnForest.DialogueSystem
{
    [RequireComponent(typeof(Animator))]
    public class DialogueWindowUI : MonoBehaviour
    {
        [SerializeField] private AnimationClip windowDisableAnimation;
        [SerializeField] private AnimationClip windowEnableAnimation;

        private Animator animator;

        [SerializeField] private GameObject dialogueWindowUI;
        [SerializeField] private Text dialogueTextUI;
        [SerializeField] private Text dialogueNameUI;

        [SerializeField] private float textSpeed = 0.02f;

        //костыль момент
        private UniTask disableTask;
        private UniTask enableTask;

        private void Start()
        {
            dialogueWindowUI.SetActive(false);
            animator = GetComponent<Animator>();
        }
        private void OnEnable()
        {
            GlobalServiceLocator.GetService<DialogueManager>().OnDialogueStarted += OnDialogueStarted;
            GlobalServiceLocator.GetService<DialogueManager>().OnDialogueEnded += OnDialogueEnded;
            GlobalServiceLocator.GetService<DialogueManager>().OnPhraseSwitched += ShowPhrase;
        }
        private void OnDisable()
        {
            GlobalServiceLocator.GetService<DialogueManager>().OnDialogueStarted -= OnDialogueStarted;
            GlobalServiceLocator.GetService<DialogueManager>().OnDialogueEnded -= OnDialogueEnded;
            GlobalServiceLocator.GetService<DialogueManager>().OnPhraseSwitched -= ShowPhrase;
        }

        private void OnDialogueStarted(Dialogue dialogue)
        {
            enableTask = SelfEnable();
            dialogueNameUI.text = dialogue.DialogueName.Value;
        }
        private void OnDialogueEnded(Dialogue dialogue) => disableTask = SelfDisable();

        private async void ShowPhrase(string name, string text)
        {
            dialogueNameUI.text = name;
            dialogueTextUI.text = "";

            for (int i = 0; i < text.Length; i++)
            {
                dialogueTextUI.text += text[i];
                await UniTask.Delay(TimeSpan.FromSeconds(textSpeed));
            }
        }

        protected async UniTask SelfEnable()
        {
            if (disableTask.Status == UniTaskStatus.Pending)
                await disableTask;

            dialogueWindowUI.SetActive(true);
            animator.Play(windowEnableAnimation.name);

            await UniTask.Delay(TimeSpan.FromSeconds(windowEnableAnimation.length));
        }
        protected async UniTask SelfDisable()
        {
            if (enableTask.Status == UniTaskStatus.Pending)
                await enableTask;

            dialogueTextUI.text = "";
            dialogueNameUI.text = "";

            animator.Play(windowDisableAnimation.name);
            await UniTask.Delay(TimeSpan.FromSeconds(windowDisableAnimation.length));

            dialogueWindowUI.SetActive(false);
        }
    }
}
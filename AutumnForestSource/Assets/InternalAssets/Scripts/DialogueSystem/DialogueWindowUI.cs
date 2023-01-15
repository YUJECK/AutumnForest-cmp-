using AutumnForest.Extensions;
using Cysharp.Threading.Tasks;
using System;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

namespace AutumnForest.DialogueSystem
{
    [RequireComponent(typeof(Animator))]
    public class DialogueWindowUI : UIWindow
    {
        private const string windowEnableAnimationName = "DialogueWindowEnable";
        private const string windowDisableAnimationName = "DialogueWindowDisable";

        private Animator animator;

        [SerializeField] private GameObject dialogueWindowUI;
        [SerializeField] private Text dialogueTextUI;
        [SerializeField] private Text dialogueNameUI;

        [SerializeField] private float textSpeed = 0.02f;

        private CancellationTokenSource token = new();
        private UniTask disableTask;
        //костыль момент

        private void Start()
        {
            dialogueWindowUI.SetActive(false);
            animator = GetComponent<Animator>();

            GlobalServiceLocator.GetService<DialogueManager>().OnDialogueStarted += OnDialogueStarted;
            GlobalServiceLocator.GetService<DialogueManager>().OnDialogueEnded += OnDialogueEnded;
            GlobalServiceLocator.GetService<DialogueManager>().OnPhraseSwitched += ShowPhrase;
        }

        private void OnDialogueStarted(Dialogue dialogue)
        {
            SelfEnable();
            dialogueNameUI.text = dialogue.dialogueName;
        }
        private void OnDialogueEnded(Dialogue dialogue)
        {
            SelfDisable();
        }

        private async void ShowPhrase(string name, string text)
        {
            dialogueNameUI.text = name;
            dialogueTextUI.text = "";

            for (int i = 0; i < text.Length; i++)
            {
                dialogueTextUI.text += text[i];
                await UniTask.Delay(TimeSpan.FromSeconds(textSpeed), cancellationToken: token.Token);
            }
        }

        protected override void SelfEnable()
        {
            Enable();

            async UniTaskVoid Enable()
            {
                if (disableTask.Status == UniTaskStatus.Pending)
                    await disableTask;

                dialogueWindowUI.SetActive(true);
                animator.Play(windowEnableAnimationName);
            }
        }
        protected override void SelfDisable()
        {
            disableTask = Disable();

            async UniTask Disable()
            {
                dialogueTextUI.text = "";
                dialogueNameUI.text = "";

                animator.Play(windowDisableAnimationName);
                await animator.WaitForEndOfCurrentClip(0.8f);

                dialogueWindowUI.SetActive(false);
            }
        }
    }
}
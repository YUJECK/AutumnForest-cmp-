using Cysharp.Threading.Tasks;
using System;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

namespace AutumnForest.DialogueSystem
{
    [RequireComponent(typeof(Animator))]
    public class DialogueWindowUI : MonoBehaviour
    {
        [SerializeField] private AnimationClip windowDisableAnimation;
        [SerializeField] private AnimationClip windowEnableAnimation;

        [SerializeField] private AudioSource dialogueClickAudio;

        private Animator animator;

        [SerializeField] private GameObject dialogueWindowUI;
        [SerializeField] private Text dialogueTextUI;
        [SerializeField] private Text dialogueNameUI;

        [SerializeField] private float textSpeed = 0.02f;

        private bool isClosing = false;
        private bool isOpening = false;

        private CancellationTokenSource cancellationToken;

        private void Start()
        {
            dialogueWindowUI.SetActive(false);
            animator = GetComponent<Animator>();
        }
        private void OnEnable()
        {
            GlobalServiceLocator.GetService<DialogueManager>().OnDialogueStarted += OnDialogueStarted;
            GlobalServiceLocator.GetService<DialogueManager>().OnDialogueEnded += OnDialogueEnded;
            GlobalServiceLocator.GetService<DialogueManager>().OnPhraseSwitched += OnPhraseSwitched;

            cancellationToken = new();
        }
        private void OnDisable()
        {
            if (GlobalServiceLocator.TryGetService(out DialogueManager dialogueManager))
            {
                dialogueManager.OnDialogueStarted -= OnDialogueStarted;
                dialogueManager.OnDialogueEnded -= OnDialogueEnded;
                dialogueManager.OnPhraseSwitched -= OnPhraseSwitched;
            }

            cancellationToken.Dispose();
        }
        private void OnDestroy() => cancellationToken.Dispose();

        private void OnPhraseSwitched(string name, string phrase)
        {
            cancellationToken.Cancel();
            
            cancellationToken = new();
            ShowPhrase(name, phrase, cancellationToken.Token);
        }

        private void OnDialogueStarted(Dialogue dialogue)
        {
            EnableWidow();
        }
        private void OnDialogueEnded(Dialogue dialogue)
        {
            if(dialogueClickAudio.isPlaying) dialogueClickAudio.Stop();
            DisableWIndow();
        }

        private async void ShowPhrase(string name, string text, CancellationToken token)
        {
            while (isClosing || isOpening) await UniTask.Yield();

            dialogueNameUI.text = name;
            dialogueTextUI.text = "";

            dialogueClickAudio.Play();

            try
            {
                for (int i = 0; i < text.Length; i++)
                {
                    dialogueTextUI.text += text[i];
                    await UniTask.Delay(TimeSpan.FromSeconds(textSpeed), cancellationToken: token);
                }
                dialogueClickAudio.Stop();
            }
            catch
            {
                return;
            }
        }

        private async void EnableWidow()
        {
            while(isClosing)
                await UniTask.Yield();

            isOpening = true;
            {
                dialogueWindowUI.SetActive(true);
                animator.Play(windowEnableAnimation.name);

                await UniTask.Delay(TimeSpan.FromSeconds(windowEnableAnimation.length));
            }
            isOpening = false;
        }
        private async void DisableWIndow()
        {
            while (isOpening)
                await UniTask.Yield();

            isClosing = true;
            {
                ClearWindow();

                animator.Play(windowDisableAnimation.name);
                
                await UniTask.Delay(TimeSpan.FromSeconds(windowDisableAnimation.length));

                dialogueWindowUI.SetActive(false);
            }
            isClosing = false;
        }

        private void ClearWindow()
        {
            dialogueTextUI.text = "";
            dialogueNameUI.text = "";
        }
    }
}
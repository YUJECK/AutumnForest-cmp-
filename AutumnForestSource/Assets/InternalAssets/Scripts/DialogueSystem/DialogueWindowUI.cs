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

        //костыль момент
        private UniTask disableTask;
        private UniTask enableTask;

        private CancellationTokenSource cancellationToken;

        private void Start()
        {
            dialogueWindowUI.SetActive(false);
            animator = GetComponent<Animator>();
        }
        private void OnEnable()
        {
            Debug.Log("OnEnable");

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
        private void OnDestroy()
        {
            cancellationToken.Dispose();
        }

        private void OnPhraseSwitched(string name, string phrase)
        {
            cancellationToken.Cancel();
            
            cancellationToken = new();
            ShowPhrase(name, phrase, cancellationToken.Token);
        }

        private void OnDialogueStarted(Dialogue dialogue)
        {
            enableTask = SelfEnable();
            dialogueNameUI.text = dialogue.DialogueName.Value;
        }
        private void OnDialogueEnded(Dialogue dialogue)
        {
            if(dialogueClickAudio.isPlaying)
                dialogueClickAudio.Stop();
            
            disableTask = SelfDisable();
        }

        private async void ShowPhrase(string name, string text, CancellationToken token)
        {
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
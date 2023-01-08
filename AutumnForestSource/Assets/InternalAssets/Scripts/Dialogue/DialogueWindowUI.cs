using Cysharp.Threading.Tasks;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace AutumnForest.DialogueSystem
{
    public class DialogueWindowUI : MonoBehaviour
    {
        [SerializeField] private GameObject dialogueWindowUI;
        [SerializeField] private Text dialogueTextUI;
        [SerializeField] private Text dialogueNameUI;
        [SerializeField] private float textSpeed = 0.2f;

        private async void ShowPhrase(Dialogue dialogue)
        {
            dialogueNameUI.text = name;

            for (int i = 0; i < dialogue.; i++)
            {

                await UniTask.Delay(TimeSpan.FromSeconds(textSpeed));            
            }
        }
    }
}
using AutumnForest.DialogueSystem;
using Cinemachine;
using Cysharp.Threading.Tasks;
using System;
using UnityEngine;

namespace AutumnForest.Catscenes
{
    public class MafiaHouseCutscene : Catscene
    {
        [SerializeField] private new CinemachineVirtualCamera camera;
        [SerializeField] private AudioSource titlesTheme;
        [SerializeField] private AudioSource mafiaHouseTheme;

        [SerializeField] private PassiveDialogue dialogue;

        protected override async void OnCatsceneStart()
        {
            camera.gameObject.SetActive(true);
            await titlesTheme.StopSmoothly();

            await UniTask.Delay(TimeSpan.FromSeconds(1.5f));
            
            mafiaHouseTheme.Play();
            dialogue.Dialogue.StartDialogue();
        }
        protected override void OnCatsceneEnd()
        {
            camera.gameObject.SetActive(false);
        }
    }
}
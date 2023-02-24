using AutumnForest.DialogueSystem;
using Cinemachine;
using Cysharp.Threading.Tasks;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace AutumnForest.Catscenes
{
    public class MafiaHouseCutscene : Catscene
    {
        [SerializeField] private new CinemachineVirtualCamera camera;
        [SerializeField] private AudioSource titlesTheme;
        [SerializeField] private AudioSource mafiaHouseTheme;
            
        [SerializeField] private DialgueBus dialgueBus;
        [SerializeField] private Transform secondTarget; 

        protected override async void OnCatsceneStart()
        {
            SetCatsceneObjectsActive(true);
            camera.gameObject.SetActive(true);

            dialgueBus.OnBusCompleted += EndCutScene;
            
            await titlesTheme.StopSmoothly();
            await UniTask.Delay(TimeSpan.FromSeconds(1.5f));

            mafiaHouseTheme.Play();
            
            await UniTask.Delay(TimeSpan.FromSeconds(4f));
            dialgueBus.StartBus();
        }
        protected override async void OnCatsceneEnd()
        {
            
            camera.Follow = secondTarget;
            camera.LookAt = secondTarget;

            await UniTask.Delay(TimeSpan.FromSeconds(3f));
            SetCatsceneObjectsActive(false);
            await FindObjectOfType<BlackoutTransition>().StartBlackout();
            SceneManager.LoadScene(0);

            //перемещаем типо в "спасибо за игру"
        }
    }
}
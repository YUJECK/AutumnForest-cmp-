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
            
        [SerializeField] private DialgueBus dialgueBus;

        private void Awake()
        {
            objectsInCatscene.Add(camera.gameObject);
        }

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
        protected override void OnCatsceneEnd()
        {
            SetCatsceneObjectsActive(false);

            //перемещаем типо в "спасибо за игру"
        }
    }
}
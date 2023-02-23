using Cinemachine;
using Cysharp.Threading.Tasks;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace AutumnForest.Catscenes
{
    public class StaticCatscene : Catscene
    {
        [SerializeField] private float catsceneDuraiton;
        
        [SerializeField] private CinemachineVirtualCamera catsceneCamera;

        private BlackoutTransition blackoutTransition;

        private void Awake()
        {
            blackoutTransition = FindObjectOfType<BlackoutTransition>(true);
            objectsInCatscene.Add(catsceneCamera.gameObject);

            SetCatsceneObjectsActive(false);                
        }
        protected override void OnCatsceneStart()
        {
            SetCatsceneObjectsActive(true);
            Wait();
        }
        protected override void OnCatsceneEnd() => SetCatsceneObjectsActive(false);


        private async void Wait()
        {
            await UniTask.Delay(TimeSpan.FromSeconds(catsceneDuraiton));
            await blackoutTransition.StartBlackout();
            
            EndCutScene();
        }
    }
}
using Cinemachine;
using Cysharp.Threading.Tasks;
using System;
using UnityEngine;

namespace AutumnForest.Catscenes
{
    public class StaticCatscene : Catscene
    {
        [SerializeField] private float catsceneDuraiton;
        [SerializeField] private new CinemachineVirtualCamera camera;

        private BlackoutTransition blackoutTransition;

        private void Awake() => blackoutTransition = FindObjectOfType<BlackoutTransition>(true);

        protected override void OnCatsceneStart()
        {
            camera.gameObject.SetActive(true);
            Wait();
        }
        protected override void OnCatsceneEnd()
        {
            camera.gameObject.SetActive(false);
        }


        private async void Wait()
        {
            await UniTask.Delay(TimeSpan.FromSeconds(catsceneDuraiton));
            
            await blackoutTransition.StartBlackout();
            
            EndCutScene();
        }
    }
}
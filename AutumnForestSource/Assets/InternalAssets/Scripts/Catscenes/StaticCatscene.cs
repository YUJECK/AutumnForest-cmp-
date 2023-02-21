using Cinemachine;
using Cysharp.Threading.Tasks;
using System;
using UnityEngine;

namespace AutumnForest.Cutscenes
{
    public class StaticCatscene : Catscene
    {
        [SerializeField] private float catsceneDuraiton;
        [SerializeField] private CinemachineVirtualCamera camera;

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
            EndCutScene();
        }
    }
}
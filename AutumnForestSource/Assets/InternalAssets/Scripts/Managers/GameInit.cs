using AutumnForest.BossFight;
using AutumnForest.BossFight.Fox;
using AutumnForest.BossFight.Raccoon;
using AutumnForest.DialogueSystem;
using AutumnForest.Helpers;
using AutumnForest.Other;
using AutumnForest.Player;
using Cinemachine;
using UnityEngine;
using UnityEngine.Events;

namespace AutumnForest
{
    public sealed class GameInit : MonoBehaviour
    {
        [SerializeField] private CinemachineVirtualCamera mainCamera;
        [SerializeField] private CinemachineVirtualCamera bossfightCamera;
        [SerializeField] private CinemachineVirtualCamera slingshotCamera;

        private void OnEnable()
        {
            RegisterPlayerServices();
            RegisterBossFightServices();
            RegisterCameras();
            RegisterDialogueServices();

            GlobalServiceLocator.GetService<PlayerInput>().Enable();
        }

        private void RegisterPlayerServices()
        {
            GlobalServiceLocator.RegisterService(FindObjectOfType<PlayerMovable>());
            GlobalServiceLocator.RegisterService(FindObjectOfType<PlayerAttack>());
            GlobalServiceLocator.RegisterService(FindObjectOfType<PlayerDash>());
            GlobalServiceLocator.RegisterService(FindObjectOfType<PlayerFlipper>());
            GlobalServiceLocator.RegisterService(new PlayerInput());
        }
        private void RegisterCameras()
        {
            GlobalServiceLocator.RegisterService(new VirtualCameraHelper(mainCamera, bossfightCamera, slingshotCamera)) ;
            GlobalServiceLocator.RegisterService(FindObjectOfType<CinemachineBrain>());
        }
        private void RegisterDialogueServices()
        {
            GlobalServiceLocator.RegisterService(new DialogueManager());
        }
        private void RegisterBossFightServices()
        {
            GlobalServiceLocator.RegisterService(FindObjectOfType<RaccoonStateMachine>());
            GlobalServiceLocator.RegisterService(FindObjectOfType<BossFightController>());
            GlobalServiceLocator.RegisterService(FindObjectOfType<FoxStateMachine>());
        }
    }
}
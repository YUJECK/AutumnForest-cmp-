using AutumnForest.BossFight;
using AutumnForest.DialogueSystem;
using AutumnForest.Managers;
using AutumnForest.Player;
using Cinemachine;
using UnityEngine;

namespace AutumnForest
{
    public sealed class GlobalServiceRegistrar : MonoBehaviour
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
            GlobalServiceLocator.RegisterService(new CameraSwitcher(mainCamera, bossfightCamera, slingshotCamera));
            GlobalServiceLocator.RegisterService(FindObjectOfType<CinemachineBrain>());
        }
        private void RegisterDialogueServices()
        {
            GlobalServiceLocator.RegisterService(new DialogueManager());
        }
        private void RegisterBossFightServices()
        {
            GlobalServiceLocator.RegisterService(new BossFightManager());
        }
    }
}
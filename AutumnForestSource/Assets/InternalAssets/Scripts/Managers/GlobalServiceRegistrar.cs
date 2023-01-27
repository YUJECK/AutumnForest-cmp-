using AutumnForest.BossFight;
using AutumnForest.BossFight.Raccoon;
using AutumnForest.DialogueSystem;
using AutumnForest.Health;
using AutumnForest.Helpers;
using AutumnForest.Managers;
using AutumnForest.Player;
using Cinemachine;
using UnityEngine;

namespace AutumnForest
{
    public sealed class GlobalServiceRegistrar : MonoBehaviour
    {
        [Header("Cameras")]
        [SerializeField] private CinemachineVirtualCamera mainCamera;
        [SerializeField] private CinemachineVirtualCamera bossfightCamera;
        [SerializeField] private CinemachineVirtualCamera slingshotCamera;
        [Header("Health bars")]
        [SerializeField] private HealthBar bossHealthBar;
        [SerializeField] private HealthBar playerHealthBar;

        private void Awake()
        {
            RegisterHelpers();
            RegisterPlayerServices();
            RegisterCameras();
            RegisterDialogueServices();
            RegisterBossFightServices();

            GlobalServiceLocator.GetService<PlayerInput>().Enable();
        }

        private void RegisterPlayerServices()
        {
            GlobalServiceLocator.RegisterService(FindObjectOfType<PlayerMovable>(true));
            GlobalServiceLocator.RegisterService(FindObjectOfType<PlayerAttack>(true));
            GlobalServiceLocator.RegisterService(FindObjectOfType<PlayerDash>(true));
            GlobalServiceLocator.RegisterService(FindObjectOfType<PlayerFlipper>(true));
            GlobalServiceLocator.RegisterService(new PlayerInput());
        }
        private void RegisterCameras()
        {
            GlobalServiceLocator.RegisterService(new CameraSwitcher(mainCamera, bossfightCamera, slingshotCamera));
            GlobalServiceLocator.RegisterService(FindObjectOfType<CinemachineBrain>(true));
        }
        private void RegisterDialogueServices()
        {
            GlobalServiceLocator.RegisterService(new DialogueManager());
        }
        private void RegisterHelpers()
        {
            GlobalServiceLocator.RegisterService(new HealthBarHelper(bossHealthBar, playerHealthBar));
        }
        private void RegisterBossFightServices()
        {
            GlobalServiceLocator.RegisterService(FindObjectOfType<RaccoonStateMachineUser>(true));
            GlobalServiceLocator.RegisterService(new BossFightManager());
        }
    }
}
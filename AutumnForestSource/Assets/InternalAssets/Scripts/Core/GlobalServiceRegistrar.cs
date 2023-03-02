using AutumnForest.BossFight;
using AutumnForest.BossFight.Fox;
using AutumnForest.BossFight.Raccoon;
using AutumnForest.DialogueSystem;
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
        [SerializeField] private CinemachineVirtualCamera dialogueCamera;
        [SerializeField] private CinemachineVirtualCamera slingshotCamera;
        [SerializeField] private CinemachineVirtualCamera houseCamera;
        [SerializeField] private CinemachineVirtualCamera basementCamera;
        [Header("Music themes")]
        [SerializeField] private AudioSource mainTheme;
        [SerializeField] private AudioSource bossfightTheme;
        [SerializeField] private AudioSource basementAmbientTheme;
        [SerializeField] private AudioSource gramophoneTheme;
        [Header("Containers")]
        [SerializeField] private Transform projectileContainer;
        [SerializeField] private Transform creatureContainer;
        [SerializeField] private Transform otherContainer;

        private void Awake()
        {
            RegisterHelpers();
            RegisterPools();
            RegisterPlayerServices();
            RegisterHouseServices();
            RegisterCameras();
            RegisterMusicThemes();
            RegisterDialogueServices();
            RegisterBossFightServices();

            GlobalServiceLocator.GetService<PlayerInput>().Enable();
        }

        private void RegisterMusicThemes()
        {
            GlobalServiceLocator.RegisterService(new MusicSwitcher(
                mainTheme, bossfightTheme, basementAmbientTheme, gramophoneTheme));
        }
        private void RegisterHouseServices()
        {
            GlobalServiceLocator.RegisterService(FindObjectOfType<HouseController>(true));
        }
        private void RegisterPools()
        {
            GlobalServiceLocator.RegisterService(FindObjectOfType<PoolsContainer>(true));
        }
        private void RegisterPlayerServices()
        {
            GlobalServiceLocator.RegisterService(new PlayerInput());
            GlobalServiceLocator.RegisterService(FindObjectOfType<PlayerMovable>(true));
            GlobalServiceLocator.RegisterService(FindObjectOfType<PlayerAttack>(true));
            GlobalServiceLocator.RegisterService(FindObjectOfType<PlayerDash>(true));
        }
        private void RegisterCameras()
        {
            GlobalServiceLocator.RegisterService(new CameraSwitcher(mainCamera, bossfightCamera, slingshotCamera, dialogueCamera, houseCamera, basementCamera));
            GlobalServiceLocator.RegisterService(FindObjectOfType<CinemachineBrain>(true));
        }
        private void RegisterDialogueServices()
        {
            GlobalServiceLocator.RegisterService(new DialogueManager());
        }
        private void RegisterHelpers()
        {
            GlobalServiceLocator.RegisterService(new ContainerHelper(projectileContainer, creatureContainer, otherContainer));
            GlobalServiceLocator.RegisterService(FindObjectOfType<BlackoutTransition>(true));
        }
        private void RegisterBossFightServices()
        {
            GlobalServiceLocator.RegisterService(FindObjectOfType<BossFightUIMarker>(true));
            GlobalServiceLocator.RegisterService(FindObjectOfType<RaccoonStateMachineUser>(true));
            GlobalServiceLocator.RegisterService(FindObjectOfType<FoxStateMachineUser>(true));
            GlobalServiceLocator.RegisterService(new BossFightManager());
        }
    }
}
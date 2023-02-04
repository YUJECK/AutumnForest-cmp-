using AutumnForest.BossFight;
using AutumnForest.BossFight.Raccoon;
using AutumnForest.DialogueSystem;
using AutumnForest.Health;
using AutumnForest.Helpers;
using AutumnForest.Managers;
using AutumnForest.Player;
using AutumnForest.Projectiles;
using Cinemachine;
using System;
using UnityEngine;

namespace AutumnForest
{
    public sealed class GlobalServiceRegistrar : MonoBehaviour
    {
        [Header("Pool")]
        [SerializeField] private Projectile acorn;
        [SerializeField] private Projectile cone;
        [SerializeField] private AcornHeal acornHeal;
        [SerializeField] private Projectile defaultSword;
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
        [Header("Health bars")]
        [SerializeField] private BossFightHealthBar bossHealthBar;
        [SerializeField] private BossFightHealthBar playerHealthBar;
        [Header("Containers")]
        [SerializeField] private Transform projectileContainer;
        [SerializeField] private Transform creatureContainer;
        [SerializeField] private Transform otherContainer;

        private void Awake()
        {
            RegisterHelpers();
            RegisterPools();
            RegisterPlayerServices();
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

        private void RegisterPools()
        {
            GlobalServiceLocator.RegisterService(new SomePoolsContainer(acorn, cone, acornHeal, defaultSword));
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
            GlobalServiceLocator.RegisterService(new HealthBarHelper(bossHealthBar, playerHealthBar));
        }
        private void RegisterBossFightServices()
        {
            GlobalServiceLocator.RegisterService(FindObjectOfType<RaccoonStateMachineUser>(true));
            GlobalServiceLocator.RegisterService(FindObjectOfType<FoxStateMachineUser>(true));
            GlobalServiceLocator.RegisterService(new BossFightManager());
        }
    }
}
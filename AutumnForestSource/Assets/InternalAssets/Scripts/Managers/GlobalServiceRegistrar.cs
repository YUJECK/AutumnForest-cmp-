using AutumnForest.BossFight;
using AutumnForest.BossFight.Raccoon;
using AutumnForest.DialogueSystem;
using AutumnForest.Health;
using AutumnForest.Helpers;
using AutumnForest.Managers;
using AutumnForest.Player;
using AutumnForest.Projectiles;
using Cinemachine;
using UnityEngine;

namespace AutumnForest
{
    public sealed class GlobalServiceRegistrar : MonoBehaviour
    {
        [Header("Pool")]
        [SerializeField] private Projectile acorn;
        [SerializeField] private Projectile cone;
        [SerializeField] private AcornHeal acornHeal;
        [Header("Cameras")]
        [SerializeField] private CinemachineVirtualCamera mainCamera;
        [SerializeField] private CinemachineVirtualCamera bossfightCamera;
        [SerializeField] private CinemachineVirtualCamera dialogueCamera;
        [SerializeField] private CinemachineVirtualCamera slingshotCamera;
        [SerializeField] private CinemachineVirtualCamera houseCamera;
        [SerializeField] private CinemachineVirtualCamera basementCamera;
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
            RegisterDialogueServices();
            RegisterBossFightServices();

            GlobalServiceLocator.GetService<PlayerInput>().Enable();
        }

        private void RegisterPools()
        {
            GlobalServiceLocator.RegisterService(new SomePoolsContainer(acorn, cone, acornHeal));
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
            GlobalServiceLocator.RegisterService(new BossFightManager());
        }
    }
}
using AutumnForest.BossFight;
using AutumnForest.BossFight.Fox;
using AutumnForest.BossFight.Raccoon;
using AutumnForest.DialogueSystem;
using AutumnForest.Other;
using AutumnForest.Player;
using UnityEngine;
using UnityEngine.Events;

namespace AutumnForest
{
    public sealed class GameInit : MonoBehaviour
    {
        public UnityEvent OnInit = new();

        private void OnEnable()
        {
            RegisterPlayerServices();
            RegisterBossFightServices();
            RegisterDialogueServices();

            ServiceLocator.GetService<PlayerInput>().Enable();

            OnInit.Invoke();
        }

        private void RegisterPlayerServices()
        {
            ServiceLocator.RegisterService(FindObjectOfType<PlayerMovable>());
            ServiceLocator.RegisterService(FindObjectOfType<PlayerAttack>());
            ServiceLocator.RegisterService(FindObjectOfType<PlayerDash>());
            ServiceLocator.RegisterService(FindObjectOfType<PlayerFlipper>());
            ServiceLocator.RegisterService(FindObjectOfType<MainCameraBrain>());
            ServiceLocator.RegisterService(new PlayerInput());
        }
        private void RegisterDialogueServices()
        {
            ServiceLocator.RegisterService(FindObjectOfType<DialogueManager>());
        }
        private void RegisterBossFightServices()
        {
            ServiceLocator.RegisterService(FindObjectOfType<RaccoonStateMachine>());
            ServiceLocator.RegisterService(FindObjectOfType<BossFightController>());
            ServiceLocator.RegisterService(FindObjectOfType<FoxStateMachine>());
        }
    }
}
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

            GlobalServiceLocator.GetService<PlayerInput>().Enable();

            OnInit.Invoke();
        }

        private void RegisterPlayerServices()
        {
            GlobalServiceLocator.RegisterService(FindObjectOfType<PlayerMovable>());
            GlobalServiceLocator.RegisterService(FindObjectOfType<PlayerAttack>());
            GlobalServiceLocator.RegisterService(FindObjectOfType<PlayerDash>());
            GlobalServiceLocator.RegisterService(FindObjectOfType<PlayerFlipper>());
            GlobalServiceLocator.RegisterService(FindObjectOfType<MainCameraBrain>());
            GlobalServiceLocator.RegisterService(new PlayerInput());
        }
        private void RegisterDialogueServices()
        {
            GlobalServiceLocator.RegisterService(FindObjectOfType<DialogueManager>());
        }
        private void RegisterBossFightServices()
        {
            GlobalServiceLocator.RegisterService(FindObjectOfType<RaccoonStateMachine>());
            GlobalServiceLocator.RegisterService(FindObjectOfType<BossFightController>());
            GlobalServiceLocator.RegisterService(FindObjectOfType<FoxStateMachine>());
        }
    }
}
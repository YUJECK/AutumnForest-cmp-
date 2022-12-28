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
            //registering
            //boss fight services
            ServiceLocator.RegisterService(FindObjectOfType<RaccoonStateMachine>());
            ServiceLocator.RegisterService(FindObjectOfType<BossFightController>());
            ServiceLocator.RegisterService(FindObjectOfType<FoxStateMachine>());
            //player like components
            ServiceLocator.RegisterService(FindObjectOfType<MainCameraBrain>());
            ServiceLocator.RegisterService(FindObjectOfType<PlayerController>());
            ServiceLocator.RegisterService(new PlayerInput());
            //other managers
            ServiceLocator.RegisterService(FindObjectOfType<DialogueManager>());

            //doing something
            ServiceLocator.GetService<PlayerInput>().Enable();

            OnInit.Invoke();
        }
    }
}
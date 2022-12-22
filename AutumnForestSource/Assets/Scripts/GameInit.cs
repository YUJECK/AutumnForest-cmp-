using AutumnForest.BossFight;
using AutumnForest.BossFight.Fox;
using AutumnForest.BossFight.Raccoon;
using AutumnForest.DialogueSystem;
using AutumnForest.Other;
using AutumnForest.Player;
using UnityEngine;

namespace AutumnForest
{
    public class GameInit : MonoBehaviour
    {
        private void Awake()
        {
            //registering
            //boss fight services
            ServiceLocator.RegisterService(FindObjectOfType<RaccoonStateMachine>());
            ServiceLocator.RegisterService(FindObjectOfType<BossFightController>());
            ServiceLocator.RegisterService(FindObjectOfType<FoxStateMachine>());
            //player like components
            ServiceLocator.RegisterService(FindObjectOfType<MainCameraBrain>());
            ServiceLocator.RegisterService(FindObjectOfType<PlayerController>());
            ServiceLocator.RegisterService(FindObjectOfType<PlayerInput>());
            //other managers
            ServiceLocator.RegisterService(FindObjectOfType<DialogueManager>());
            
            //doing something
            ServiceLocator.GetService<FoxStateMachine>().gameObject.SetActive(false);
        }
    }
}
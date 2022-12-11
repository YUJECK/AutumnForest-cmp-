using UnityEngine;

namespace AutumnForest
{
    public class GameInit : MonoBehaviour
    {
        private void Awake()
        {
            ServiceLocator.RegisterService(FindObjectOfType<RaccoonStateMachine>());
            ServiceLocator.RegisterService(FindObjectOfType<FoxStateMachine>());
            ServiceLocator.RegisterService(FindObjectOfType<PlayerController>());
            ServiceLocator.RegisterService(FindObjectOfType<DialogueManager>());
            ServiceLocator.RegisterService(Camera.main);
        }
    }
}
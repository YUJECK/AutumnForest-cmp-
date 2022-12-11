using UnityEngine;

namespace AutumnForest
{
    public class GameInit : MonoBehaviour
    {
        private void Awake()
        {
            ServiceLocator.RegisterService(FindObjectOfType<RaccoonStateMachine>());
            ServiceLocator.RegisterService(FindObjectOfType<BossFightController>());
            ServiceLocator.RegisterService(FindObjectOfType<FoxStateMachine>());
            ServiceLocator.GetService<FoxStateMachine>().gameObject.SetActive(false);
            ServiceLocator.RegisterService(FindObjectOfType<PlayerController>());
            ServiceLocator.RegisterService(FindObjectOfType<DialogueManager>());
            ServiceLocator.RegisterService(Camera.main);
        }
    }
}
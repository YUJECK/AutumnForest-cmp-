using UnityEngine;

namespace AutumnForest
{
    public class EnteringToBossFight : OnTriggerEnterEvent
    {
        [SerializeField] private GameObject log;
        [SerializeField] private GameObject healthBar;

        protected override void OnEnterTrigger()
        {
            log.SetActive(true);
            healthBar.SetActive(true);
            ServiceLocator.GetService<Camera>().orthographicSize = 7;
            ServiceLocator.GetService<Camera>().GetComponent<MainCameraBrain>().SetTarget(ServiceLocator.GetService<RaccoonStateMachine>().gameObject);

            ServiceLocator.GetService<BossFightController>().StateChoosing();
        }
        private void Start()
        {
            log.SetActive(false);
            healthBar.SetActive(false);
        }
    }
}
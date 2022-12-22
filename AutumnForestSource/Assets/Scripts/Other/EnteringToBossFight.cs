using AutumnForest.BossFight;
using AutumnForest.BossFight.Raccoon;
using AutumnForest.Other;
using UnityEngine;

namespace AutumnForest
{
    public class EnteringToBossFight : OnTriggerEnterEvent
    {
        [SerializeField] private GameObject log;
        [SerializeField] private GameObject healthBar;

        private bool hasEntered = false;

        protected override void OnEnterTrigger()
        {
            log.SetActive(true);
            healthBar.SetActive(true);

            MainCameraBrain camera = ServiceLocator.GetService<MainCameraBrain>();
            camera.SetTargets(ServiceLocator.GetService<RaccoonStateMachine>().gameObject);
            camera.ChangeOrthographicSize(7);

            ServiceLocator.GetService<BossFightController>().StateChoosing();

            Destroy(this);            
        }
        private void Start()
        {
            log.SetActive(false);
            healthBar.SetActive(false);
        }
    }
}
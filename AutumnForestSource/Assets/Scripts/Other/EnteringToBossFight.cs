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
        }
        private void Start()
        {
            log.SetActive(false);
            healthBar.SetActive(false);
        }
    }
}
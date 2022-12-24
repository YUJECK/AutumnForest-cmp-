using AutumnForest.BossFight;
using AutumnForest.BossFight.Raccoon;
using AutumnForest.Other;
using UnityEngine;
using UnityEngine.Events;

namespace AutumnForest
{
    public class EnteringToBossFight : MonoBehaviour, IInteractive
    {
        [SerializeField] private GameObject log;
        [SerializeField] private GameObject healthBar;
        [SerializeField] private float cameraSizeOnBossFight = 7f;

        private UnityEvent onInteract = new();
        public UnityEvent OnInteract { get => onInteract; set => onInteract = value; }

        private void Start()
        {
            log.SetActive(false);
            healthBar.SetActive(false);
        }

        public void Interact()
        {
            log.SetActive(true);
            healthBar.SetActive(true);

            MainCameraBrain camera = ServiceLocator.GetService<MainCameraBrain>();

            camera.SetTargets(ServiceLocator.GetService<RaccoonStateMachine>().gameObject);
            camera.ChangeOrthographicSize(cameraSizeOnBossFight);

            ServiceLocator.GetService<BossFightController>().StateChoosing();

            Destroy(this);
        }

    }
}

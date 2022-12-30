using AutumnForest.BossFight;
using UnityEngine;

namespace AutumnForest.Other
{
    public class MusicManager : MonoBehaviour
    {
        //music objects
        [SerializeField] private GameObject mainTheme;
        [SerializeField] private GameObject bossTheme;

        private BossFightController fightController;

        //unity methods
        private void Awake() => fightController = FindObjectOfType<BossFightController>();
        private void Start()
        {
            fightController.StateMachine.OnMachineEnabled.AddListener(
                delegate { mainTheme.SetActive(false); bossTheme.SetActive(true); });
            fightController.StateMachine.OnMachineEnabled.AddListener(
                delegate { mainTheme.SetActive(true); bossTheme.SetActive(false); });
        }
    }
}
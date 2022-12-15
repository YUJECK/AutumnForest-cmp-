using System.Collections;
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
            fightController.OnMachineStarts.AddListener(
                delegate { mainTheme.SetActive(false); bossTheme.SetActive(true); });
            fightController.OnMachineStops.AddListener(
                delegate { mainTheme.SetActive(true); bossTheme.SetActive(false); });
        }
    }
}
using UnityEngine;

namespace AutumnForest
{
    public class MusicManager : MonoBehaviour
    {
        //music objects
        [SerializeField] private GameObject mainTheme;
        [SerializeField] private GameObject bossTheme;

        private MafiaFightController fightController;

        //unity methods
        private void Awake() => fightController = FindObjectOfType<MafiaFightController>();
        private void Start()
        {
            fightController.onBossFightBegins.AddListener(
                delegate { mainTheme.SetActive(false); bossTheme.SetActive(true); });
            fightController.onBossFightEnds.AddListener(
                delegate { mainTheme.SetActive(true); bossTheme.SetActive(false); });
        }
    }
}
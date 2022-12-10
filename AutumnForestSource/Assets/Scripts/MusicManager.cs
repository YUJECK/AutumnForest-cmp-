using UnityEngine;

namespace AutumnForest
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
            //fightController.OnBossFightBegins.AddListener(
            //    delegate { mainTheme.SetActive(false); bossTheme.SetActive(true); });
            //fightController.OnBossFightEnds.AddListener(
            //    delegate { mainTheme.SetActive(true); bossTheme.SetActive(false); });
        }
    }
}
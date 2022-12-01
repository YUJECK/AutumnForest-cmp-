using CreaturesAI;
using UnityEngine;
using UnityEngine.Events;

namespace AutumnForest
{
    public enum Stages
    {
        FirstStage,
        SecondStage,
        ThirdStage,
    }

    public class MafiaFightController : BossFightController
    {
        //variables
        private Stages currentStage = Stages.FirstStage;
        [SerializeField] private StateMachine raccoon;
        [SerializeField] private StateMachine fox;
        [SerializeField] private GameObject log;
        public UnityEvent<GameObject> OnBossChange = new UnityEvent<GameObject>();

        //getters
        public Stages CurrentStage => currentStage;

        //methods
        private void CheckHealth(int currentHealth, int maximumHealth)
        {
            if (currentHealth < 0.6 * maximumHealth && currentStage != Stages.SecondStage)
                EnterSecondStage();
            else if (currentHealth <= 0)
                EnterThirdStage();
        }
        public override void StartBossFight()
        {
            onBossFightBegins.Invoke();

            ObjectList.MainCamera.orthographicSize = 6f;
            log?.SetActive(true);

            EnterFirstStage();
        }
        private void EnterFirstStage()
        {
            OnBossChange.Invoke(raccoon.gameObject);
            raccoon.StateChoosing();
        }
        private void EnterSecondStage()
        {
            OnBossChange.Invoke(fox.gameObject);
            currentStage = Stages.SecondStage;
            raccoon.Health.onHealthChange.RemoveListener(CheckHealth);
            raccoon.StateChoosing();
            fox.gameObject.SetActive(true);
            fox.Health.onHealthChange.AddListener(CheckHealth);
            fox.StateChoosing();
        }
        private void EnterThirdStage()
        {
            OnBossChange.Invoke(raccoon.gameObject);
            currentStage = Stages.ThirdStage;
            fox.Health.onHealthChange.RemoveListener(CheckHealth);
            raccoon.Health.onHealthChange.AddListener(CheckHealth);
            raccoon.StateChoosing();
        }
        public override void EndBossFight()
        {
            onBossFightEnds.Invoke();
            ObjectList.MainCamera.orthographicSize = 3f;
            ObjectList.MainCamera.GetComponent<MainCameraBrain>().SetTarget(ObjectList.Player.gameObject);
            if (log != null) log.SetActive(false);
        }

        //unity methods
        private void Start()
        {
            raccoon.Health.onHealthChange.AddListener(CheckHealth);
            OnBossChange.AddListener(GameObject.FindGameObjectWithTag("MainCamera").GetComponent<MainCameraBrain>().SetTarget);
        }
    }
}
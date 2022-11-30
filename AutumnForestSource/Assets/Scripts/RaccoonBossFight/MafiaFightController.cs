using CreaturesAI;
using System.Net.NetworkInformation;
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
            Following cameraFollowing = ObjectList.MainCamera.GetComponent<Following>();

            cameraFollowing.SetTarget(raccoon.gameObject);
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
        }
        public override void EndBossFight()
        {
            onBossFightEnds.Invoke();
            ObjectList.MainCamera.orthographicSize = 3f;
            Following cameraFollowing = ObjectList.MainCamera.GetComponent<Following>();

            if (cameraFollowing != null && raccoon != null)
                cameraFollowing.SetTarget(ObjectList.Player.gameObject);
            else Debug.LogError("Following script doesnt set to camera");
            if (log != null) log.SetActive(false);
        }

        //unity methods
        private void Start() => raccoon.Health.onHealthChange.AddListener(CheckHealth);
    }
}
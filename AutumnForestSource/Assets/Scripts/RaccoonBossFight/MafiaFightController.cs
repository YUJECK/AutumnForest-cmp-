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
        private Stages currentStage = Stages.FirstStage;
        [SerializeField] private GameObject raccoon;
        [SerializeField] private GameObject fox;
        [SerializeField] private GameObject log;
        public UnityEvent<GameObject> OnBossChange = new UnityEvent<GameObject>();

        public Stages CurrentStage => currentStage;

        //methods
        private void CheckHealth(int currentHealth, int maximumHealth)
        {
            if (currentHealth < 0.6 * maximumHealth && currentStage != Stages.SecondStage)
                EnterSecondState();
            else if (currentHealth <= 0)
                EnterThirdState();        
        }
        public override void StartBossFight()
        {
            onBossFightBegins.Invoke();
            ObjectList.MainCamera.orthographicSize = 6f;
            Following cameraFollowing = ObjectList.MainCamera.GetComponent<Following>();

            if (cameraFollowing != null && raccoon != null)
                cameraFollowing.followTarget = raccoon;
            else Debug.LogError("Following script doesnt set to camera");
            if (log != null) log.SetActive(true);
        }
        private void EnterSecondState()
        {
            OnBossChange.Invoke(fox);
            currentStage = Stages.SecondStage;
            raccoon.GetComponent<Health>().onHealthChange.RemoveListener(CheckHealth);
            fox.GetComponent<Health>().onHealthChange.AddListener(CheckHealth);
        }
        private void EnterThirdState()
        {
            OnBossChange.Invoke(raccoon);
            currentStage = Stages.ThirdStage;
            fox.GetComponent<Health>().onHealthChange.RemoveListener(CheckHealth);
            raccoon.GetComponent<Health>().onHealthChange.AddListener(CheckHealth);
        }
        public override void EndBossFight()
        {
            onBossFightEnds.Invoke();
            ObjectList.MainCamera.orthographicSize = 3f;
            Following cameraFollowing = ObjectList.MainCamera.GetComponent<Following>();

            if (cameraFollowing != null && raccoon != null)
                cameraFollowing.followTarget = ObjectList.Player.gameObject;
            else Debug.LogError("Following script doesnt set to camera");
            if (log != null) log.SetActive(false);
        }

        //unity methods
        private void Start() 
        {
            raccoon.GetComponent<StateMachine>().Health.onHealthChange.AddListener(CheckHealth);
            OnBossChange.Invoke(raccoon); 
        }
    }
}
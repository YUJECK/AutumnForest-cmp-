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

    public class BossFightController : MonoBehaviour
    {
        //events
        public UnityEvent OnBossFightBegins = new UnityEvent();
        public UnityEvent OnBossFightEnds = new UnityEvent();
        //variables
        private Stages currentStage = Stages.FirstStage;
        private StateMachine raccoon;
        private StateMachine fox;
        private GameObject log;
        private GameObject familyInteractiveField;
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
        public void StartBossFight()
        {
            OnBossFightBegins.Invoke();

            ObjectList.MainCamera.orthographicSize = 6f;
            log?.SetActive(true);
            raccoon.Health.onHealthChange.AddListener(CheckHealth);

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
        public void EndBossFight()
        {
            OnBossFightEnds.Invoke();
            ObjectList.MainCamera.orthographicSize = 3f;
            ObjectList.MainCamera.GetComponent<MainCameraBrain>().SetTarget(ObjectList.Player.gameObject);
            if (log != null) log.SetActive(false);
        }

        //unity methods
        private void Awake()
        {
            //init some fields
            raccoon = GameObject.FindGameObjectWithTag(TagHelper.RaccoonTag).GetComponent<StateMachine>();
            fox = GameObject.FindGameObjectWithTag(TagHelper.FoxTag).GetComponent<StateMachine>();
            log = GameObject.FindGameObjectWithTag(TagHelper.Log);
            familyInteractiveField = GameObject.FindGameObjectWithTag(TagHelper.FamilyFieldTag);
            //disableing some gameobjects 
            fox.gameObject.SetActive(false);
            log.SetActive(false);
            familyInteractiveField.SetActive(false);
            //adding events
            OnBossFightEnds.AddListener(delegate { familyInteractiveField.SetActive(true); });
        }
    }
}
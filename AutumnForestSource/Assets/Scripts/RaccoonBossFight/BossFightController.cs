using CreaturesAI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

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
        private StateMachine currentBoss;
        private GameObject currentHealthBar;
        private StateMachine raccoon;
        private StateMachine fox;
        [SerializeField] private GameObject raccoonHealthBar;
        [SerializeField] private GameObject foxHealthBar;
        private GameObject familyInteractiveField;
        private GameObject log;
        public UnityEvent<GameObject> OnBossChange = new UnityEvent<GameObject>();
        //getters
        public Stages CurrentStage => currentStage;

        //methods
        private void ChangeBoss(StateMachine newBoss, GameObject newHealthBar)
        {
            if(currentBoss != null) currentBoss.Health.onHealthChange.RemoveListener(CheckHealth);
            if (!newBoss.gameObject.active) newBoss.gameObject.SetActive(true);
            newBoss.Health.onHealthChange.AddListener(CheckHealth);
            currentBoss = newBoss;
            if (currentHealthBar != null) currentHealthBar.SetActive(false);
            newHealthBar.SetActive(true);
            currentHealthBar = newHealthBar;
           
            OnBossChange.Invoke(currentBoss.gameObject);
        }
        private void CheckHealth(int currentHealth, int maximumHealth)
        {
            if (currentHealth < 0.6 * maximumHealth && currentStage == Stages.FirstStage)
                EnterSecondStage();
            else if (currentHealth <= 0 && currentStage == Stages.SecondStage)
                EnterThirdStage();
        }
        public void StartBossFight()
        {
            OnBossFightBegins.Invoke();
            ObjectList.MainCamera.orthographicSize = 6f;
            log?.SetActive(true);

            EnterFirstStage();
        }
        private void EnterFirstStage()
        {
            currentStage = Stages.FirstStage;
            ChangeBoss(raccoon, raccoonHealthBar);
            currentBoss.StateChoosing();
        }
        private void EnterSecondStage()
        {
            currentStage = Stages.SecondStage;
            ChangeBoss(fox, foxHealthBar);
            currentBoss.StateChoosing();
        }
        private void EnterThirdStage()
        {
            currentStage = Stages.ThirdStage;
            ChangeBoss(raccoon, raccoonHealthBar);
            currentBoss.StateChoosing();
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
            raccoon.Health.onDie.AddListener(EndBossFight);
        }
    }
}
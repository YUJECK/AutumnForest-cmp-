using AutumnForest.EditorScripts;
using AutumnForest.StateMachineSystem;
using CreaturesAI.CombatSkills;
using CreaturesAI.Health;
using System;
using UnityEngine;

namespace AutumnForest.BossFight.Raccoon
{
    public class RaccoonStateMachineUser : MonoBehaviour, IStateMachineUser
    {
        [Header("Services")]
        [SerializeField] private CreatureAnimator creatureAnimator;
        [SerializeField] private Shooting shooting;
        [SerializeField, Interface(typeof(IHealth))] private UnityEngine.Object healthObject;
        
        private BossFightManager bossFightManager;
        private RaccoonStatesContainer raccoonStatesContainer;

        public event Action<StateBehaviour> OnStateChanged;
        public StateMachine StateMachine { get; private set; }
        public LocalServiceLocator ServiceLocator { get; private set; }


        private void Awake()
        {
            ServiceLocator = new(creatureAnimator, shooting, (IHealth)healthObject);
            raccoonStatesContainer = GetComponent<IStateContainerVariator>().InitStates() as RaccoonStatesContainer; 

            StateMachine = new(this, false);
            StateMachine.OnMachineWorking += StateChoosing;

            bossFightManager = GlobalServiceLocator.GetService<BossFightManager>();
        }
        private void OnEnable()
        {
            bossFightManager.OnBossFightStarted += StateMachine.EnableStateMachine;
            StateMachine.OnMachineWorking += StateChoosing;
        }
        private void OnDisable()
        {
            bossFightManager.OnBossFightStarted -= StateMachine.EnableStateMachine;
            StateMachine.OnMachineWorking -= StateChoosing;
        }

        private void StateChoosing()
        {
            StateBehaviour nextState = null;

            if (bossFightManager.CurrentStage == BossFightStage.First)
                nextState = FirstStageChoosing();
            else if (bossFightManager.CurrentStage == BossFightStage.Second)
                nextState = SecondStageChoosing();
            else if (bossFightManager.CurrentStage == BossFightStage.Third)
                nextState = ThirdStageChoosing();

            //тут должны еще быть разные проверки
            if(nextState != null)
                OnStateChanged?.Invoke(nextState);
        }

        private StateBehaviour ThirdStageChoosing()
        {
            throw new NotImplementedException("что же не так");
        }

        private StateBehaviour SecondStageChoosing()
        {
            throw new NotImplementedException("что же не так");
        }

        private StateBehaviour FirstStageChoosing()
        {
            return raccoonStatesContainer.ConeRoundShotState;
        }
    }
}
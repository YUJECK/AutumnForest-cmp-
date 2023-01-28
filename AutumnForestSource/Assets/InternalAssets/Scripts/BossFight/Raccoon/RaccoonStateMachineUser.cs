using AutumnForest.EditorScripts;
using AutumnForest.StateMachineSystem;
using CreaturesAI.CombatSkills;
using AutumnForest.Health;
using System;
using UnityEngine;

namespace AutumnForest.BossFight.Raccoon
{
    [RequireComponent(typeof(IStateContainerVariator))]
    public class RaccoonStateMachineUser : MonoBehaviour, IStateMachineUser
    {
        [Header("Services")]
        [SerializeField] private CreatureAnimator creatureAnimator;
        [SerializeField] private Shooting shooting;
        [SerializeField] private CreatureHealth healthObject;
        
        private BossFightManager bossFightManager;
        private RaccoonStatesContainer raccoonStatesContainer;

        public event Action<StateBehaviour> OnStateChanged;
        public StateMachine StateMachine { get; private set; }
        public LocalServiceLocator ServiceLocator { get; private set; }


        private void Awake()
        {
            ServiceLocator = new(creatureAnimator, shooting, healthObject);
            raccoonStatesContainer = GetComponent<IStateContainerVariator>().InitStates() as RaccoonStatesContainer;

            StateMachine = new(this, false);
            StateMachine.OnMachineWorking += StateChoosing;
        }
        private void Start()
        {
            bossFightManager = GlobalServiceLocator.GetService<BossFightManager>();
        }
        private void OnEnable()
        {
            StateMachine.OnMachineWorking += StateChoosing;
        }
        private void OnDisable()
        {
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
            OnStateChanged?.Invoke(raccoonStatesContainer.IdleState);
            throw new NotImplementedException("что же не так. ведь какой-то коля точно сделал метод для выбора состояний третьей стадии, как и сами состояния");
        }

        private StateBehaviour SecondStageChoosing()
        {
            OnStateChanged?.Invoke(raccoonStatesContainer.IdleState);
            throw new NotImplementedException("что же не так. ведь какой-то коля точно сделал метод для выбора состояний второй стадии, как и сами состояния");
        }

        private StateBehaviour FirstStageChoosing()
        {
            return raccoonStatesContainer.ConeRoundShotState;
        }
    }
}
using AutumnForest.Health;
using AutumnForest.Projectiles;
using AutumnForest.StateMachineSystem;
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
        [SerializeField] private SpawnPlace pointContainer;

        private BossFightManager bossFightManager;
        private RaccoonStatesContainer raccoonStatesContainer;

        public event Action<StateBehaviour> OnStateChanged;
        public StateMachine StateMachine { get; private set; }
        public LocalServiceLocator ServiceLocator { get; private set; }

        private bool isStart = true;

        private void Awake()
        {
            ServiceLocator = new(creatureAnimator, shooting, healthObject, pointContainer, transform);
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

            //тут мб должны еще быть разные проверки
            if (nextState != null)
                OnStateChanged?.Invoke(nextState);
        }

        private StateBehaviour FirstStageChoosing()
        {
            StateBehaviour nextState = raccoonStatesContainer.IdleState;

            if (isStart)
            {
                isStart = false;
                return raccoonStatesContainer.DialogueState;
            }

            switch (UnityEngine.Random.Range(0, 2))
            {
                case 0:
                    nextState = raccoonStatesContainer.ConeRoundShotState;
                    break;
                case 1:
                    nextState = raccoonStatesContainer.DefaultSquirrelSpawnState;
                    break;
            }

            return nextState;
        }
        private StateBehaviour SecondStageChoosing()
        {
            OnStateChanged?.Invoke(raccoonStatesContainer.ConeRoundShotState);
            throw new NotImplementedException("что же не так. ведь какой-то коля точно сделал метод для выбора состояний второй стадии, как и сами состояния");
        }
        private StateBehaviour ThirdStageChoosing()
        {
            OnStateChanged?.Invoke(raccoonStatesContainer.DefaultSquirrelSpawnState);
            throw new NotImplementedException("что же не так. ведь какой-то коля точно сделал метод для выбора состояний третьей стадии, как и сами состояния");
        }
    }
}
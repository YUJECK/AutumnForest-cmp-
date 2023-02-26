using AutumnForest.Health;
using AutumnForest.Helpers;
using AutumnForest.Projectiles;
using AutumnForest.StateMachineSystem;
using Cysharp.Threading.Tasks;
using System;
using UnityEngine;

namespace AutumnForest.BossFight.Raccoon
{
    [RequireComponent(typeof(IStateContainerVariator))]
    [RequireComponent(typeof(RaccoonSoudsHelper))]
    public class RaccoonStateMachineUser : MonoBehaviour, IStateMachineUser
    {
        [Header("Services")]
        [SerializeField] private Animator animator;
        [SerializeField] private Shooting shooting;
        [SerializeField] private CreatureHealth healthObject;
        [SerializeField] private RaccoonSoudsHelper raccoonSouds;
        [SerializeField] private SpawnPlace spawnPlace;

        private BossFightManager bossFightManager;
        private RaccoonStatesContainer raccoonStatesContainer;

        public event Action OnEnteredHealingState;

        public event Action<StateBehaviour> OnStateChanged;
        public StateMachine StateMachine { get; private set; }
        public LocalServiceLocator ServiceLocator { get; private set; }

        private bool isStart = true;

        private void Awake()
        {
            ServiceLocator = new(new RaccoonAnimator(animator), shooting, healthObject, spawnPlace, raccoonSouds, transform);
            raccoonStatesContainer = GetComponent<IStateContainerVariator>().InitStates() as RaccoonStatesContainer;

            StateMachine = new(this, false);
            StateMachine.OnMachineWorking += StateChoosing;
        }
        private void Start() => bossFightManager = GlobalServiceLocator.GetService<BossFightManager>();
        private void OnEnable()
        {
            StateMachine.OnMachineWorking += StateChoosing;
            healthObject.OnDied += OnDied;
        }
        private void OnDisable()
        {
            healthObject.OnDied -= OnDied;

            StateMachine.OnMachineWorking -= StateChoosing;
            StateMachine.DisableStateMachine();
        }

        private void StateChoosing()
        {
            StateBehaviour nextState = null;

            if (bossFightManager.CurrentStage == BossFightStage.First) nextState = FirstStageChoosing();
            else if (bossFightManager.CurrentStage == BossFightStage.Second) nextState = SecondStageChoosing();
            else if (bossFightManager.CurrentStage == BossFightStage.Third) nextState = ThirdStageChoosing();

            if (nextState != null) OnStateChanged?.Invoke(nextState);
        }

        private StateBehaviour FirstStageChoosing()
        {
            if (isStart)
            {
                isStart = false;
                return raccoonStatesContainer.DialogueState;
            }

            return ObjectRandomizer.GetRandom(raccoonStatesContainer.FirstStageStates);
        }
        private StateBehaviour SecondStageChoosing() => raccoonStatesContainer.HealingState;
        private StateBehaviour ThirdStageChoosing() => ObjectRandomizer.GetRandom(raccoonStatesContainer.ThirdStageStates);
        
        public void HealingStateEntered() => OnEnteredHealingState?.Invoke();
        public async void OnDied()
        {
            ServiceLocator.GetService<RaccoonAnimator>().PlayJump();

            await UniTask.Delay(TimeSpan.FromSeconds(0.3f));

            gameObject.SetActive(false);
        }
    }
}
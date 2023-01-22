using AutumnForest.Editor;
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

        public StateMachine StateMachine { get; private set; }
        public LocalServiceLocator ServiceLocator { get; private set; }

        public event Action<StateBehaviour> OnStateChanged;

        private void Awake()
        {
            //нужно прописать сервисы
            ServiceLocator = new(creatureAnimator, shooting, (IHealth)healthObject);
            StateMachine = new(this, false);
        }
        private void OnEnable()
        {
            //StateMachine.OnMachineWorking += StateChoosing;
        }
        private void OnDisable()
        {
            //StateMachine.OnMachineWorking -= StateChoosing;
        }

        private void StateChoosing()
        {
            //первая стадия
            if (BossFightManager.CurrentStage == BossFightStage.First)
                FirstStageChoosing();
            else if (BossFightManager.CurrentStage == BossFightStage.Second)
                SecondStageChoosing();
            else if (BossFightManager.CurrentStage == BossFightStage.Third)
                ThirdStageChoosing();
            //третья стадия
        }

        private void ThirdStageChoosing()
        {

        }

        private void SecondStageChoosing()
        {

        }

        private void FirstStageChoosing()
        {

        }
    }
}
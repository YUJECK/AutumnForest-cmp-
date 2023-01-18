using AutumnForest.DialogueSystem;
using AutumnForest.StateMachineSystem;
using CreaturesAI.CombatSkills;
using CreaturesAI.Health;
using UnityEngine;

namespace AutumnForest.BossFight.Raccoon
{
    public partial class RaccoonStateMachine
    {
        [System.Serializable]
        private class RaccoonComponents 
        {
            [SerializeField] private Shooting shooting;
            [SerializeField] private Dialogue dialogue;
            [SerializeField] private Health health;
            [SerializeField] private CreatureAnimator animator;

            public void RegisterComponents(CreatureServiceLocator serviceLocator)
            {
                serviceLocator.RegisterService(shooting);
                serviceLocator.RegisterService(dialogue);
                serviceLocator.RegisterService(health);
                serviceLocator.RegisterService(animator);
            }
        }
    }
}
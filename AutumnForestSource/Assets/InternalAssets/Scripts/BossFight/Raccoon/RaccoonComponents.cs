using AutumnForest.DialogueSystem;
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

            public Shooting Shooting => shooting;
            public Dialogue Dialogue => dialogue;
            public Health Health => health;
            public CreatureAnimator Animator => animator;
        }
    }
}
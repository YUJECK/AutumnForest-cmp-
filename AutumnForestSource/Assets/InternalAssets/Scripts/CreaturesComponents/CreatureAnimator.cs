using AutumnForest.Helpers;
using System;
using UnityEngine;

namespace AutumnForest
{
    [RequireComponent(typeof(Animator))]
    public class CreatureAnimator : MonoBehaviour, ICreatureComponent
    {
        [SerializeField] private string defaultAnimation = "Idle";
        private string currentAnimation = "";
        private Animator animator;

        private void Awake()
        {
            animator = GetComponent<Animator>();
            SetDefault();
        }

        public void SetDefault() => PlayAnimation(defaultAnimation);
        public void PlayAnimation(string animation)
        {
            if(animation == "")
                throw new NotImplementedException(nameof(defaultAnimation));

            if (currentAnimation != animation)
                animator.Play(animation);
        }
    }
}
using System;
using UnityEngine;

namespace AutumnForest.BossFight.Squirrels
{
    [RequireComponent(typeof(FireSquirrel))]
    public sealed class FireSquirrelAnimator : MonoBehaviour
    {
        [SerializeField] private Animator squirrelAnimator;
        [SerializeField] private Animator firePlaceAnimator;
        [SerializeField] private FireSquirrel fireSquirrel;

        private void Awake()
        {
            if (squirrelAnimator == null) throw new NullReferenceException(nameof(squirrelAnimator));
            if (firePlaceAnimator == null) throw new NullReferenceException(nameof(firePlaceAnimator));
        }

        private void OnEnable()
        {
            fireSquirrel.FirePlace.OnCasted += OnCasted;
        }
        private void OnDisable()
        {
            fireSquirrel.FirePlace.OnCasted += OnCasted;
        }

        private void OnCasted()
        {
            squirrelAnimator.Play("Cast");
            firePlaceAnimator.Play("Cast");
        }
    }
}
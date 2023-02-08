using Cysharp.Threading.Tasks;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace AutumnForest.BossFight.Squirrels
{
    [RequireComponent(typeof(FireSquirrel))]
    public sealed class FireSquirrelAnimator : MonoBehaviour
    {
        [SerializeField] private Animator squirrelAnimator;
        [SerializeField] private Image field;
        [SerializeField] private FireSquirrel fireSquirrel;

        private void Awake()
        {
            if (squirrelAnimator == null)
                throw new NullReferenceException(nameof(squirrelAnimator));
        }

        private void OnEnable() => fireSquirrel.FirePlace.OnCasted += OnCasted;
        private void OnDisable() => fireSquirrel.FirePlace.OnCasted += OnCasted;

        private void OnCasted()
        {
            squirrelAnimator.Play("Cast");
            FieldFilling();
        }

        private async void FieldFilling()
        {
            float startTime = Time.time;
            float addValue = 1 / fireSquirrel.CastRate;

            field.fillAmount = 0;

            while (Time.time <= startTime + fireSquirrel.CastRate)
            {
                field.fillAmount += addValue;
                await UniTask.Delay(TimeSpan.FromSeconds(1));
            }
        }
    }
}
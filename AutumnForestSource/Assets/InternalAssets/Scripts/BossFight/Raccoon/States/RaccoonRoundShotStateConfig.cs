using System;
using UnityEngine;

namespace AutumnForest
{
    [CreateAssetMenu(fileName = "New " + nameof(RaccoonRoundShotStateConfig), menuName = AsstetMenuHelper.BossFight_StatesConfigs + nameof(RaccoonRoundShotStateConfig))]
    public sealed class RaccoonRoundShotStateConfig : ScriptableObject
    {
        [field: SerializeField] public int ConeCountPerCycle { get; private set; } = 16;
        [field: SerializeField] public int Cycles { get; private set; } = 3;
        [SerializeField] public float throwRate = 0.1f; 

        public int TotalConeCount => Cycles * ConeCountPerCycle;
        public TimeSpan ThrowRate => TimeSpan.FromSeconds(throwRate);
    }
}
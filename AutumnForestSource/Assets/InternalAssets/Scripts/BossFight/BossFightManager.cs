using System;
using UnityEngine;
using UnityEngine.Events;

namespace AutumnForest.BossFight
{
    public enum BossFightStage
    {
        NotStarted,
        First,
        Second,
        Third
    }

    public class BossFightManager
    {
        public BossFightStage CurrentStage { get; private set; } = BossFightStage.NotStarted;

        public event Action<BossFightStage> OnStageChanged;

        public event Action OnBossFightStarted;
        public event Action OnBossFightEnded;
        public UnityEvent test;

        public void StartBossFight() { OnBossFightStarted?.Invoke(); CurrentStage = BossFightStage.First; }
        public void EndBossFight() => OnBossFightEnded?.Invoke();
    }
}
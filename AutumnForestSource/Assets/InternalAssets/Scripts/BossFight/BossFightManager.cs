using System;

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

        public void StartBossFight() { CurrentStage = BossFightStage.First; OnBossFightStarted?.Invoke(); }
        public void EndBossFight() => OnBossFightEnded?.Invoke();
    }
}
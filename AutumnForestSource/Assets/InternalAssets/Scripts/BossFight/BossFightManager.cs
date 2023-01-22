using System;

namespace AutumnForest.BossFight
{
    public enum BossFightStage
    {
        First,
        Second,
        Third
    }

    public static class BossFightManager
    {
        public static BossFightStage CurrentStage { get; private set; } = BossFightStage.First;
        public static event Action OnBossFightStarts;

        public static void StartBossFight()
        {
            //многа кода(а может и мало)
            OnBossFightStarts?.Invoke();
        }

        //реализовать смену стадий
    }
}
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
        public static BossFightStage CurrentStage { get; private set; }

        //реализовать смену стадий
    }
}
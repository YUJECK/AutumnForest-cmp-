using AutumnForest.Health;

namespace AutumnForest.Helpers
{
    public class HealthBarHelper
    {
        public static BossFightHealthBar BossHealthBar { get; private set; }
        public static BossFightHealthBar PlayerHealthBar { get; private set; }
        
        public HealthBarHelper(BossFightHealthBar bossHealthBar, BossFightHealthBar playerHealthBar)
        {
            BossHealthBar = bossHealthBar;
            PlayerHealthBar = playerHealthBar;
        }
    }
}   
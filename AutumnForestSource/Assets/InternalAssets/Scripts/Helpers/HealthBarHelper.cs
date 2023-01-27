using AutumnForest.Health;

namespace AutumnForest.Helpers
{
    public class HealthBarHelper
    {
        public static HealthBar BossHealthBar { get; private set; }
        public static HealthBar PlayerHealthBar { get; private set; }
        
        public HealthBarHelper(HealthBar bossHealthBar, HealthBar playerHealthBar)
        {
            BossHealthBar = bossHealthBar;
            PlayerHealthBar = playerHealthBar;
        }
    }
}   
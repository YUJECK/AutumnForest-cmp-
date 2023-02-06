using System;

namespace AutumnForest.Health
{
    public interface IHealth
    {
        BossFightHealthBarConfig HealthBarConfig { get; }

        int CurrentHealth { get; }
        int MaximumHealth { get; }

        event Action<int, int> OnHealthChanged;
        event Action<int, int> OnHealed;
        event Action<int, int> OnTakeHit;

        event Action OnDied;

        void TakeHit(int damagePoints);
        void Heal(int healPoints);
    }
}
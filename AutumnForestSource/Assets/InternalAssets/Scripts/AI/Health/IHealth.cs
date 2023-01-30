using System;

namespace AutumnForest.Health
{
    public interface IHealth
    {
        HealthBarConfig HealthBarConfig { get; }

        int CurrentHealth { get; }
        int MaximumHealth { get; }

        event Action<int, int> OnHealthChange;
        event Action<int, int> OnHeal;
        event Action<int, int> OnTakeHit;

        event Action OnDie;

        void TakeHit(int damagePoints);
        void Heal(int healPoints);
    }
}
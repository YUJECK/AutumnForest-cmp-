using System;

namespace CreaturesAI.Health
{
    public interface IHealth
    {
        int CurrentHealth { get; }
        int MaximumHealth { get; }

        event Action<int, int> OnHealthChange;
        event Action<int, int> OnHeal;
        event Action<int, int> OnTakeHit;
        event Action OnDie;

        //abstract methods
        void TakeHit(int damagePoints);
        void Heal(int healPoints);
        void DecreaseMaximumHealth(int damagePoints);
        void IncreaseMaximumHealth(int healPoints);
    }
}
using AutumnForest.Health;
using Cysharp.Threading.Tasks;
using System;
using System.Threading;
using UnityEngine;

namespace AutumnForest.Player
{
    public class PlayerHealth : MonoBehaviour, IHealth, IFireable
    {
        [field: SerializeField] public HealthBarConfig HealthBarConfig { get; private set; }

        //здесь можно было добавить всякие проверки в сеттер этого свойства, но мне было лень
        //и поэтому я чисто их прикостылил в методы ниже
        //да и по сути впринципи можно было бы обойтись чисто сеттером, без методов ниже
        //думаю так было бы гораздо удобнее /:
        //но нет, я пишу эти комменты вместо того чтобы написать этот сеттер\

        [field: SerializeField] public int CurrentHealth { get; private set; }
        [field: SerializeField] public int MaximumHealth { get; private set; }

        public bool Fired { get; private set; }

        public event Action<int, int> OnHealthChange;
        public event Action<int, int> OnHeal;
        public event Action<int, int> OnTakeHit;
        public event Action OnDie;

        public void Heal(int healPoints)
        {
            CurrentHealth += healPoints;

            OnHeal?.Invoke(CurrentHealth, MaximumHealth);
            OnHealthChange?.Invoke(CurrentHealth, MaximumHealth);

            if (CurrentHealth > MaximumHealth)
                CurrentHealth = MaximumHealth;
        }
        public void TakeHit(int damagePoints)
        {
            CurrentHealth -= damagePoints;

            OnTakeHit?.Invoke(CurrentHealth, MaximumHealth);
            OnHealthChange?.Invoke(CurrentHealth, MaximumHealth);

            if (CurrentHealth <= 0)
            {
                OnDie?.Invoke();
                //GameManager.Restart();
            }
        }

        public async void Fire()
        {
            if (Fired) return;

            Fired = true;
            {
                for (int i = 0; i < 5; i++)
                {
                    TakeHit(2);
                    await UniTask.Delay(TimeSpan.FromSeconds(1f));
                }
            }
            Fired = false;
        }
    }
}
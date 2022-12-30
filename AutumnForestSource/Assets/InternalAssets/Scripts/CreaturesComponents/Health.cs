using AutumnForest.Helpers;
using UnityEngine;
using UnityEngine.Events;

namespace CreaturesAI.Health
{
    public abstract class Health : MonoBehaviour, ICreatureComponent
    {
        //health indicators
        [SerializeField] protected int currentHealth = 60;
        [SerializeField] protected int maximumHealth = 60;
        [Space]
        //events
        public UnityEvent<int, int> OnHealthChange = new UnityEvent<int, int>();
        public UnityEvent<int, int> OnHeal = new UnityEvent<int, int>();
        public UnityEvent<int, int> OnTakeHit = new UnityEvent<int, int>();
        public UnityEvent OnDie = new UnityEvent();
        //getters
        public int CurrentHealth => currentHealth;
        public int MaximumHealth => maximumHealth;

        //abstract methods
        public abstract void TakeHit(int damagePoints);
        public abstract void Heal(int healPoints);
        public abstract void DecreaseMaximumHealth(int damagePoints);
        public abstract void IncreaseMaximumHealth(int healPoints);
    }
}
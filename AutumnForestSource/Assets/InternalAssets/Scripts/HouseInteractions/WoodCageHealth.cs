﻿using AutumnForest.Health;
using System;
using UnityEngine;

namespace AutumnForest.HouseInteractions
{
    public sealed class WoodCageHealth : MonoBehaviour, IHealth
    {
        [SerializeField] private GameObject family;
        [SerializeField] private AudioSource destroySound; 

        public int CurrentHealth { get; private set; }
        public int MaximumHealth { get; private set; }

        public event Action<int, int> OnHealthChanged;
        public event Action<int, int> OnHealed;
        public event Action<int, int> OnTakeHit;
        public event Action OnDied;


        public void Heal(int healPoints) => OnHealed?.Invoke(CurrentHealth, MaximumHealth); 
        public void TakeHit(int damagePoints)
        {
            CurrentHealth -= damagePoints;
            OnTakeHit?.Invoke(CurrentHealth, MaximumHealth);
            OnHealthChanged?.Invoke(CurrentHealth, MaximumHealth);

            if (CurrentHealth < MaximumHealth) 
                Die();
        }

        private async void Die()
        {
            OnDied?.Invoke();
            destroySound.Play();

            await GlobalServiceLocator.GetService<BlackoutTransition>().StartBlackout();

            Destroy(gameObject);
            family.SetActive(true);
        }
    }
}
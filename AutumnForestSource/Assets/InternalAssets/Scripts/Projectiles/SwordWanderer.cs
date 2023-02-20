using AutumnForest.Health;
using AutumnForest.Other;
using AutumnForest.Projectiles;
using System;
using UnityEngine;

namespace AutumnForest
{
    [RequireComponent(typeof(Projectile))]
    [RequireComponent(typeof(MonoRotator))]
    public class SwordWanderer : MonoBehaviour, IHealth
    {
        [SerializeField] private float speed = 1;
        
        private bool stopped;
        
        private new Rigidbody2D rigidbody2D;
        private MonoRotator monoRotator;

        public int CurrentHealth => 999;
        public int MaximumHealth => 999;

        public event Action<int, int> OnHealthChanged;
        public event Action<int, int> OnHealed;
        public event Action<int, int> OnTakeHit;
        public event Action OnDied;

        public void Heal(int healPoints) { }
        public void TakeHit(int damagePoints)
        {
            monoRotator.TransfromRotation.Disable();
            stopped = true;
            transform.Rotate(new Vector3(0, 0, 180));
            rigidbody2D.velocity = transform.up * 10;
        }

        private void Awake()
        {
            rigidbody2D = GetComponent<Rigidbody2D>();
            monoRotator = GetComponent<MonoRotator>();
        }
        private void FixedUpdate()
        {
            if(!stopped)
                Move();
        }
        
        
        private void Move()
        {
            rigidbody2D.velocity = transform.up * speed;
        }
    }
}
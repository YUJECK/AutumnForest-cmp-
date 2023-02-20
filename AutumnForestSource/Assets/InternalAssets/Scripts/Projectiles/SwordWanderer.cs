using AutumnForest.Health;
using AutumnForest.Other;
using AutumnForest.Projectiles;
using System;
using UnityEngine;

namespace AutumnForest
{
    [RequireComponent(typeof(Projectile))]
    [RequireComponent(typeof(MonoRotator))]
    public class SwordWanderer : MonoBehaviour, IHealth, IDisablable
    {
        [SerializeField] private float _minimumSpeed = 1.8f;
        [SerializeField] private float _maximumSpeed = 2.2f;

        private float _speed;
        
        private bool _stopped;
        
        private Rigidbody2D _rigidbody2D;
        private MonoRotator _monoRotator;

        public int CurrentHealth => 999;
        public int MaximumHealth => 999;

        public bool Enabled { get; private set; }

        public event Action<int, int> OnHealthChanged;
        public event Action<int, int> OnHealed;
        public event Action<int, int> OnTakeHit;
        public event Action OnDied;

        public event Action OnEnabled;
        public event Action OnDisabled;

        public void Disable()
        {
            _monoRotator.TransfromRotation.Disable();
            _stopped = true;
        }
        public void Enable()
        {
            _monoRotator.TransfromRotation.Enable();
            _stopped = false;
        }

        public void Heal(int healPoints) { }
        public void TakeHit(int damagePoints)
        {
            _monoRotator.TransfromRotation.Disable();
            _stopped = true;
            transform.Rotate(new Vector3(0, 0, 180));
            _rigidbody2D.velocity = transform.up * 10;
        }

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _monoRotator = GetComponent<MonoRotator>();

            SetSpeed();

            Disable();
        }
        private void FixedUpdate()
        {
            if(!_stopped)
                Move();
        }
        
        private void SetSpeed() => _speed = UnityEngine.Random.Range(_minimumSpeed, _maximumSpeed);
        private void Move() => _rigidbody2D.velocity = transform.up * _minimumSpeed;
    }
}
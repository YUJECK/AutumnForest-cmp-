using AutumnForest.Health;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace AutumnForest
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(IHealth))]
    public sealed class SimpleHealthBar : MonoBehaviour
    {
        [SerializeField] private Image healthBarFill;
        private IHealth healthBarTarget;

        private HealthBar healthBar;

        private void Awake()
        {
            if (healthBarFill == null) throw new NullReferenceException(nameof(healthBarFill));

            healthBarTarget = GetComponent<IHealth>();
            healthBar = new(healthBarFill, healthBarTarget);
        }
    }
}
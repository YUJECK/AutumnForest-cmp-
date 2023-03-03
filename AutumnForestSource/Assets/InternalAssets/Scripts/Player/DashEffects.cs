using System;
using UnityEngine;

namespace AutumnForest.Player
{
    [RequireComponent(typeof(SpriteRenderer))]
    public sealed class DashEffects : MonoBehaviour
    {
        [SerializeField] private GameObject dashIndicator;
        [SerializeField] private ParticleSystem dashParticle;
        [SerializeField] private Animator playerAnimator;
        
        private PlayerDash playerDash;

        private void Awake()
        {
            playerDash = GlobalServiceLocator.GetService<PlayerDash>();

            if (dashIndicator == null) throw new NullReferenceException(nameof(dashIndicator));
            if (dashParticle == null) throw new NullReferenceException(nameof(dashParticle));

            playerDash.OnEnabled += OnEnabled;
            playerDash.OnDisabled += OnDisabled;
        }

        private void OnEnabled()
        {
            playerDash.OnDashStarted += OnDashed;
            playerDash.OnReloaded += OnReloaded;

            dashIndicator.SetActive(true);
        }
        private void OnDisabled()
        {
            playerDash.OnDashStarted -= OnDashed;
            playerDash.OnReloaded -= OnReloaded;

            dashIndicator.SetActive(false);
        }

        private void OnReloaded()
        {
            dashIndicator.SetActive(true);
        }
        private void OnDashed()
        {
            dashIndicator.SetActive(false);
            dashParticle.Play();
        }
    }
}
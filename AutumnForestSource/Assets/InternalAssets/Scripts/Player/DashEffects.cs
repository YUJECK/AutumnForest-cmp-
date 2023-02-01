using System;
using UnityEngine;

namespace AutumnForest.Player
{
    [RequireComponent(typeof(SpriteRenderer))]
    public sealed class DashEffects : MonoBehaviour
    {
        [SerializeField] private GameObject dashIndicator;
        [SerializeField] private ParticleSystem dashParticle;
        
        private PlayerDash playerDash;

        private void Awake()
        {
            playerDash = GlobalServiceLocator.GetService<PlayerDash>();

            if (dashIndicator == null) throw new NullReferenceException(nameof(dashIndicator));
            if (dashParticle == null) throw new NullReferenceException(nameof(dashParticle));
        }
        private void OnEnable()
        {
            playerDash.OnDashed += OnDashed;
            playerDash.OnReloaded += OnReloaded; 
            
            dashIndicator.SetActive(true);
        }
        private void OnDisable()
        {
            playerDash.OnDashed -= OnDashed;
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

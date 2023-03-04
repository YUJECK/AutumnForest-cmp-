using AutumnForest.Health;
using UnityEngine;

namespace AutumnForest
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(IHealth))]
    public class DeathSound : MonoBehaviour
    {
        [SerializeField] private AudioSource sound;
        private IHealth health;

        private void Awake()
        {
            health = GetComponent<IHealth>();
            health.OnDied += sound.Play;
        }
        private void OnDestroy()
        {
            health.OnDied -= sound.Play;
        }
    }
}
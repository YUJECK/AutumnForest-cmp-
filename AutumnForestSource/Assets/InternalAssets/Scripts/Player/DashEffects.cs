using UnityEngine;

namespace AutumnForest.Player
{
    [RequireComponent(typeof(SpriteRenderer))]
    public sealed class DashEffects : MonoBehaviour
    {
        private SpriteRenderer spriteRenderer;
        private PlayerDash playerDash;

        private void Awake()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            playerDash = GlobalServiceLocator.GetService<PlayerDash>();
        }
        private void OnEnable()
        {
            playerDash.OnDashed += OnDashed;
            playerDash.OnDashReleased += OnDashReleased;
        }

        private void OnDashReleased()
        {
            spriteRenderer.color = new Color(
                spriteRenderer.color.r,
                spriteRenderer.color.g,
                spriteRenderer.color.b,
                1);
        }

        private void OnDashed()
        {
            spriteRenderer.color = new Color(
                spriteRenderer.color.r,
                spriteRenderer.color.g,
                spriteRenderer.color.b,
                0.5f);
        }

        private void OnDisable()
        {

        }

    }
}

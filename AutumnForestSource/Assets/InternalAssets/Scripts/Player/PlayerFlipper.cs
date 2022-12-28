using UnityEngine;

namespace AutumnForest.Assets.InternalAssets.Scripts.Player
{
    [RequireComponent(typeof(PlayerMove))]
    public sealed class PlayerFlipper : MonoBehaviour
    {
        private PlayerMove playerMove;

        private void Awake()
        {
            playerMove = GetComponent<PlayerMove>();
            playerMove.OnMove.AddListener(Flip);
        }
        private void Flip(Vector2 movement)
        {
            if (movement.x < 0 && transform.localScale.x == -1) transform.localScale = new Vector3(1, 1, 1);
            else if (movement.x > 0 && transform.localScale.x == 1) transform.localScale = new Vector3(-1, 1, 1);
        }
    }
}
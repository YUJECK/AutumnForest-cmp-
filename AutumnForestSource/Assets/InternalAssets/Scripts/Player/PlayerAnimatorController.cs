using UnityEngine;

namespace AutumnForest.Player
{
    public sealed class PlayerAnimatorController : MonoBehaviour
    {
        private Animator animator;
        private PlayerAnimator playerAnimator;

        private void Awake()
        {
            animator = GetComponent<Animator>();
            playerAnimator = new(animator);
        }

        private void OnEnable()
        {
            GlobalServiceLocator.GetService<PlayerMovable>().OnMoved += OnMoved;
            GlobalServiceLocator.GetService<PlayerMovable>().OnMoveReleased += OnMoveReleased; 
        }
        private void OnDisable()
        {
            if (GlobalServiceLocator.TryGetService(out PlayerMovable playerMovable))
            {
                playerMovable.OnMoved += OnMoved;
                playerMovable.OnMoveReleased += OnMoveReleased;
            }
        }

        private void OnMoved(Vector2 obj) => playerAnimator.PlayWalkAnimation();
        private void OnMoveReleased(Vector2 obj) => playerAnimator.PlayIdleAnimation();
    }
}
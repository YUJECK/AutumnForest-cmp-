using UnityEngine;

namespace AutumnForest.Player
{
    [RequireComponent(typeof(CreatureAnimator))]
    public sealed class PlayerAnimator : MonoBehaviour
    {
        private const string walkAnimation = "PlayerWalk";
        private const string idleAnimation = "PlayerIdle";

        private CreatureAnimator creatureAnimator;

        private void Awake()
        {
            creatureAnimator = GetComponent<CreatureAnimator>();
        }

        private void OnEnable()
        {
            GlobalServiceLocator.GetService<PlayerMovable>().OnMoved += PlayWalkAnimation;
            GlobalServiceLocator.GetService<PlayerMovable>().OnMoveReleased += PlayIdleAnimation;
        }
        private void OnDisable()
        {
            GlobalServiceLocator.GetService<PlayerMovable>().OnMoved -= PlayWalkAnimation;
            GlobalServiceLocator.GetService<PlayerMovable>().OnMoveReleased -= PlayIdleAnimation;
        }

        private void PlayWalkAnimation(Vector2 movement) => creatureAnimator.PlayAnimation(walkAnimation);
        private void PlayIdleAnimation(Vector2 movement) => creatureAnimator.PlayAnimation(idleAnimation);
    }
}
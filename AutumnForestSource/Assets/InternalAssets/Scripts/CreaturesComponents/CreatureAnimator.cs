using AutumnForest.Helpers;
using UnityEngine;

namespace AutumnForest
{
    [RequireComponent(typeof(Animator))]
    public class CreatureAnimator : MonoBehaviour, ICreatureComponent
    {
        [SerializeField] private string defaultAnimation = "Idle";
        private Animator animator;

        private void OnEnable()
        {
            animator = GetComponent<Animator>();
            SetDefault();
        }

        public void SetDefault()
        {
            if (defaultAnimation != "") Play(defaultAnimation);
            else Debug.LogError($"The DefaultAnimation field is not filled in {gameObject.name}");
        }
        public void Play(string animationName)
        {
            if (animator != null) animator.Play(animationName);
            else Debug.LogError($"Animator is null; {gameObject.name}");
        }
    }
}
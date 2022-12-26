using UnityEngine;

namespace AutumnForest.Other
{
    public abstract class InteractiveHandler : MonoBehaviour
    {
        [SerializeField] private GameObject interactive;
        public IInteractive Interactive { get; set; }

        private void OnValidate()
        {
            if (interactive != null)
            {
                if (interactive.TryGetComponent(out IInteractive _interactive))
                    Interactive = _interactive;
                else interactive = null;
            }
        }
    }
}
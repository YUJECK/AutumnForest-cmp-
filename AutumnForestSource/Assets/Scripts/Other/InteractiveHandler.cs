using AutumnForest.Editor;
using UnityEngine;

namespace AutumnForest.Other
{
    public abstract class InteractiveHandler : MonoBehaviour
    {
        [Interface(typeof(IInteractive)), SerializeField] private Object interactive;
        public IInteractive Interactive { get; private set; }

        private void Awake() => Interactive = interactive as IInteractive;
    }
}
using AutumnForest.Editor;
using UnityEngine;

namespace AutumnForest.Other
{
    public abstract class InteractiveHandler : MonoBehaviour
    {
        [Interface(typeof(IInteractive)), SerializeField] private Object interactive;
        
        private IInteractive _interactive;
        public IInteractive Interactive 
        { 
            get 
            {
                if (_interactive == null)
                    _interactive = interactive as IInteractive;

                return _interactive;
            }
            private set => _interactive = value;
        }
    }
}
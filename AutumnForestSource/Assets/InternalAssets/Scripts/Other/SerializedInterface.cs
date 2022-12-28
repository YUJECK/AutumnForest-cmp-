using AutumnForest.Editor;
using UnityEngine;

namespace AutumnForest
{
    [System.Serializable]
    public sealed class SerializedInterface<T> where T : class
    {
        private T test;

        [SerializeField, Interface()] private Object interfaceObject;

        private T _interface;
        public T Interface
        {
            get
            {
                if (_interface == null)
                    _interface = _interface as T;

                return _interface;
            }
        }
    }
}
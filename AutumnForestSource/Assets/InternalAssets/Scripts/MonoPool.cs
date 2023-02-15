using UnityEngine;

namespace AutumnForest
{
    public sealed class SerializablePool<T> 
    {
        [SerializeField] private T prefab;
        [SerializeField] private Transform poolContainer;
        [SerializeField] private int poolSize;
        [SerializeField] private bool autoExpand;
        

        public SerializablePool()
        {

        }
    }
}
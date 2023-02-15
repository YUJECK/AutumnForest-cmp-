using System;
using System.Collections.Generic;
using UnityEngine;

namespace AutumnForest
{
    public sealed class MonoObjectPool<T> where T : MonoBehaviour
    {
        [SerializeField] private T prefab;
        [SerializeField] private Transform poolContainer;
        [SerializeField] private bool autoExpand;

        private List<T> pool = new();

        public MonoObjectPool(T prefab, Transform container, int poolSize, bool autoExpand)
        {
            if (prefab == null) 
                throw new NullReferenceException(nameof(prefab));
            this.prefab = prefab;
            
            if (container == null)
                throw new NullReferenceException(nameof(container));
            this.poolContainer = container;
            
            this.autoExpand = autoExpand;

            InitPool(poolSize);
        }

        private void InitPool(int poolSize)
        {
            for (int i = 0; i < poolSize; i++)
                CreateNewObject(false);
        }
        private T CreateNewObject(bool isActiveByDefault)
        {
            T newObject = GameObject.Instantiate(prefab, poolContainer);
            newObject.gameObject.SetActive(isActiveByDefault);
            pool.Add(newObject);

            return newObject;
        }

        public bool TryGetFree(out T element)
        {
            for (int i = 0; i < pool.Count; i++)
            {
                if (!pool[i].gameObject.activeInHierarchy)
                {
                    element = pool[i];
                    return true;
                }
            }

            element = null;
            return false;
        }
        public T GetFree()
        {
            if (TryGetFree(out T element))
            {
                element.gameObject.SetActive(true);
                return element;
            }

            else if (autoExpand)
                return CreateNewObject(true);

            throw new Exception("There is no free element in pool");
        }
    }
}
using AutumnForest.Helpers;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace AutumnForest
{
    public class CreatureServiceLocator : MonoBehaviour
    {
        private readonly Dictionary<Type, object> services = new Dictionary<Type, object>();

        public void RegisterService<T>(T newService) where T : class, ICreatureComponent
        {
            if(newService != null) services.Add(typeof(T), newService);
            else throw new NullReferenceException(nameof(T));
        }
        public void UnregisterService<T>() where T : class, ICreatureComponent
        {
            if (services.ContainsKey(typeof(T))) services.Remove(typeof(T));
            else throw new NullReferenceException(nameof(T));
        }
        public T GetService<T>() where T : class, ICreatureComponent
        {
            if (services.TryGetValue(typeof(T), out var service)) return service as T;
            else throw new NullReferenceException(nameof(T));
        }
    }
}
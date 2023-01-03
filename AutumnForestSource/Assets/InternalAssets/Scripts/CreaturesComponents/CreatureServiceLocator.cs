using AutumnForest.Helpers;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace AutumnForest
{
    public class CreatureServiceLocator : MonoBehaviour
    {
        private readonly Dictionary<Type, object> services = new Dictionary<Type, object>();

        public void RegisterService<T>(T newService) where T : class, ICreatureComponent => services.Add(typeof(T), newService);
        public void UnregisterService<T>() where T : class, ICreatureComponent
        {
            if (services.ContainsKey(typeof(T)))
                services.Remove(typeof(T));
            else Debug.LogError("Service isnt registered");
        }
        public T GetService<T>() where T : class, ICreatureComponent
        {
            if (services.TryGetValue(typeof(T), out var service)) return service as T;
            else Debug.Log("Service isnt registered");

            return null;
        }
    }
}
using System;
using System.Collections.Generic;
using UnityEngine;

namespace AutumnForest
{
    public class LocalServiceLocator
    {
        private readonly Dictionary<Type, object> services = new Dictionary<Type, object>();
        public int ServicesCount => services.Count;

        public LocalServiceLocator(params object[] services) 
        {
            for (int i = 0; i < services.Length; i++)
                RegisterService(services[i]);
        }

        public void RegisterService<T>(T newService) where T : class
        {
            if (newService != null) services.Add(newService.GetType(), newService);
            else throw new NullReferenceException(nameof(T));
        }
        public void UnregisterService<T>() where T : class
        {
            if (services.ContainsKey(typeof(T))) services.Remove(typeof(T));
            else throw new NullReferenceException(nameof(T));
        }
        public T GetService<T>() where T : class
        {
            if (services.TryGetValue(typeof(T), out var service)) return service as T;
            else throw new NullReferenceException(nameof(T));
        }
    }
}
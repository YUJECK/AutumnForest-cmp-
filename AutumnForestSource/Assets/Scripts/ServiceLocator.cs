using System;
using System.Collections.Generic;
using UnityEngine;

namespace AutumnForest
{
    public static class ServiceLocator
    {
        //services
        private static readonly Dictionary<Type, object> services = new Dictionary<Type, object>();

        //methods
        public static void RegisterService<T>(T newService) where T : class => services.Add(typeof(T), newService);
        public static void UnregisterService<T>() where T : class
        {
            if (services.ContainsKey(typeof(T)))
                services.Remove(typeof(T));
            else Debug.LogError("Service isnt registered");
        }
        public static T GetService<T>() where T : class
        {
            if (services.TryGetValue(typeof(T), out var service)) return service as T;
            else Debug.Log("Service isnt registered");

            return null;
        }
    }
}
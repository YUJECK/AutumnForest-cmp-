using UnityEngine;
using System;

namespace AutumnForest.EditorScripts
{
    public class InterfaceAttribute : PropertyAttribute
    {
        public Type requiredType { get; private set; }

        public InterfaceAttribute(Type type) => requiredType = type;
    }
}
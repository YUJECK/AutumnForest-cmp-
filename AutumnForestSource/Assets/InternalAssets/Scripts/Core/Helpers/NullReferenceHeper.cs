using System;

namespace AutumnForest.Helpers
{
    public static class CheckForNullHelper
    {
        public static T Check<T>(T value) => CheckNull(value, "value");
        public static T Check<T>(T value, string name) => CheckNull(value, name);

        private static T CheckNull<T>(T value, string name)
        {
            if (value == null) throw new NullReferenceException(name);
            return value;
        }
    }
}
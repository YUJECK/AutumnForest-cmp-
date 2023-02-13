using System;

namespace AutumnForest.Helpers
{
    public static class ThrowNullReferenceHeper
    {
        public static void Check(object value, string name)
        {
            if (value == null)
                throw new NullReferenceException(name);
        }
    }
}
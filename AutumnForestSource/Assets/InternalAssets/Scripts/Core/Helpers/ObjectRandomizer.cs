namespace AutumnForest.Helpers
{
    public sealed class ObjectRandomizer
    {
        public static T GetRandom<T>(params T[] objects) => objects[UnityEngine.Random.Range(0, objects.Length)];
    }
}
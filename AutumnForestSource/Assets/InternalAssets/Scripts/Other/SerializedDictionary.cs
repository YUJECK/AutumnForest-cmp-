namespace AutumnForest.Helpers
{
    [System.Serializable] class SerializedDictionary<KeyT, ValueT> : MonoBehavior
    {
        public readonly KeyT key;
        public readonly ValueT value;
    }
}
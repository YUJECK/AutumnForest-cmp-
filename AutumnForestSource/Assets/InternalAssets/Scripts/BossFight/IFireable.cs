namespace AutumnForest
{
    public interface IFireable
    {
        bool Fired { get; }
        void Fire();
    }
}
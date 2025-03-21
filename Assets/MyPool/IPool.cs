namespace MyPool
{
    public interface IPool<T> where T : IPoolable
    {
        void Preload(int capacity);
        void Push(T entity);
        T Pop();
        void PushAll();
    }
}
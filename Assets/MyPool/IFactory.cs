namespace MyPool
{
    public interface IFactory<T> where T : IPoolable
    {
        T Create(IPool<T> pool);
    }
}
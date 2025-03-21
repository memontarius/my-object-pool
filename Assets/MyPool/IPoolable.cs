namespace MyPool
{
    public interface IPoolable
    {
        public void Activate();
        public void Deactivate();
        public void Release();
    }
}
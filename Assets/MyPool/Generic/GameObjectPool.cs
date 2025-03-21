using System.Collections.Generic;

namespace MyPool.Generic
{
    public class GameObjectPool: IPool<GameObjectPoolable>
    {
        private readonly IFactory<GameObjectPoolable> _factory;
        private readonly Stack<GameObjectPoolable> _inactiveEntities = new ();
        private readonly List<GameObjectPoolable> _activeEntities = new ();
        
        public GameObjectPool(IFactory<GameObjectPoolable> factory)
        {
            _factory = factory;
        }
        
        public void Preload(int capacity)
        {
            for (int i = 0; i < capacity; i++)
            {
                GameObjectPoolable entity = _factory.Create(this);
                Push(entity);
            }
        }

        public void Push(GameObjectPoolable entity)
        {
            _activeEntities.Remove(entity);
            entity.Deactivate();
            _inactiveEntities.Push(entity);
        }

        public GameObjectPoolable Pop()
        {
            GameObjectPoolable entity = _inactiveEntities.Count > 0
                ? _inactiveEntities.Pop()
                : _factory.Create(this);
            
            entity.Activate();
            _activeEntities.Add(entity);
            
            return entity;
        }

        public void PushAll()
        {
            foreach (GameObjectPoolable entity in _activeEntities)
            {
                Push(entity);
            }
        }
    }
}

using UnityEngine;

namespace MyPool.Generic
{
    public class GameObjectFactory : IFactory<GameObjectPoolable>
    {
        private GameObject _prefab;
        
        public GameObjectFactory(GameObject prefab)
        {
            _prefab = prefab;
        }
        
        public GameObjectPoolable Create(IPool<GameObjectPoolable> pool)
        {
             GameObject go = GameObject.Instantiate(_prefab);
             var poolable = go.AddComponent<GameObjectPoolable>();
             poolable.Pool = pool ;
             return poolable;
        }
    }
}
using UnityEngine;

namespace MyPool.Generic
{
    public class GameObjectPoolable : MonoBehaviour, IPoolable
    {
        public IPool<GameObjectPoolable> Pool { get; set; }
        
        public void Activate()
        {
            gameObject.SetActive(true);
        }

        public void Deactivate()
        {
            gameObject.SetActive(false);
        }

        public void Release()
        {
            Pool.Push(this);
        }
    }
}
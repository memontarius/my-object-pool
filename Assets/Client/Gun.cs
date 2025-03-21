using MyPool.Generic;
using UnityEngine;

namespace Client
{
    public class Gun : MonoBehaviour
    {
        public GameObject _bulletPrefab;
        private GameObjectPool _bulletGameObjectPool;
        
        private void Start()
        {
            _bulletGameObjectPool = new GameObjectPool(new GameObjectFactory(_bulletPrefab));
            _bulletGameObjectPool.Preload(20);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Shot();
            }
        }

        private void Shot()
        {
            GameObjectPoolable entity = _bulletGameObjectPool.Pop();
            entity.transform.position = transform.position;
            entity.transform.up = transform.forward;
        }
    }
}
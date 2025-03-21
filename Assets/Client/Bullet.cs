using MyPool;
using UnityEngine;

namespace Client
{
    public class Bullet : MonoBehaviour
    {
        private void OnEnable()
        {
            Invoke(nameof(Deactivate), 2.5f);
        }

        private void OnDisable()
        {
            CancelInvoke(nameof(Deactivate));
        }
        
        private void Update()
        {
            transform.Translate(Vector3.up * Time.deltaTime * 10f);
        }

        private void Deactivate()
        {
            GetComponent<IPoolable>().Release();
        }
    }
}
using Runner.PlayerController;
using Runner.Settings;
using System;
using UnityEngine;

namespace Runner.Platforms
{
    public class Platform : MonoBehaviour
    {
        [SerializeField] private Transform _pool;
        [SerializeField] private Transform _obstaclesPool;

        private EntryPoint _entryPoint;

        public event Action<Player> PlayerSteppedOnPlatform;
        public event Action<Player> PlayerSteppedOutOfThePlatform;

        private void OnEnable()
        {
                ChangePrefabsState();
                EnableObstacles();
        }

        private void OnDisable()
        {
            foreach (Transform obstacle in _obstaclesPool)
            {
                obstacle.gameObject.SetActive(false);
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.collider.TryGetComponent(out Player player))
            {
                PlayerSteppedOnPlatform?.Invoke(player);
            }
        }

        private void OnCollisionExit(Collision collision)
        {
            if (collision.collider.TryGetComponent(out Player player))
            {
                PlayerSteppedOutOfThePlatform?.Invoke(player);
            }
        }

        public void Init(EntryPoint entryPoint)
        {
            _entryPoint = entryPoint;
        }

        private void ChangePrefabsState()
        {
            foreach (Transform prefab in _pool)
            {
                prefab.position = CalculatePrefabPosition(transform);
                prefab.gameObject.SetActive(true);
            }
        }

        private void EnableObstacles()
        {
            int obstaclesAmount = 5;

            if (_obstaclesPool.childCount > 0)
            {
                for (int i = 0; i < obstaclesAmount; i++)
                {
                    _obstaclesPool.GetChild(UnityEngine.Random.Range(0, _obstaclesPool.childCount)).gameObject.SetActive(true);
                }
            }
        }

        private Vector3 CalculatePrefabPosition(Transform transform)
        {
            var collider = transform.GetComponent<Collider>();

            float spawnPosY = 0;
            float minSpawnPosX = collider.bounds.min.x;
            float maxSpawnPosX = collider.bounds.max.x;
            float minSpawnPosZ = collider.bounds.min.z;
            float maxSpawnPosZ = collider.bounds.max.z;

            return new Vector3(UnityEngine.Random.Range(minSpawnPosX, maxSpawnPosX), spawnPosY, UnityEngine.Random.Range(minSpawnPosZ, maxSpawnPosZ));
        }
    }
}

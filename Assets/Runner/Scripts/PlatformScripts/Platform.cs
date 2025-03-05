using Runner.PlayerController;
using System;
using UnityEngine;

namespace Runner.Platforms
{
    public class Platform : MonoBehaviour
    {
        [SerializeField] private Transform _pool;

        public event Action<Player> PlayerSteppedOnPlatform;
        public event Action<Player> PlayerSteppedOutOfThePlatform;

        private void OnEnable()
        {
            ChangePrefabsState();
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

        private void ChangePrefabsState()
        {
            foreach (Transform prefab in _pool)
            {
                prefab.position = CalculatePrefabPosition(transform,prefab.position.y);
                prefab.gameObject.SetActive(true);
            }
        }

        private Vector3 CalculatePrefabPosition(Transform transform, float prefabHeight)
        {
            var collider = transform.GetComponent<Collider>();

            float spawnPosY = prefabHeight;
            float minSpawnPosX = collider.bounds.min.x;
            float maxSpawnPosX = collider.bounds.max.x;
            float minSpawnPosZ = collider.bounds.min.z;
            float maxSpawnPosZ = collider.bounds.max.z;

            return new Vector3(UnityEngine.Random.Range(minSpawnPosX, maxSpawnPosX), spawnPosY, UnityEngine.Random.Range(minSpawnPosZ, maxSpawnPosZ));
        }
    }
}

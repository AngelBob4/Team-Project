using UnityEngine;

namespace Platforms
{
    public class Platform : MonoBehaviour
    {
        [SerializeField] private Transform _pool;

        private void OnEnable()
        {
            ChangePrefabsState();
        }

        private void ChangePrefabsState()
        {
            foreach (Transform prefab in _pool)
            {
                prefab.position = CalculatePrefabPosition(transform);
                prefab.gameObject.SetActive(true);
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

            return new Vector3(Random.Range(minSpawnPosX, maxSpawnPosX), spawnPosY, Random.Range(minSpawnPosZ, maxSpawnPosZ));
        }
    }
}

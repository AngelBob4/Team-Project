using Runner.Optimization;
using UnityEngine;

namespace Runner.Platforms
{
    public class Platform : MonoBehaviour
    {
        private readonly int ObstaclesAmount = 3;

        [SerializeField] private Transform _collectablesPool;
        [SerializeField] private Transform _enemiesPool;
        [SerializeField] private Transform _obstaclesPool;
        [SerializeField] private MeshCombiner _meshCombiner;

        private int _enemiesAmount;

        private void OnEnable()
        {
            EnableEnemies();
            EnableObstacles();
            EnableCollectables();
            EnableEnemies();
        }

        private void Awake()
        {
            DisablePrefabs(_collectablesPool);
            DisablePrefabs(_enemiesPool);
            DisablePrefabs(_obstaclesPool);
        }

        private void OnDisable()
        {
            DisablePrefabs(_collectablesPool);
            DisablePrefabs(_enemiesPool);
            DisablePrefabs(_obstaclesPool);
        }

        public void CombineMeshes()
        {
            _meshCombiner.CombineMeshes();
        }

        public void InitEnemiesAmount(int enemiesAmount)
        {
            _enemiesAmount = enemiesAmount;

            DisablePrefabs(_collectablesPool);
            DisablePrefabs(_enemiesPool);
        }

        private void EnableEnemies()
        {
            if (_enemiesAmount <= _enemiesPool.childCount)
            {
                for (int i = 0; i < _enemiesAmount; i++)
                {
                    _enemiesPool.GetChild(i).position = CalculatePrefabPosition(transform);
                    _enemiesPool.GetChild(i).gameObject.SetActive(true);
                }
            }
        }

        private void EnableCollectables()
        {
            foreach (Transform collectable in _collectablesPool)
            {
                collectable.position = CalculatePrefabPosition(transform);
                collectable.gameObject.SetActive(true);
            }
        }

        private void EnableObstacles()
        {
            if (_obstaclesPool.childCount > 0 && ObstaclesAmount <= _obstaclesPool.childCount)
            {
                for (int i = 0; i < ObstaclesAmount; i++)
                {
                    _obstaclesPool.GetChild(Random.Range(0, _obstaclesPool.childCount)).gameObject.SetActive(true);
                }
            }
        }

        private void DisablePrefabs(Transform pool)
        {
            foreach (Transform prefab in pool)
            {
                prefab.gameObject.SetActive(false);
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

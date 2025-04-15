using Runner.Optimization;
using UnityEngine;

namespace Runner.Platforms
{
    public class Platform : MonoBehaviour
    {
        [SerializeField] private Transform _pool;
        [SerializeField] private Transform _obstaclesPool;
        [SerializeField] private MeshCombiner _meshCombiner;

        private int _npcAmount;
        private int _obstaclesAmount;

        private void OnEnable()
        {
            EnableNPCs();
            EnableObstacles();
        }

        private void OnDisable()
        {
            DisablePrefabs(_pool);
            DisablePrefabs(_obstaclesPool);
        }

        public void ChangeMeshCombinerPosition(float offset)
        {
            _meshCombiner.CombineMeshes();
            _meshCombiner.transform.position = new Vector3(0, 0, offset);
        }

        public void InitPrefabsAmount(int npcAmount, int obstaclesAmount)
        {
            _npcAmount = npcAmount;
            _obstaclesAmount = obstaclesAmount;
        }

        private void EnableNPCs()
        {
            for (int i = 0; i < _npcAmount; i++)
            {
                _pool.GetChild(i).position = CalculatePrefabPosition(transform);
                _pool.GetChild(i).gameObject.SetActive(true);
            }
        }

        private void EnableObstacles()
        {
            if (_obstaclesPool.childCount > 0)
            {
                for (int i = 0; i < _obstaclesAmount; i++)
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

using Runner.Platforms;
using Runner.ScriptableObjects;
using UnityEngine;

namespace Runner.PlatformsHandler
{
    public class PlatformsSpawner : MonoBehaviour
    {
        [SerializeField] private Transform _startPlatform;
        [SerializeField] private Transform _lastPlatform;
        [SerializeField] private Transform _pool;

        private int _npcsAmount;
       
        private float _offset = 30f;
       
        public void InitPlatformsPrefabsAmount(int npcsAmount)
        {
            _npcsAmount = npcsAmount;           
        }

        public void SpawnAllTypesOfPlatforms(LocationType currentRunnerSettings)
        {
            SpawnPlatform(currentRunnerSettings.StartPlatformView, _startPlatform);
            SpawnPlatform(currentRunnerSettings.LastPlatformView, _lastPlatform);
            SpawnPlatformVariants(currentRunnerSettings);

            _pool.gameObject.SetActive(false);
        }

        public void ActivatePlatformVariants()
        {
            _pool.gameObject.SetActive(true);

            foreach (Transform prefab in _pool)
            {
                float offset = 0;

                prefab.GetComponent<Platform>().ChangeMeshCombinerPosition(offset);

                offset += -30;

            }
        }

        private void SpawnPlatform(GameObject platform, Transform parent)
        {
            Instantiate(platform, parent);
        }

        private void SpawnPlatformVariants(LocationType currentRunnerSettings  )
        {
            for (int i = 0; i < currentRunnerSettings.PlatformVariants.Count; i++)
            {
                var spawnPos = _pool.position + new Vector3(0, 0, _offset);
                Platform newPlatform = Instantiate(currentRunnerSettings.PlatformVariants[i], spawnPos, Quaternion.identity, _pool);
                newPlatform.InitPrefabsAmount(_npcsAmount);
                _offset += 30f;
            }
        }
    }
}

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

        private int _enemiesAmount;
        private float _offset = 30f;

        public void SpawnAllTypesOfPlatforms(LocationType currentRunnerSettings, int enemiesAmount)
        {
            _enemiesAmount = enemiesAmount;
            SpawnStartPlatform(currentRunnerSettings.StartPlatform, _startPlatform);
            SpawnPlatform(currentRunnerSettings.LastPlatformView, _lastPlatform);
            SpawnPlatformVariants(currentRunnerSettings);
        }

        public void ActivatePlatformVariants()
        {
            for (int i = 0; i < _pool.childCount; i++)
            {
                var spawnPos = _pool.position + new Vector3(0, 0, _offset);
                _pool.GetChild(i).transform.position = spawnPos;
                _pool.GetChild(i).gameObject.SetActive(true);
                _offset += 30f;
            }
        }

        private void SpawnStartPlatform(StartPlatform startPlatform, Transform parent)
        {
            StartPlatform newStartPlatform = Instantiate(startPlatform, parent);
            newStartPlatform.CombineMeshes();
        }

        private void SpawnPlatform(GameObject platform, Transform parent)
        {
            Instantiate(platform, parent);
        }

        private void SpawnPlatformVariants(LocationType currentRunnerSettings)
        {
            for (int i = 0; i < currentRunnerSettings.PlatformVariants.Count; i++)
            {
                Platform newPlatform = Instantiate(currentRunnerSettings.PlatformVariants[i], _pool.position + new Vector3(0, 0, _offset), Quaternion.identity, _pool);
                newPlatform.CombineMeshes();
                newPlatform.InitEnemiesAmount(_enemiesAmount);
            }
        }
    }
}
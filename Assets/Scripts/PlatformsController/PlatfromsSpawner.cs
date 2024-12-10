using UnityEngine;

public class PlatfromsSpawner : MonoBehaviour
{
    [SerializeField] private AllPlatformViews _currentPlatformViews;
    [SerializeField] private StartPlatform _startPlatform;
    [SerializeField] private LastPlatform _lastPlatform;
    [SerializeField] private Transform _pool;

    private float _offset = 30f;

    private void Awake()
    {
        // получаем из менюшки _currentPlatformViews

        SpawnPlatform(_currentPlatformViews.StartPlatformView, _startPlatform.transform);
        SpawnPlatform(_currentPlatformViews.LastPlatformView, _lastPlatform.transform);
        SpawnPlatformVariants();
    }

    private void SpawnPlatform(GameObject platform, Transform parent)
    {
        Instantiate(platform, parent);
    }

    private void SpawnPlatformVariants()
    {
        for (int i = 0; i < _currentPlatformViews.PlatformVariants.Count; i++)
        {
            var spawnPos = _pool.position + new Vector3(0, 0, _offset);
            Instantiate(_currentPlatformViews.PlatformVariants[i], spawnPos, Quaternion.identity, _pool);
            _offset += 30f;
        }
    }
}

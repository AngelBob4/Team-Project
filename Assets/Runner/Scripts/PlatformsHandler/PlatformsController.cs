using Runner.ScriptableObjects;
using Runner.Settings;
using UnityEngine;

namespace Runner.PlatformsHandler
{
    public class PlatformsController : MonoBehaviour
    {
        [SerializeField] private PlatformsCounter _platformsCounter;
        [SerializeField] private PlatformsSpawner _platformsSpawner;
        [SerializeField] private PlatformsMover _platformsMover;

        [SerializeField] private LevelController _levelController;

        public LevelController LevelController =>_levelController;

        public void InitPlatforms(AllRunnerSettings currentRunnerSettings, int platformsAmount)
        {
            _platformsSpawner.InitPlatformsViews(currentRunnerSettings);
            _platformsSpawner.InitPlatformsPrefabsAmount(5, 5);
            _platformsMover.InitTotalNumberOfPlatforms(platformsAmount);
        }

        public void StartGameProcess()
        {
            _platformsSpawner.ActivatePlatformVariants();
        }
    }
}
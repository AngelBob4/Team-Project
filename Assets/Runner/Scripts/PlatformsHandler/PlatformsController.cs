using Runner.PlayerController;
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

        private Player _player;
        private LevelController _levelController;

        public PlatformsCounter Counter => _platformsCounter;

        private void Update()
        {
            if (_levelController.IsRunnerStarted)
            {
                _platformsMover.MovePlatfroms(_player, _platformsCounter);
            }
        }

        public void Initialize(Player player, LevelController levelController, Level level)
        {
            _player = player;
            _levelController = levelController;
        }

        public void InitializeLevel(LocationType currentRunnerSettings, int platformsAmount, int enemiesAmount)
        {
            _platformsSpawner.SpawnAllTypesOfPlatforms(currentRunnerSettings, enemiesAmount);
            _platformsMover.InitTotalNumberOfPlatforms(platformsAmount);
        }

        public void StartGameProcess()
        {
            _platformsSpawner.ActivatePlatformVariants();
        }
    }
}
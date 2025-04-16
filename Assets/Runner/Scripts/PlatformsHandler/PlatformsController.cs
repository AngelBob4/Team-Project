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
       
        [SerializeField] private Player _player;
        [SerializeField] private LevelController _levelController;

        private void OnEnable()
        {
            
        }

        private void OnDisable()
        {
            
        }

        private void Update()
        {
            if (_levelController.IsRunnerStarted)
            {
                _platformsMover.MovePlatfroms(_player, _platformsCounter);
            }
        }

        public void InitPlatforms(LocationType currentRunnerSettings, int platformsAmount, int prefabsAmount)
        {
            _platformsSpawner.InitPlatformsPrefabsAmount(prefabsAmount);
            _platformsSpawner.SpawnAllTypesOfPlatforms(currentRunnerSettings);
            _platformsMover.InitTotalNumberOfPlatforms(platformsAmount);
        }

        public void CombinePlatformMeshes()
        {

        }

        public void StartGameProcess()
        {
            _platformsSpawner.ActivatePlatformVariants();
        }

        // инициализация платформ
        // спаун платформ
        // комбайн мешей
        // запуск платформ

        // контролирует : движение платформ, отсчет платформ, пора ли запускать последнюю платформу
    }
}
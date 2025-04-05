using Runner.Enums;
using Runner.PlatformsHandler;
using Runner.ScriptableObjects;
using Runner.SoundSystem;
using System.Collections.Generic;
using UnityEngine;

namespace Runner.Settings
{
    public class EntryPoint : MonoBehaviour
    {
        private const int PlatformsAmount = 30;

        [SerializeField] private PlatfromsSpawner _platformsSpawner;
        [SerializeField] private PlatformController _platformsController;
        [SerializeField] private BackgroundMusic _backgroundMusic;
        [SerializeField] private List<AllRunnerSettings> _allRunnerSettings;

        private bool _isRunnerStarted = false;

        public bool IsRunnerStarted => _isRunnerStarted;

        public void InitAllSettingsForRunner(LocationTypes locationType, int platformsAmount = PlatformsAmount)
        {
            _backgroundMusic.InitAudioClip(_allRunnerSettings[(int)locationType]);
            _platformsSpawner.InitPlatformsViews(_allRunnerSettings[(int)locationType]);
            _platformsController.InitTotalNumberOfPlatforms(platformsAmount);
            _backgroundMusic.PlayBackgroundMusic();
        }

        public void StartRunner()
        {
            _isRunnerStarted = true;
            _platformsSpawner.ActivatePlatformVariants();
           // _platformsSpawner.SpawnPlatformVariants();
        }

        public void StopRunner()
        {
            _isRunnerStarted = false;
        }
    }
}

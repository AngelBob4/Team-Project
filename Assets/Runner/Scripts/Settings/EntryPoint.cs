using UnityEngine;
using Runner.PlatformsHandler;
using System.Collections.Generic;
using Runner.ScriptableObjects;
using Runner.SoundSystem;
using Runner.PlayerController;

namespace Runner.Settings
{
    public class EntryPoint : MonoBehaviour
    {
        [SerializeField] private PlatfromsSpawner _platformsSpawner;
        [SerializeField] private PlatformsCounter _platformsCounter;
        [SerializeField] private PlatformController _platformsController;
        [SerializeField] private BackgroundMusic _backgroundMusic;
        [SerializeField] private List<AllRunnerSettings> _allRunnerSettings;
        [SerializeField] private Player _player;

        private bool _isRunnerStarted = false;

        public bool IsRunnerStarted => _isRunnerStarted;

        public void InitAllSettingsForRunner(int index, int health, int platformsAmount, float lanternIntensity)
        {
            _backgroundMusic.InitAudioClip(_allRunnerSettings[index]);
            _platformsSpawner.InitPlatformsViews(_allRunnerSettings[index]);
            _platformsController.InitTotalNumberOfPlatforms(platformsAmount);
            _player.PlayerLantern.InitLanternIntensity(lanternIntensity);
            _player.PlayerHealth.InitHealth(health);
            _player.PlayerMovement.PutPlayerToDefaultPosition();
        }

        public void StartRunner()
        {
            _backgroundMusic.PlayBackgroundMusic();
            _isRunnerStarted = true;
        }
    }
}

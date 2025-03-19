using UnityEngine;
using Runner.PlatformsHandler;
using System.Collections.Generic;
using Runner.ScriptableObjects;
using Runner.SoundSystem;
using Runner.PlayerController;
using System;
using Runner.Enums;

namespace Runner.Settings
{
    public class EntryPoint : MonoBehaviour
    {
        private const int PlatformsAmount = 3;

        [SerializeField] private PlatfromsSpawner _platformsSpawner;
        [SerializeField] private PlatformsCounter _platformsCounter;
        [SerializeField] private PlatformController _platformsController;
        [SerializeField] private BackgroundMusic _backgroundMusic;
        [SerializeField] private List<AllRunnerSettings> _allRunnerSettings;
        [SerializeField] private Player _player;

        private bool _isRunnerStarted = false;

        public bool IsRunnerStarted => _isRunnerStarted;

        public void InitAllSettingsForRunner(LocationTypes locationType, int platformsAmount = PlatformsAmount)//, int health, , float lanternIntensity)
        {
            _backgroundMusic.InitAudioClip(_allRunnerSettings[(int)locationType]);
            _platformsSpawner.InitPlatformsViews(_allRunnerSettings[(int)locationType]);
            _platformsController.InitTotalNumberOfPlatforms(platformsAmount);
            //_player.PlayerLantern.InitLanternIntensity(8);
            //_player.PlayerHealth.InitHealth(7);
            _player.PlayerMovement.PutPlayerToDefaultPosition();
        }

        public void StartRunner()
        {
            _backgroundMusic.PlayBackgroundMusic();
            _isRunnerStarted = true;
        }
    }
}

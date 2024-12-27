using UnityEngine;
using Runner.PlatformsHandler;
using System.Collections.Generic;
using Runner.ScriptableObjects;
using Runner.SoundSystem;

namespace Runner.Settings
{
    public class EntryPoint : MonoBehaviour
    {
        [SerializeField] private PlatfromsSpawner _platformsSpawner;
        [SerializeField] private BackgroundMusic _backgroundMusic;
        [SerializeField] private List<AllRunnerSettings> _allRunnerSettings;

        private bool _isRunnerStarted = false;

        public bool IsRunnerStarted => _isRunnerStarted;

        public void InitAllSettingsForRunner()
        {
            _backgroundMusic.InitAudioClip(_allRunnerSettings[0]);
            _platformsSpawner.InitPlatformsViews(_allRunnerSettings[0]);
            //_player.PlayerHealth.InitHealth();
            _isRunnerStarted = true;
        }
    }
}

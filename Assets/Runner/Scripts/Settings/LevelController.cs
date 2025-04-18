using MainGlobal;
using Runner.PlatformsHandler;
using Runner.PlayerController;
using Runner.ScriptableObjects;
using Runner.SoundSystem;
using Runner.UI;
using UnityEngine;

namespace Runner.Settings
{
    public class LevelController : MonoBehaviour
    {
        private CanvasUI _canvasUI;
        private Player _player;
        private PlatformsController _platformController;
        private SoundController _soundController;
        private PlayerGlobalData _playerGlobalData;
        private GlobalGame _globalGame;

        private Level _level;

        private bool _isRunnerStarted = false;

        public bool IsRunnerStarted => _isRunnerStarted;

        private void OnDisable()
        {
            _playerGlobalData.Died -= GameOver;
        }

        public void Initialize(GlobalGame globalGame, PlayerGlobalData globalData, CanvasUI canvasUI, SoundController soundController, Level level,
            Player player, PlatformsController platformsController)
        {
            _globalGame = globalGame;
            _playerGlobalData = globalData;
            _level = level;
            _canvasUI = canvasUI;
            _soundController = soundController;
            _platformController = platformsController;
            _player = player;

            _playerGlobalData.Died += GameOver;
            InitializeLevel();
        }

        public void InitializeLevel()
        {
            _canvasUI.InitializeLevel(_level);
            _platformController.InitializeLevel(_level.LocationType, _level.PlatformsAmount, _level.EnemiesAmount);
        }

        public void StartRunner()
        {
            _isRunnerStarted = true;
            _canvasUI.StartGameProcess();
            _platformController.StartGameProcess();
            _player.StartGameProcess();
        }

        public void GameOver()
        {
            _isRunnerStarted = false;
            _canvasUI.EnableDeathPanel();
            _player.Die();
        }

        public void FinishRunner()
        {
            _globalGame.StartEvent();
        }
    }
}

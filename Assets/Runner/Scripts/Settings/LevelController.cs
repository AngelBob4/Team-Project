using MainGlobal;
using Runner.PlatformsHandler;
using Runner.PlayerController;
using Runner.ScriptableObjects;
using Runner.UI;
using UnityEngine;

namespace Runner.Settings
{
    public class LevelController : MonoBehaviour
    {
        private CanvasUI _canvasUI;
        private Player _player;
        private PlatformsController _platformController;
        private PlayerGlobalData _playerGlobalData;
        private GlobalGame _globalGame;

        private Level _level;

        private bool _isRunnerStarted = false;

        public bool IsRunnerStarted => _isRunnerStarted;

        private void OnDisable()
        {
            _playerGlobalData.Died -= GameOver;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Time.timeScale = 0;
            }

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Time.timeScale = 1f;
            }
        }

        public void Initialize(GlobalGame globalGame, PlayerGlobalData globalData, CanvasUI canvasUI, Level level, Player player, PlatformsController platformsController)
        {
            _globalGame = globalGame;
            _playerGlobalData = globalData;
            _level = level;
            _canvasUI = canvasUI;
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
            _canvasUI.EnableDeathPanel(true);
            _player.Die();
        }

        public void ResurrectPlayer()
        {
            _isRunnerStarted = true;
            _canvasUI.EnableDeathPanel(false);
            _playerGlobalData.ChangeHP(_playerGlobalData.StartHPMax);
            _playerGlobalData.ChangeLanternLight(_playerGlobalData.StartLanternLightMax);
            _player.Resurrect();
            // создать дефолтные значения для здоровья и монеток в глобал дата
        }

        public void FinishRunner()
        {
            _globalGame.StartEvent();
        }
    }
}

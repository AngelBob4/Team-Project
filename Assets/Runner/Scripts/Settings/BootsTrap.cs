using MainGlobal;
using Reflex.Attributes;
using Runner.PlatformsHandler;
using Runner.PlayerController;
using Runner.ScriptableObjects;
using Runner.SoundSystem;
using Runner.UI;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Runner.Settings
{
    public class BootsTrap : MonoBehaviour
    {
        private const string SoundController = nameof(SoundController);
        private const string LevelController = nameof(LevelController);
        private const string Player = nameof(Player);
        private const string CameraMovement = nameof(CameraMovement);
        private const string PlatformsController = nameof(PlatformsController);

        [SerializeField] private CanvasUI _canvasUI;
        [SerializeField] private List<Level> _levels;

        private SoundController _soundController;
        private CameraMovement _cameraMovement;
        private Player _player;
        private LevelController _levelController;
        private PlatformsController _platformsController;

        private GlobalGame _globalGame;
        private PlayerGlobalData _playerGlobalData;

        private int _defaultLevelNumber = 10;
        private Level _currentLevel;

        [Inject]
        private void Inject(GlobalGame globalGame)
        {
            _globalGame = globalGame;
        }

        [Inject]
        private void Inject(PlayerGlobalData playerGlobalData)
        {
            _playerGlobalData = playerGlobalData;
        }

        private void Awake()
        {
            InitLevel(_globalGame.Level);
            //InitLevel(4);
            SetGrafficsSettings(_currentLevel.Color);
            SpawnAll();
            InitializeAll();
        }

        private void InitLevel(int levelNumber)
        {
            if (levelNumber > 0 && levelNumber <= _levels.Count)
            {
                _currentLevel = _levels.Where(level => level.LevelNumber == levelNumber).First();
            }
            else
            {
                _currentLevel = _levels.Where(level => level.LevelNumber == _defaultLevelNumber).First();
            }
        }

        private void SetGrafficsSettings(Color color)
        {
            RenderSettings.fog = true;
            RenderSettings.fogColor = color;
        }

        private void SpawnAll()
        {
            _soundController = Instantiate(Resources.Load(SoundController, typeof(SoundController))) as SoundController;
            _levelController = Instantiate(Resources.Load(LevelController, typeof(LevelController))) as LevelController;
            _player = Instantiate(Resources.Load(Player, typeof(Player))) as Player;
            _cameraMovement = Instantiate(Resources.Load(CameraMovement, typeof(CameraMovement))) as CameraMovement;
            _platformsController = Instantiate(Resources.Load(PlatformsController, typeof(PlatformsController))) as PlatformsController;
        }

        private void InitializeAll()
        {
            _soundController.Initialize(_currentLevel.LocationType.AudioClip, _player, _canvasUI);
            _player.Initialize(_levelController, _playerGlobalData);
            _cameraMovement.Initialize(_player);
            _platformsController.Initialize(_player, _levelController, _currentLevel);
            _canvasUI.Initialize(_levelController, _soundController);
            _levelController.Initialize(_globalGame, _playerGlobalData, _canvasUI, _currentLevel, _player, _platformsController);
        }
    }
}

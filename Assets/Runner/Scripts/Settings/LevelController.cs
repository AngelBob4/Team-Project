using MainGlobal;
using Reflex.Attributes;
using Runner.Enums;
using Runner.PlatformsHandler;
using Runner.PlayerController;
using Runner.ScriptableObjects;
using Runner.Settings.StateMachine;
using Runner.SoundSystem;
using Runner.UI;
using System.Collections.Generic;
using UnityEngine;

namespace Runner.Settings
{
    public class LevelController : MonoBehaviour
    {
        [SerializeField] private CanvasUI _canvasUI;
        [SerializeField] private Player _player;
        [SerializeField] private BackgroundMusic _backgroundMusic;
        [SerializeField] private PlatformsController _platformController;

        [SerializeField] private List<AllRunnerSettings> _allRunnerSettings;

        private AllRunnerSettings _currentRunnerSettings;
        private LevelStateMachine _levelStateMachine;
        private PlayerGlobalData _playerGlobalData;
        private GlobalGame _globalGame;

        private bool _isRunnerStarted = false;

        public bool IsRunnerStarted => _isRunnerStarted;


        [Inject]
        private void Inject(PlayerGlobalData playerGlobalData)
        {
            _playerGlobalData = playerGlobalData;
        }

        [Inject]
        private void Inject(GlobalGame globalGame)
        {
            _globalGame = globalGame;
        }

        private void Awake()
        {
            _levelStateMachine = new LevelStateMachine();

            _levelStateMachine.AddState(new InitializeLevelState(_levelStateMachine, _globalGame, this));
            _levelStateMachine.AddState(new GameOverLevelState(_levelStateMachine, _globalGame, this));
            _levelStateMachine.AddState(new FinishLevelState(_levelStateMachine, _globalGame));
            _levelStateMachine.AddState(new GameProcessLevelState(_levelStateMachine, _globalGame, this));

            _levelStateMachine.SetState<InitializeLevelState>();
        }

        private void OnEnable()
        {
            _playerGlobalData.Died += Die;
        }

        private void OnDisable()
        {
            _playerGlobalData.Died -= Die;
        }

        public void InitRunnerFeatures(LocationTypes type, int raceNumber)
        {
            _currentRunnerSettings = _allRunnerSettings[(int)type];

            _backgroundMusic.InitAudioClip(_currentRunnerSettings.AudioClip);
            _backgroundMusic.Play();
            _platformController.InitPlatforms(_currentRunnerSettings, 10);

        }

        public void StartRunner()
        {
            _isRunnerStarted = true;
            _canvasUI.DisableStartButton();
            _player.StartRun();
            _platformController.StartGameProcess();
            // ����������� 
        }

        public void StopRunner()
        {
            _isRunnerStarted = false;
            _canvasUI.EnableDeathPanel();
            _player.Die();
        }

        public void OnStartButtonClick()
        {
            _levelStateMachine.SetState<GameProcessLevelState>();
        }

        public void EndGame()
        {
            _levelStateMachine.SetState<FinishLevelState>();
        }

        private void Die()
        {
            _levelStateMachine.SetState<GameOverLevelState>();
        }


        // 1) ������������� 
        // - �������� ��� �������  ( �������� ��� ���), ����� ������ (�� ���� ������� ���������� ������, ���������� �����������(����� ������),
        // 2) �������������� ����� (� ������������� ���������)
        // 3) ������ ��������
        // 4) ������ ������ �������� ��������
        // 5) ��������� �������
        // + 6) ���� ����
    }
}

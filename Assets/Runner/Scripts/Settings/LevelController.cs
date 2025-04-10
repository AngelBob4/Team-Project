using MainGlobal;
using Reflex.Attributes;
using Runner.PlayerController;
using Runner.Settings.StateMachine;
using Runner.UI;
using UnityEngine;

namespace Runner.Settings
{
    public class LevelController : MonoBehaviour
    {
        [SerializeField] private EntryPoint _entryPoint;
        [SerializeField] private CanvasUI _canvasUI;
        [SerializeField] private Player _player;

        private LevelStateMachine _levelStateMachine;

        private PlayerGlobalData _playerGlobalData;
        private GlobalGame _globalGame;

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

            _levelStateMachine.AddState(new InitializeLevelState(_levelStateMachine, _globalGame, _entryPoint));
            _levelStateMachine.AddState(new GameOverLevelState(_levelStateMachine, _globalGame, _entryPoint, _player, _canvasUI));
            _levelStateMachine.AddState(new FinishLevelState(_levelStateMachine, _globalGame));
            _levelStateMachine.AddState(new GameProcessLevelState(_levelStateMachine, _globalGame, _entryPoint,_canvasUI));

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

       
        // 1) инициализация в энтри поинт
        // - передает вид раннера  ( кладбище или лес), номер забега (от него зависит количество врагов, количество препятствий(можно убрать),
        // 2) комбинирование мэшей (в инициализацию отправить)
        // 3) запуск обучения
        // 4) запуск самого игрового процесса
        // 5) окончание раннера
        // + 6) гейм овер
    }
}

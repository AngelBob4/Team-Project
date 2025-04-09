using MainGlobal;
using Reflex.Attributes;
using Runner.PlayerController;
using Runner.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Runner.Settings
{
    public class RunnerGameManager : MonoBehaviour
    {
        [SerializeField] private EntryPoint _entryPoint;
        [SerializeField] private Player _player;
        [SerializeField] private DeathPanel _deathPanel;
        [SerializeField] private GameObject _startButton;

        private GlobalGame _globalGame;
        private PlayerGlobalData _playerGlobalData;

        // 1) инициализация в энтри поинт
        // - передает вид раннера  ( кладбище или лес), номер забега (от него зависит количество врагов, количество препятствий(можно убрать),
        // 2) комбинирование мэшей (в инициализацию отправить)
        // 3) запуск обучения
        // 4) запуск самого игрового процесса
        // 5) окончание раннера

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

        private void OnEnable()
        {
            _playerGlobalData.Died += Die;
        }

        private void OnDisable()
        {
            _playerGlobalData.Died -= Die;
        }

        private void Start()
        {
            StartGame();
        }

        public void StartGame()
        {
            _entryPoint.InitAllSettingsForRunner(_globalGame.LocationRunnerTypes);
        }

        public void StartRunner()
        {
            _entryPoint.StartRunner();
            _startButton.gameObject.SetActive(false);
        }

        public void EndGame()
        {
            _globalGame.StartEvent();
        }


        public void LoadMainMenuScene()
        {
            SceneManager.LoadScene(0);
        }

        private void Die()
        {
            _entryPoint.StopRunner();
            _player.PlayerCollisions.DisableCollider();
            _player.PlayerAnimations.SetDeathAnimation();
            _deathPanel.gameObject.SetActive(true);
        }
    }
}

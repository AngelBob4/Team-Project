using MainGlobal;
using Reflex.Attributes;
using Runner.PlayerController;
using Runner.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

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
           // _entryPoint.StartRunner();
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
            _player.PlayerAnimations.SetDeathAnimation();
            _deathPanel.gameObject.SetActive(true);
        }
    }
}

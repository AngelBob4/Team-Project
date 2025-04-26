using Runner.ScriptableObjects;
using Runner.Settings;
using Runner.SoundSystem;
using UnityEngine;
using UnityEngine.UI;

namespace Runner.UI
{
    public class CanvasUI : MonoBehaviour
    {
        [SerializeField] private SoundControllerView _soundControllerView;
        [SerializeField] private DeathPanel _deathPanel;
        [SerializeField] private Button _startButton;
        [SerializeField] private Button _finishButton;

        private LevelController _levelController;
        
        public void Initialize(LevelController levelController,SoundController soundController)
        {
            _levelController = levelController;
            _soundControllerView.Initialize(soundController);
        }

        public void InitializeLevel(Level level)
        {
            _startButton.onClick.AddListener(_levelController.StartRunner);
            _finishButton.onClick.AddListener(_levelController.FinishRunner);


            if (level.LevelNumber == 1)
            {
                //_startButton.gameObject.SetActive(false);
                // запускаем обучение
            }
            else
            {
                _startButton.gameObject.SetActive(true);
            }
        }

        public void EnableDeathPanel()
        {
            _deathPanel.gameObject.SetActive(true);
        }

        public void StartGameProcess()
        {
            _startButton.gameObject.SetActive(false);
        }
    }
}
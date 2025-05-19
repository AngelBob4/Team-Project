using Runner.ScriptableObjects;
using Runner.Settings;
using Runner.SoundSystem;
using UnityEngine;
using UnityEngine.UI;

namespace Runner.UI
{
    public class CanvasUI : MonoBehaviour
    {
        [SerializeField] private EducationView _educationView;
        [SerializeField] private DeathPanel _deathPanel;
        [SerializeField] private Button _startButton;
        [SerializeField] private Button _finishButton;

        private LevelController _levelController;

        public LevelController LevelController =>_levelController;

        public void Initialize(LevelController levelController, SoundController soundController)
        {
            _levelController = levelController;
        }

        public void InitializeLevel(Level level)
        {
            _startButton.onClick.AddListener(_levelController.StartRunner);
            _finishButton.onClick.AddListener(_levelController.FinishRunner);


            if (level.LevelNumber == 1)
            {
                _educationView.gameObject.SetActive(true);
            }
            else
            {
                _educationView.gameObject.SetActive(false);
                _startButton.gameObject.SetActive(true);
            }
        }

        public void EnableDeathPanel(bool isActive)
        {
            _deathPanel.gameObject.SetActive(isActive);
        }

        public void StartGameProcess()
        {
            _startButton.gameObject.SetActive(false);
            _educationView.gameObject.SetActive(false);
        }
    }
}
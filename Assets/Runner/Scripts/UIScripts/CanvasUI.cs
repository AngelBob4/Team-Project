using Runner.ScriptableObjects;
using Runner.Settings;
using UnityEngine;
using UnityEngine.UI;

namespace Runner.UI
{
    public class CanvasUI : MonoBehaviour
    {
        [SerializeField] private DeathPanel _deathPanel;
        [SerializeField] private Button _startButton;

        private LevelController _levelController;

        public void Initialize(LevelController levelController)
        {
            _levelController = levelController;
        }

        public void InitializeLevel(Level level)
        {
            _startButton.onClick.AddListener(_levelController.StartRunner);

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
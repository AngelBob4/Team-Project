using UnityEngine;
using UnityEngine.UI;

namespace Runner.UI
{
    public class CanvasUI : MonoBehaviour
    {
        [SerializeField] private DeathPanel _deathPanel;
        [SerializeField] private Button _startButton;

        public void EnableDeathPanel()
        {
            _deathPanel.gameObject.SetActive(true);
        }

        public void DisableStartButton()
        {
            _startButton.gameObject.SetActive(false);
        }
    }
}
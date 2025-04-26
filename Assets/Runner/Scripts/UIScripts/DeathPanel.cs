using UnityEngine;
using UnityEngine.UI;

namespace Runner.UI
{
    public class DeathPanel : MonoBehaviour
    {
        [SerializeField] private Image _bloodImage;
        [SerializeField] private Button _restartButton;
        [SerializeField] private Button _watchAddButton;
        [SerializeField] private GameObject _advertisementPanel;
        [SerializeField] private Button _whatchAdd;
        [SerializeField] private Button _refuse;

        [SerializeField] private CanvasUI _canvasUI;

        private void Update()
        {
            // переделать на инвоук репитин или корутину
            StartBleeding();
        }

        private void StartBleeding()
        {
            int bloodImageMaxYPos = 604;
            int changeValue = -200;

            if (_bloodImage.transform.position.y > bloodImageMaxYPos)
            {
                _bloodImage.transform.position += new Vector3(0, changeValue, 0) * Time.deltaTime;
            }
        }

        public void OnRefuseButtonClick()
        {
            _restartButton.gameObject.SetActive(true);
            _advertisementPanel.SetActive(false);
        }

        public void OnWatchAddButtonClick()
        {
            //посмотреть рекламу
            _advertisementPanel.SetActive(true);
            _canvasUI.LevelController.ResurrectPlayer();
            // запустить процесс игры
        }
    }
}

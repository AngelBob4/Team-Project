using UnityEngine;
using UnityEngine.UI;

namespace Runner.UI
{
    public class DeathPanel : MonoBehaviour
    {
        [SerializeField] private Image _bloodImage;
        [SerializeField] private Button _restartButton;

        private void Update()
        {
            StartBleeding();
            MakeButtonVisible();
        }

        private void StartBleeding()
        {
            int bloodImageMaxYPos = 604;
            int changeValue = -200;

            if (_bloodImage.transform.position.y > bloodImageMaxYPos)
            {
                _bloodImage.transform.position += new Vector3(0, changeValue, 0) * Time.deltaTime;
            }

            MakeButtonVisible();
        }

        private void MakeButtonVisible()
        {
            int maxAColor = 255;
            float changeValue = 0.1f;

            if (_restartButton.image.color.a < maxAColor)
            {
                _restartButton.image.color = new Color(_restartButton.image.color.r, _restartButton.image.color.g, _restartButton.image.color.b,
                Mathf.MoveTowards(_restartButton.image.color.a, 1f, changeValue * Time.deltaTime));
            }
        }
    }
}

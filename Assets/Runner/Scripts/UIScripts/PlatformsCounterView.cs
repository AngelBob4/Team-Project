using Runner.PlatformsHandler;
using TMPro;
using UnityEngine;

namespace Runner.UI
{
    public class PlatformsCounterView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _platformsAmount;

        private PlatformsController _platformsController;

        private void OnEnable()
        {
           // _platformsController.Counter.PlatformsAmountChanged += OnPlatformsAmountChanged;
        }

        private void OnDisable()
        {
           // _platformsController.Counter.PlatformsAmountChanged -= OnPlatformsAmountChanged;
        }

        private void OnPlatformsAmountChanged(int meter)
        {
            //_platformsAmount.text = meter.ToString();
        }
    }
}

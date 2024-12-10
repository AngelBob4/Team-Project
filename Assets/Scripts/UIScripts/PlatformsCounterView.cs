using TMPro;
using UnityEngine;

public class PlatformsCounterView : MonoBehaviour
{
    [SerializeField] private TMP_Text _platformsAmount;
    [SerializeField] private PlatformsCounter _platformsCounter;

    private void OnEnable()
    {
        _platformsCounter.PlatformsAmountChanged += OnPlatformsAmountChanged;
    }

    private void OnDisable()
    {
        _platformsCounter.PlatformsAmountChanged -= OnPlatformsAmountChanged;
    }

    private void OnPlatformsAmountChanged(int meter)
    {
        _platformsAmount.text = meter.ToString();
    }
}

using System;
using UnityEngine;

public class PlatformsCounter : MonoBehaviour
{
    private int _lightIntensityModifier = -1;
    private int _meter = 1;
    private int _numerOfPlatformsToReduceLight = 5;
    private int _stableIndex = 5;

    [SerializeField] private Player _player;
   
    public int Meter => _meter;

    public event Action<int> PlatformsAmountChanged;

    private void Start()
    {
        PlatformsAmountChanged?.Invoke(_meter);
    }

    public void OnPlatformsAmountChanged()
    {
        ReduceLight();
        _meter++;
        PlatformsAmountChanged?.Invoke(_meter);
    }

    private void ReduceLight()
    {
        if (_meter >= _numerOfPlatformsToReduceLight)
        {
            _player.PlayerLantern.ChangeLanternLightIntensity(_lightIntensityModifier);
            _numerOfPlatformsToReduceLight += _stableIndex;
        }
    }
}

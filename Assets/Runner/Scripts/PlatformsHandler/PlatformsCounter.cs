using System;
using UnityEngine;
using Runner.PlayerController;

namespace Runner.PlatformsHandler
{
    public class PlatformsCounter : MonoBehaviour
    {
        [SerializeField] private Player _player;

        private int _lightIntensityModifier = -1;
        private int _meter = 1;
        private int _numberOfPlatformsToReduceLight = 5;
        private int _stableIndex = 5;

        public event Action<int> PlatformsAmountChanged;

        public int Meter => _meter;

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
            if (_meter >= _numberOfPlatformsToReduceLight)
            {
              //  _player.PlayerLantern.ChangeLanternLightIntensity(_lightIntensityModifier);
                _numberOfPlatformsToReduceLight += _stableIndex;
            }
        }
    }
}

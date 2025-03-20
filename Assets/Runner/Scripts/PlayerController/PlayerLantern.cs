using MainGlobal;
using Reflex.Attributes;
using System;
using UnityEngine;

namespace Runner.PlayerController
{
    public class PlayerLantern : MonoBehaviour
    {
        [SerializeField] private Light _lanternLight;

        public event Action<int> LanternLightChanged;

        private PlayerGlobalData _playerGlobalData;

        [Inject]
        private void Inject(PlayerGlobalData playerGlobalData)
        {
            _playerGlobalData = playerGlobalData;
        }

        private void Start()
        {
            SetValues();
        }

        public void ChangeLanternLightIntensity(int lightIntensityModifier)
        {
            _playerGlobalData.ChangeLanternLight(lightIntensityModifier);

            SetValues();
        }

        private void SetValues()
        {
            _lanternLight.intensity = (float)_playerGlobalData.LanternLight.CurrentValue;
            LanternLightChanged?.Invoke(_playerGlobalData.LanternLight.CurrentValue);
        }
    }
}

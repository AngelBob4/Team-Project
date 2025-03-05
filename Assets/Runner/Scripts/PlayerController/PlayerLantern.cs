using System;
using UnityEngine;

namespace Runner.PlayerController
{
    public class PlayerLantern : MonoBehaviour
    {
        [SerializeField] private Light _lanternLight;

        public event Action<float> LanternLightChanged;
      
        public void InitLanternIntensity(float lanternIntensity)
        {
            _lanternLight.intensity = lanternIntensity;
            LanternLightChanged?.Invoke(_lanternLight.intensity);
        }

        public void ChangeLanternLightIntensity(float lightIntensityModifier)
        {
            _lanternLight.intensity += lightIntensityModifier;
            LanternLightChanged?.Invoke(_lanternLight.intensity);
        }

        public float GetCurrentLanternLightIntensity()
        {
            return _lanternLight.intensity;
        }
    }
}

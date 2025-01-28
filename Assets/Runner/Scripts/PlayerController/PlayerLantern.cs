using UnityEngine;

namespace Runner.PlayerController
{
    public class PlayerLantern : MonoBehaviour
    {
        [SerializeField] private Light _lanternLight;

        public void InitLanternIntensity(float lanternIntensity)
        {
            _lanternLight.intensity = lanternIntensity;
        }

        public void ChangeLanternLightIntensity(float lightIntensityModifier)
        {
            _lanternLight.intensity += lightIntensityModifier;
        }

        public float GetCurrentLanternLightIntensity()
        {
            return _lanternLight.intensity;
        }
    }
}

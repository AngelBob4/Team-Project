using UnityEngine;

namespace Runner.PlayerController
{
    public class PlayerLantern : MonoBehaviour
    {
        [SerializeField] private Light _lanternLight;

        public void ChangeLanternLightIntensity(int lightIntensityModifier)
        {
            _lanternLight.intensity += lightIntensityModifier;
        }
    }
}

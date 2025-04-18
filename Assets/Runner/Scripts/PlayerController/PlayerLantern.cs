using UnityEngine;

namespace Runner.PlayerController
{
    public class PlayerLantern : MonoBehaviour
    {
        private const string ReduceLanternLight = nameof(ReduceLanternLighIntensity);

        [SerializeField] private Light _lanternLight;
        [SerializeField] private Player _player;

        private float _delay = 2f;
        private float _repeatRate = 3f;
        private int _lightDecreaseValue = -1;

        private void Start()
        {
            //SetValues();
        }

        public void ReduceLight()
        {

            InvokeRepeating(ReduceLanternLight, _delay, _repeatRate);
        }
        public void ChangeLanternLightIntensity(int lightIntensityModifier)
        {
            _player.PlayerGlobalData.ChangeLanternLight(lightIntensityModifier);
            SetValues();
        }

        private void ReduceLanternLighIntensity()
        {
            ChangeLanternLightIntensity(_lightDecreaseValue);
            SetValues();
        }

        private void SetValues()
        {
            _lanternLight.intensity = (float)_player.PlayerGlobalData.LanternLight.CurrentValue;
        }
    }
}

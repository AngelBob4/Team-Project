using Runner.PlayerController;
using TMPro;
using UnityEngine;

namespace Runner.UI
{
    public class LanternLightView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _lanternLightValue;
        [SerializeField] private Player _player;

        private void OnEnable()
        {
            _player.PlayerLantern.LanternLightChanged += OnPlayerLanternLightChanged;
        }

        private void OnDisable()
        {
            _player.PlayerLantern.LanternLightChanged -= OnPlayerLanternLightChanged;
        }

        private void OnPlayerLanternLightChanged(int lanternLight)
        {
            _lanternLightValue.text = lanternLight.ToString();
        }
    }
}

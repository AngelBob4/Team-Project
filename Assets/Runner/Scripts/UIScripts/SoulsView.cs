using Runner.PlayerController;
using TMPro;
using UnityEngine;

namespace Runner.UI
{
    public class SoulsView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _soulsValue;
        [SerializeField] private Player _player;

        private void OnEnable()
        {
            _player.PlayerLantern.LanternLightChanged += OnPlayerLanternLightChanged;
        }

        private void OnDisable()
        {
            _player.PlayerLantern.LanternLightChanged -= OnPlayerLanternLightChanged;
        }

        private void OnPlayerLanternLightChanged(float lanternLight)
        {
            _soulsValue.text = lanternLight.ToString();
        }
    }
}

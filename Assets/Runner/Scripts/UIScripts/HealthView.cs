using TMPro;
using UnityEngine;
using PlayerController;

namespace UI
{
    public class HealthView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _healthValue;
        [SerializeField] private Player _player;

        private void OnEnable()
        {
            _player.PlayerHealth.HealthChanged += OnPlayerHealthChanged;
        }

        private void OnDisable()
        {
            _player.PlayerHealth.HealthChanged -= OnPlayerHealthChanged;
        }

        private void OnPlayerHealthChanged(int health)
        {
            _healthValue.text = health.ToString();
        }
    }
}

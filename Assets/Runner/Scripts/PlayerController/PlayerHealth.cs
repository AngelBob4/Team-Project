using System;
using UnityEngine;

namespace Runner.PlayerController
{
    public class PlayerHealth : MonoBehaviour
    {
        private int _health;
        private int _maxHealth = 10;

        public event Action<int> HealthChanged;

        private void Start()
        {
            _health = _maxHealth;
            HealthChanged?.Invoke(_maxHealth);
        }

        public void InitHealth(int healthValueFromFighting)
        {
            _health = healthValueFromFighting;
            HealthChanged?.Invoke(_health);
        }

        public void OnHealthChanged(int healthChangeValue)
        {
            _health = Mathf.Clamp(_health + healthChangeValue, 0, _maxHealth);
            HealthChanged?.Invoke(_health);
        }

        public int GetCurrentHealthValue()
        {
            return _health;
        }
    }
}

using MainGlobal;
using Reflex.Attributes;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Runner.PlayerController
{
    public class PlayerHealth : MonoBehaviour
    {
        //private int _health;
        //private int _maxHealth = 10;
        private PlayerGlobalData _playerGlobalData;

        public event Action<int> HealthChanged;

        [Inject]
        private void Inject(PlayerGlobalData playerGlobalData)
        {
            _playerGlobalData = playerGlobalData;
        }

        private void Start()
        {
            HealthChanged?.Invoke(_playerGlobalData.HPBar.CurrentValue);
            //_health = _maxHealth;
            //HealthChanged?.Invoke(_maxHealth);
        }

        private void OnEnable()
        {
            _playerGlobalData.Died += Die;
        }

        private void OnDisable()
        {
            _playerGlobalData.Died -= Die;
        }

        //public void InitHealth(int healthValueFromFighting)
        //{
        //    //_health = healthValueFromFighting;
        //    //HealthChanged?.Invoke(_health);
        //}

        public void OnHealthChanged(int healthChangeValue)
        {
            _playerGlobalData.ChangeHP(healthChangeValue);

            //_health = Mathf.Clamp(_health + healthChangeValue, 0, _maxHealth);
            HealthChanged?.Invoke(_playerGlobalData.HPBar.CurrentValue);

            //if (_health <= 0)
            //{
            //    Die();
            //}
        }

        private void Die()
        {
            SceneManager.LoadScene(0);
        }
    }
}

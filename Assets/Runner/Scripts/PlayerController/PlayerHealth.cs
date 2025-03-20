using MainGlobal;
using Reflex.Attributes;
using System;
using UnityEngine;

namespace Runner.PlayerController
{
    public class PlayerHealth : MonoBehaviour
    {
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
        }

        public void OnHealthChanged(int healthChangeValue)
        {
            _playerGlobalData.ChangeHP(healthChangeValue);
            HealthChanged?.Invoke(_playerGlobalData.HPBar.CurrentValue);
        }
    }
}

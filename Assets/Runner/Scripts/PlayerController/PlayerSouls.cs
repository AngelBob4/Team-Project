using MainGlobal;
using Reflex.Attributes;
using System;
using UnityEngine;

namespace Runner.PlayerController
{
    public class PlayerSouls : MonoBehaviour
    {     
        private PlayerGlobalData _playerGlobalData;

        public event Action<int> SoulsAmountChanged;

        [Inject]
        private void Inject(PlayerGlobalData playerGlobalData)
        {
            _playerGlobalData = playerGlobalData;
        }

        private void Start()
        {
            SoulsAmountChanged?.Invoke(_playerGlobalData.Coins.CurrentValue);
        }

        public void ChangeSoulsAmount(int souls)
        {
           _playerGlobalData.ChangeCoins(souls);
           SoulsAmountChanged?.Invoke(_playerGlobalData.Coins.CurrentValue);
        }
    }
}

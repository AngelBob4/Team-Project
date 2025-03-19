using MainGlobal;
using Reflex.Attributes;
using System;
using UnityEngine;

namespace Runner.PlayerController
{
    public class PlayerSouls : MonoBehaviour
    {
        //[SerializeField] private int _souls;

        public event Action<int> SoulsAmountChanged;

        private PlayerGlobalData _playerGlobalData;

        [Inject]
        private void Inject(PlayerGlobalData playerGlobalData)
        {
            _playerGlobalData = playerGlobalData;
        }

        private void Start()
        {
            SoulsAmountChanged?.Invoke(_playerGlobalData.Coins.CurrentValue);
        }

        //public void InitSoulsAmount(int souls)
        //{
        //    _souls = souls;
        //   SoulsAmountChanged?.Invoke(_souls);
        //}

        public void ChangeSoulsAmount(int souls)
        {
           _playerGlobalData.ChangeCoins(souls);
           SoulsAmountChanged?.Invoke(_playerGlobalData.Coins.CurrentValue);
        }
    }
}

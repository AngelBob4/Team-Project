using System;
using UnityEngine;

namespace Runner.PlayerController
{
    public class PlayerSouls : MonoBehaviour
    {
        [SerializeField] private int _souls;

        public event Action<int> SoulsAmountChanged;

        public void InitSoulsAmount(int souls)
        {
            _souls = souls;
           SoulsAmountChanged?.Invoke(_souls);
        }

        public void ChangeSoulsAmount(int souls)
        {
            _souls += souls;
           SoulsAmountChanged?.Invoke(_souls);
        }

        public int GetCurrentSouls()
        {
            return _souls;
        }
    }
}

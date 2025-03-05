using System;
using UnityEngine;

namespace Runner.PlayerController
{
    public class PlayerSouls : MonoBehaviour
    {
        [SerializeField] private int _souls;

        public event Action<int> SoulsAmountChanged;

        public void InitLanternIntensity(int souls)
        {
            _souls = souls;
           SoulsAmountChanged?.Invoke(_souls);
        }

        public void ChangeLanternLightIntensity(int souls)
        {
            _souls = souls;
           SoulsAmountChanged?.Invoke(_souls);
        }

        public int GetCurrentSouls()
        {
            return _souls;
        }
    }
}

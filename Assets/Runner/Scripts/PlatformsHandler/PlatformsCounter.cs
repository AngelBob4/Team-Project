using System;
using UnityEngine;
using Runner.PlayerController;

namespace Runner.PlatformsHandler
{
    public class PlatformsCounter : MonoBehaviour
    {       
        private int _meter = 1;
       
        public event Action<int> PlatformsAmountChanged;

        public int Meter => _meter;

        private void Start()
        {
            PlatformsAmountChanged?.Invoke(_meter);
        }

        public void OnPlatformsAmountChanged()
        {
            _meter++;
            PlatformsAmountChanged?.Invoke(_meter);
        }
    }
}

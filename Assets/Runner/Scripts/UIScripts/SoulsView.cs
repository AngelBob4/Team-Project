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
            _player.PlayerSouls.SoulsAmountChanged += OnSoulsAmountChanged;
        }

        private void OnDisable()
        {
            _player.PlayerSouls.SoulsAmountChanged -= OnSoulsAmountChanged;
        }

        private void OnSoulsAmountChanged(int souls)
        {
            _soulsValue.text = souls.ToString();
        }
    }
}

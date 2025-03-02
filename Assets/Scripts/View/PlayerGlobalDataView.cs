using Events.View;
using MainGlobal;
using Reflex.Attributes;
using TMPro;
using UnityEngine;

namespace ViewGlobal
{
    public class PlayerGlobalDataView : MonoBehaviour
    {
        [SerializeField] private BarView _hPBarView;
        [SerializeField] private BarView _staminaBarView;
        [SerializeField] private BarView _coinsBarView;
        [SerializeField] private TMP_Text _countCards;

        private PlayerGlobalData _playerGlobalData;

        [Inject]
        private void Inject(PlayerGlobalData playerGlobalData)
        {
            _playerGlobalData = playerGlobalData;
        }

        private void Start()
        {
            SetPlayer();
        }

        private void OnEnable()
        {
            _playerGlobalData.Inited += SetPlayer;
            _playerGlobalData.UpdatedText += DrawText;
        }

        private void OnDisable()
        {
            _playerGlobalData.Inited -= SetPlayer;
            _playerGlobalData.UpdatedText -= DrawText;
        }

        private void SetPlayer()
        {
            if (_playerGlobalData == null)
                return;

            _hPBarView.SetBar(_playerGlobalData.HPBar);
            _staminaBarView.SetBar(_playerGlobalData.Stamina);
            _coinsBarView.SetBar(_playerGlobalData.Coins);
        }

        private void DrawText()
        {
            _countCards.text = _playerGlobalData.CardDataList.Count.ToString();
        }
    }
}

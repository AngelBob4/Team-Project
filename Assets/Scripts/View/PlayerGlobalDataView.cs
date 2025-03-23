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
        [SerializeField] private BarView _lanternLightBarView;
        [SerializeField] private BarView _coinsBarView;
        [SerializeField] private BarView _staminaBarView;
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
            //_playerGlobalData.Inited += SetPlayer;
            _playerGlobalData.UpdatedText += DrawText;
        }

        private void OnDisable()
        {
            //_playerGlobalData.Inited -= SetPlayer;
            _playerGlobalData.UpdatedText -= DrawText;
        }

        private void SetPlayer()
        {
            if (_playerGlobalData == null)
                return;

            Debug.Log("_hPBarView");
            _hPBarView.SetBar(_playerGlobalData.HPBar);

            Debug.Log("_lanternLightBarView");
            _lanternLightBarView.SetBar(_playerGlobalData.LanternLight);

            Debug.Log("_coinsBarView");
            _coinsBarView.SetBar(_playerGlobalData.Coins);

            Debug.Log("_staminaBarView");
            if (_staminaBarView != null)
            {
                _staminaBarView.SetBar(_playerGlobalData.Stamina);
            }
        }

        private void DrawText()
        {
            if (_countCards != null)
            {
                _countCards.text = _playerGlobalData.CardDataList.Count.ToString();
            }
        }
    }
}

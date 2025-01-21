using Events.Cards;
using Events.Main.CharactersBattle;
using Events.Main.LevelingUpPlayer;
using Events.View;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Events.MainGlobal
{
    public class PlayerGlobalData : MonoBehaviour
    {
        [SerializeField] private int _startHPMax;
        [SerializeField] private BarView _hPBarView;
        [SerializeField] private BarView _staminaBarView;
        [SerializeField] private BarView _coinsBarView;
        [SerializeField] private TMP_Text _countCards;
        [SerializeField] private PlayerBattle _playerBattle;
        [SerializeField] private CardDataList _startCardDataList;
        [SerializeField] private AddOneCardPanel _addOneCardPanel;

        public event Action Died;

        private const int StartStaminaMaxValue = 3;
        private const int StartCoinsValue = 100;
        private const int MaxStaminaMaxValue = 4;

        private Bar _hPBar;
        private Bar _stamina;
        private Bar _coins;
        private List<CardData> _cardDataList;

        public Bar HPBar => _hPBar;
        public Bar Stamina => _stamina;
        public Bar Coins => _coins;
        public IReadOnlyList<CardData> CardDataList => _cardDataList;

        private void Awake()
        {
            _startCardDataList.Init();
        }

        public void InitNewPlayer()
        {
            _hPBar = new Bar(_startHPMax);
            _hPBarView.SetBar(HPBar);

            //_hPBar.ChangeValue(-50);

            _stamina = new Bar(StartStaminaMaxValue);
            _staminaBarView.SetBar(_stamina);
            _stamina.ChangeValue(-1);

            _coins = new Bar();
            _coins.SetNewValues(StartCoinsValue);
            _coinsBarView.SetBar(_coins);

            _cardDataList = _startCardDataList.GetList();

            _playerBattle.InitNewPlayer();
            DrawText();
        }

        public void ChangeHP(int value)
        {
            _hPBar.ChangeValue(value);

            CheckAlive();
        }

        public void ChangeMaxHP(int value)
        {
            _hPBar.ChangeMaxValue(value);

            CheckAlive();
        }

        public void CheckAlive()
        {
            if (_hPBar.CurrentValue <= 0)
            {
                Died?.Invoke();
            }
        }

        public void AddCard(CardData card)
        {
            _cardDataList.Add(card);
            DrawText();
        }

        public void AddOnlyCard(CardData card)
        {
            AddCard(card);
            _addOneCardPanel.gameObject.SetActive(true);
            _addOneCardPanel.Init(new Card(card));
        }

        public void RemoveCard(CardData card)
        {
            _cardDataList.Remove(card);
            DrawText();
        }

        public void ChangeCoins(int coins)
        {
            _coins.ChangeValue(coins);
        }

        public bool TrySpendCoins(int coins)
        {
            if (coins < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            if (coins > _coins.CurrentValue)
            {
                return false;
            }
            else
            {
                ChangeCoins(-coins);
                return true;
            }
        }

        private void DrawText()
        {
            _countCards.text = _cardDataList.Count.ToString();
        }
    }
}

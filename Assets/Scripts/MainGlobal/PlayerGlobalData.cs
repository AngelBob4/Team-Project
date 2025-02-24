using Events.Cards;
using Events.Main.CharactersBattle;
using Events.Main.LevelingUpPlayer;
using Events.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using TMPro;
using UnityEngine;

namespace MainGlobal
{
    public class PlayerGlobalData
    {
        //[SerializeField] private AddOneCardPanel _addOneCardPanel;

        public event Action Inited;
        public event Action UpdatedText;
        public event Action Died;
        public event Action<Card> AddedOnlyCard;

        private const int StartStaminaMaxValue = 3;
        private const int MaxStaminaMaxValue = 4;

        private PlayerBattle _playerBattle;
        private CardDataList _startCardDataList;
        private int _startHPMax = 70;
        private int StartCoinsValue = 100;
        private Bar _hPBar;
        private Bar _stamina;
        private Bar _coins;
        private List<CardData> _cardDataList;
        //private PlayerBattleCharacterData _playerBattleCharacterData

        public Bar HPBar => _hPBar;
        public Bar Stamina => _stamina;
        public Bar Coins => _coins;
        public IReadOnlyList<CardData> CardDataList => _cardDataList;

        public PlayerGlobalData(CardDataList startCardDataList)
        {
            _startCardDataList = startCardDataList;
            _startCardDataList.Init();
            //_playerBattleCharacterData = playerBattleCharacterData;
        }

        public void SetPlayerBattle(PlayerBattle playerBattle)
        {
            _playerBattle = playerBattle;
        }

        public void InitNewPlayer()
        {
            if(_hPBar != null)
            {
                _hPBar.UpdatedBar -= CheckAlive;
            }

            _hPBar = new Bar(_startHPMax);
            //_hPBarView.SetBar(HPBar);

            _hPBar.UpdatedBar += CheckAlive;

            //_hPBar.ChangeValue(-50);

            _stamina = new Bar(StartStaminaMaxValue);
            //_staminaBarView.SetBar(_stamina);
            _stamina.ChangeValue(-1);

            _coins = new Bar();
            _coins.SetNewValues(StartCoinsValue);
            //_coinsBarView.SetBar(_coins);

            _cardDataList = _startCardDataList.GetList();
            //_playerBattleCharacterData.InitNewPlayer()
            //_playerBattle.InitNewPlayer();

            Inited?.Invoke();
            DrawText();
        }

        public void ChangeHP(int value)
        {
            _hPBar.ChangeValue(value);
        }

        public void ChangeMaxHP(int value)
        {
            _hPBar.ChangeMaxValue(value);
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
            AddedOnlyCard?.Invoke(new Card(card));
            //_addOneCardPanel.gameObject.SetActive(true);
            //_addOneCardPanel.Init(new Card(card));
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
            UpdatedText?.Invoke();
        }
    }
}

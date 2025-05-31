using Events.Cards;
using Events.Main.CharactersBattle;
using MapSection.MapUI;
using System;
using System.Collections.Generic;
using UnityEngine;
using YG;

namespace MainGlobal
{
    public class PlayerGlobalData
    {
        public event Action Inited;
        public event Action UpdatedText;
        public event Action Died;
        public event Action<Card> AddedOnlyCard;

        //private const int StartStaminaMaxValue = 3;
        //private const int MaxStaminaMaxValue = 4;

        private PlayerBattle _playerBattle;
        private CardDataList _startCardDataList;
        private int _startHPMax = 70;
        private int _startCoinsValue = 100;
        private int _startLanternLightMax = 9;
        private Bar _hPBar;
        //private Bar _stamina;
        private Bar _coins;
        private Bar _lanternLight;
        private List<CardData> _cardDataList;

        public int StartHPMax => _startHPMax;
        public int StartLanternLightMax => _startLanternLightMax;

        public Bar HPBar => _hPBar;
        // Bar Stamina => _stamina;
        public Bar Coins => _coins;
        public Bar LanternLight => _lanternLight;
        public IReadOnlyList<CardData> CardDataList => _cardDataList;
        public bool IsHPFilled => HPBar.CurrentValue == HPBar.MaxValue;
        public bool IsLanternLightFilled => LanternLight.CurrentValue == LanternLight.MaxValue;

        public PlayerGlobalData(CardDataList startCardDataList)
        {
            _startCardDataList = startCardDataList;
            _startCardDataList.Init();
        }

        public void SetPlayerBattle(PlayerBattle playerBattle)
        {
            _playerBattle = playerBattle;
        }

        public void InitNewPlayer()
        {
            if (_hPBar != null)
            {
                _hPBar.UpdatedBar -= CheckAlive;
            }

            _hPBar = new Bar(_startHPMax);

            _hPBar.UpdatedBar += CheckAlive;

            //_stamina = new Bar(StartStaminaMaxValue);

            _coins = new Bar();
            _coins.SetNewValues(_startCoinsValue);

            _lanternLight = new Bar(_startLanternLightMax);

            _cardDataList = _startCardDataList.GetList();

            Inited?.Invoke();
            DrawText();
        }

        public void LoadPlayerStats()
        {
            _coins.SetValues(YandexGame.savesData.Coins);
            _lanternLight.SetValues(YandexGame.savesData.LanternLight);
            _hPBar.SetNewValues(YandexGame.savesData.MaxHP);
            _hPBar.SetValues(YandexGame.savesData.HP);

            _cardDataList.Clear();

            foreach (CardDataSave cardDataSave in YandexGame.savesData.CardDataSaveList)
            {
                _cardDataList.Add(new CardData(cardDataSave));
            }
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
        }

        public void RemoveCard(CardData card)
        {
            _cardDataList.Remove(card);
            DrawText();
        }

        public void ChangeCoins(int coins)
        {
            _coins.ChangeValue(coins);

            YandexGame.GetLeaderboard(MapCanvasUI.LeaderboardName, 10, 3, 3, "small");
            YandexGame.NewLeaderboardScores(MapCanvasUI.LeaderboardName, _coins.CurrentValue);
            UnityEngine.Debug.Log(_coins.CurrentValue);
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

        public void ChangeLanternLight(int lanternLight)
        {
            _lanternLight.ChangeValue(lanternLight);
        }

        private void DrawText()
        {
            UpdatedText?.Invoke();
        }
    }
}
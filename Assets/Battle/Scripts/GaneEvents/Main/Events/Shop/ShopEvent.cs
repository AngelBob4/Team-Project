using Events.Cards;
using MainGlobal;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Events.Main.Events.Shop
{
    public class ShopEvent : GameEvent
    {
        [SerializeField] private CardShop _cardShopPrefab;
        [SerializeField] private Transform _containerCards;
        [SerializeField] private CardDataList _cardDataList;
        [SerializeField] private PlayerGlobalData _playerGlobalData;
        [SerializeField] private ChooseImproveCardPanel _chooseImproveCardPanel;
        [SerializeField] private Button _improveCardButton;
        [SerializeField] private TMP_Text _priceRemoveCardText;
        [SerializeField] private TMP_Text _priceAddStaminaText;

        public override event Action FinishedEvent;

        private readonly int _priceRemoveCard = 75;
        private readonly int _priceAddStamina = 50;
        private readonly int _quantityCardShop = 5;
        private readonly int _priceLevelModifier = 50;

        private List<CardShop> _cards = new List<CardShop>();

        private void Awake()
        {
            _cardDataList.Init();
        }

        private void OnEnable()
        {
            foreach (CardShop cardShop in _cards)
            {
                cardShop.OnClick += TrySellCard;
            }
        }

        private void OnDisable()
        {
            foreach (CardShop cardShop in _cards)
            {
                cardShop.OnClick -= TrySellCard;
            }
        }

        public override void StartEvent(int level)
        {
            Init();
        }

        public void Init()
        {
            ClearCards();
            _improveCardButton.interactable = true;

            _priceRemoveCardText.text = _priceRemoveCard.ToString();
            _priceAddStaminaText.text = _priceAddStamina.ToString();

            for (int i = 0; i < _quantityCardShop; i++)
            {
                CardShop newCardShop = Instantiate(_cardShopPrefab, _containerCards);
                newCardShop.Init(_cardDataList.GetRandomCardData(), _priceLevelModifier);

                newCardShop.OnClick += TrySellCard;
                _cards.Add(newCardShop);
            }
        }

        public void AddStamina()
        {
            if (_playerGlobalData.Stamina.CurrentValue < _playerGlobalData.Stamina.MaxValue
                && _playerGlobalData.TrySpendCoins(_priceAddStamina))
            {
                _playerGlobalData.Stamina.AddOneValue();
            }
        }

        public void ImproveCard()
        {
            if (_playerGlobalData.TrySpendCoins(_priceRemoveCard))
            {
                _chooseImproveCardPanel.gameObject.SetActive(true);
                _chooseImproveCardPanel.Init();
                _improveCardButton.interactable = false;
            }
        }

        public void AddOilToLamp()
        {

        }

        public void Exit()
        {
            gameObject.SetActive(false);
            FinishedEvent?.Invoke();
        }

        private void ClearCards()
        {
            foreach (CardShop _card in _cards)
            {
                Destroy(_card.gameObject);
            }

            _cards.Clear();
        }

        private void TrySellCard(CardShop cardShop)
        {
            if (_playerGlobalData.TrySpendCoins(cardShop.Price))
            {
                cardShop.SellCard();
                _playerGlobalData.AddCard(cardShop.CardData);
            }
        }
    }
}

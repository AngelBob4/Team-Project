using Events.Cards;
using Events.MainGlobal.ChooseInAllPlayerCards;
using MainGlobal;
using Reflex.Attributes;
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
        [SerializeField] private ChooseImproveCardPanel _chooseImproveCardPanel;
        [SerializeField] private Button _improveCardButton;
        [SerializeField] private Button _restButton;
        [SerializeField] private TMP_Text _priceImproveCardText;
        [SerializeField] private TMP_Text _priceRestText;
        [SerializeField] private TMP_Text _effectRestText;

        private readonly int _priceImproveCard = 75;
        private readonly int _priceRest = 70;
        private readonly int _addLanternLight = 5;
        private readonly int _addHP = 30;
        private readonly int _quantityCardShop = 5;
        private readonly int _priceLevelModifier = 50;

        private PlayerGlobalData _playerGlobalData;
        private List<CardShop> _cards = new List<CardShop>();



        [Inject]
        private void Inject(PlayerGlobalData playerGlobalData)
        {
            _playerGlobalData = playerGlobalData;
        }

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
            InitCards();
            
            _improveCardButton.interactable = true;
            _restButton.interactable = true;

            DrawText();
        }

        public void OnClickButtonRest()
        {
            if (_playerGlobalData.TrySpendCoins(_priceRest) && (_playerGlobalData.IsHPFilled == false || _playerGlobalData.IsLanternLightFilled == false))
            {
                _playerGlobalData.HPBar.ChangeValue(_addHP);
                _playerGlobalData.LanternLight.ChangeValue(_addLanternLight);

                _restButton.interactable = false;
            }
        }

        public void OnClickButtonImproveCard()
        {
            if (_playerGlobalData.TrySpendCoins(_priceImproveCard))
            {
                _chooseImproveCardPanel.gameObject.SetActive(true);
                _chooseImproveCardPanel.Init();

                _improveCardButton.interactable = false;
            }
        }

        private void InitCards()
        {
            for (int i = 0; i < _quantityCardShop; i++)
            {
                CardShop newCardShop = Instantiate(_cardShopPrefab, _containerCards);
                newCardShop.Init(_cardDataList.GetRandomCardData(), _priceLevelModifier);

                newCardShop.OnClick += TrySellCard;
                _cards.Add(newCardShop);
            }
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

        private void DrawText()
        {
            _priceImproveCardText.text = _priceImproveCard.ToString();
            _priceRestText.text = _priceRest.ToString();
            _effectRestText.text = $"[+{_addLanternLight} ÔÎÍÀÐß]\r\n[+{_addHP} HP]";
        }
    }
}
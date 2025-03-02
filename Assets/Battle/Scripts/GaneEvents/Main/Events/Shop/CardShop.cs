using Events.Cards;
using Events.View;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Events.Main.Events.Shop
{
    public class CardShop : MonoBehaviour
    {
        [SerializeField] private CardView _cardView;
        [SerializeField] private Image _sold;
        [SerializeField] private TMP_Text _priceText;

        public event Action<CardShop> OnClick;

        private Card _card;
        private int _price;

        public CardData CardData => _card.Data;
        public int Price => _price;

        private void OnEnable()
        {
            if (_card != null)
            {
                _card.OnClick += OnClickCard;
            }
        }

        private void OnDisable()
        {
            if (_card != null)
            {
                _card.OnClick -= OnClickCard;
            }
        }

        public void Init(CardData cardData, int priceLevelModifier)
        {
            _card = new Card(cardData);
            _price = cardData.Level * priceLevelModifier;

            _cardView.Draw(_card);
            _priceText.text = _price.ToString();

            _card.OnClick += OnClickCard;
        }

        public void SellCard()
        {
            _sold.gameObject.SetActive(true);
        }

        private void OnClickCard(Card card)
        {
            OnClick?.Invoke(this);
        }
    }
}
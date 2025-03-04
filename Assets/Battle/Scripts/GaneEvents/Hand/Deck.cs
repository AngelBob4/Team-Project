using Events.Cards;
using System;
using System.Collections.Generic;

namespace Events.Hand
{
    public class Deck: IReadOnlyDeck
    {
        protected List<Card> _cards = new List<Card>();
        private int _maxCards;

        public event Action<Card> OnClickCardFromDeck;
        public event Action UpdatedDeck;

        public Deck(int maxCards = -1)
        {
            _maxCards = maxCards;
        }

        public int GetCardsCount()
        {
            return _cards.Count;
        }

        public void AddCard(Card card)
        {
            if (CanAddCard(card) == false)
                throw new Exception($"There is no such card ({card}) in your hand");

            card.OnClick += OnClickCardFromDeck;
            _cards.Add(card);

            UpdatedDeck?.Invoke();
        }

        public void RemoveCard(Card card)
        {
            if (CanRemoveCard(card) == false)
                throw new Exception($"This card ({card}) cannot be removed from the hand");

            card.OnClick -= OnClickCardFromDeck;
            _cards.Remove(card);
            UpdatedDeck?.Invoke();
        }

        public virtual bool CanAddCard(Card card)
        {
            if (_maxCards < 0)
                return true;

            return _cards.Count < _maxCards;
        }

        public virtual bool CanRemoveCard(Card card)
        {
            return _cards.Contains(card);
        }

        public void Clear()
        {
            while (_cards.Count > 0)
            {
                RemoveCard(_cards[_cards.Count - 1]);
            }

            UpdatedDeck?.Invoke();
        }

        public Card GetRandomCard()
        {
            if (_cards.Count == 0)
                return null;

            return _cards[UnityEngine.Random.Range(0, _cards.Count)];
        }

        public IReadOnlyList<Card> GetAllCards()
        {
            return _cards;
        }

        public void SetDeck(IReadOnlyList<CardData> cardDataList)
        {
            _cards.Clear();

            foreach (var cardData in cardDataList)
            {
                AddCard(new Card(cardData));
            }

            UpdatedDeck?.Invoke();
        }
    }
}

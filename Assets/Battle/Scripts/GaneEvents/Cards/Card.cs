using System;
using UnityEngine;

namespace Events.Cards
{
    public class Card
    {
        public event Action<Card> OnClick;
        public event Action TakenDamage;
        public event Action<Transform> MovedCard;

        private CardData _cardData;

        public CardData Data => _cardData;

        public Card(CardData cardData)
        {
            _cardData = cardData;
        }

        public void ButtonOnClick()
        {
            OnClick?.Invoke(this);
        }

        public void TakeDamage()
        {
            TakenDamage?.Invoke();
        }

        public void MoveCard(Transform transform)
        {
            Debug.Log("Card.MoveCard");
            MovedCard?.Invoke(transform);
        }
    }
}
using Events.View;
using System;
using UnityEngine;

namespace Events.Cards
{
    public class Card
    {
        public event Action<Card> OnClick;
        public event Action TakenDamage;
        //public event Action<Transform> MovedCard;
        //public event Action<Transform, Transform> MovedCard;

        private CardData _cardData;
        private CardView _cardView;

        public CardData Data => _cardData;
        public CardView CardView => _cardView;

        public Card(CardData cardData)
        {
            _cardData = cardData;
        }

        public void SetCardView(CardView cardView)
        {
            _cardView = cardView;
        }

        public void ButtonOnClick()
        {
            OnClick?.Invoke(this);
        }

        public void TakeDamage()
        {
            TakenDamage?.Invoke();
        }

        public void MoveCard(Transform endTransform)
        {
            Debug.Log("Card.MoveCard");
            if(_cardView == null)
                return;

            _cardView.PlayAnimationMoveCard(endTransform);
            //MovedCard?.Invoke(transform);
        }

        public void MoveCard(Vector3 startTransform, Transform endTransform)
        {
            Debug.Log("Card.MoveCard");
            if (_cardView == null)
                return;

            _cardView.PlayAnimationMoveCard(startTransform, endTransform);
            //MovedCard?.Invoke(transform);
        }
    }
}
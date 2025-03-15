using System;

namespace Events.Cards
{
    public class Card
    {
        public event Action<Card> OnClick;
        public event Action TakenDamage;

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
    }
}
using System;

namespace Events.Cards
{
    public class Card
    {
        public event Action<Card> OnClick;

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
    }
}
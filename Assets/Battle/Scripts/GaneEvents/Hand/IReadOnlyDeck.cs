using Events.Cards;
using System.Collections.Generic;

namespace Events.Hand
{
    public interface IReadOnlyDeck
    {
        public int GetCardsCount();

        public IReadOnlyList<Card> GetAllCards();
    }
}

using Events.Cards;
using System.Collections.Generic;

namespace Events.Hand
{
    public interface IDeck
    {
        public void AddCard(Card card);
        public void RemoveCard(Card card);
        public bool CanAddCard(Card card);
        public bool CanRemoveCard(Card card);
        public IReadOnlyList<Card> GetAllCards();
        public void Clear();
    }
}

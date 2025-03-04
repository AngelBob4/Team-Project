using Events.Cards;
using System.Collections.Generic;
using System.Linq;

namespace Events.Hand
{
    public class CombinationDeck : Deck
    {
        private int _effects;
        private List<CardType> _cardsType = new List<CardType>();

        public int CardsCount => _cards.Count;

        public CombinationDeck(int i = -1) : base(i)
        {

        }

        public List<CardType> GetCardsType()
        {
            _cardsType.Clear();

            foreach (Card card in _cards)
            {
                if (_cardsType.Contains(card.Data.Type) == false)
                {
                    _cardsType.Add(card.Data.Type);
                }
            }

            return _cardsType;
        }

        public int GetEffects(CardEffectType cardEffectType)
        {
            _effects = 0;

            for (int i = 0; i < _cards.Count; i++)
            {
                _effects += GetEffectsCard(_cards[i], cardEffectType);

                if (
                    i < _cards.Count - 1
                    && CheckEffectsCardCombination(_cards[i], _cards[i + 1].Data.Type, cardEffectType)
                    )
                {
                    _effects++;
                }
            }

            return _effects;

            int GetEffectsCard(Card card, CardEffectType cardEffectType)
            {
                switch (cardEffectType)
                {
                    case CardEffectType.Wound:
                        return card.Data.Wound;

                    case CardEffectType.Shield:
                        return card.Data.Shield;

                    case CardEffectType.TakeCards:
                        return card.Data.Cards;

                    default:
                        return 0;
                }
            }

            bool CheckEffectsCardCombination(Card card, CardType cardType, CardEffectType cardEffectType)
            {
                return card.Data.Combinations[cardType] == cardEffectType;
            }
        }


        public override bool CanAddCard(Card card)
        {
            if (base.CanAddCard(card))
                return _cards.Count == 0 || GetFurtherCombination().Contains(card.Data.Type);

            return false;
        }

        public override bool CanRemoveCard(Card card)
        {
            if (base.CanRemoveCard(card))
                return _cards[0] == card || _cards[_cards.Count - 1] == card;

            return false;
        }

        private List<CardType> GetFurtherCombination()
        {
            return _cards[_cards.Count - 1].Data.Combinations.Keys.ToList();
        }
    }
}
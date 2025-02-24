using Events.Cards;
using System;

namespace Events.View
{
    public interface IColorForCardType
    {
        public event Action UpdatedColor;

        public CardType CardType { get; }
    }
}

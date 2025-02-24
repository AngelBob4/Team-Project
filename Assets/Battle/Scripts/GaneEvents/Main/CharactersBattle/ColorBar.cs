using Events.Cards;
using Events.View;
using System;

namespace Events.Main.CharactersBattle
{
    public class ColorBar : Bar, IColorForCardType
    {
        private CardType _cardType = CardType.Null;

        public CardType CardType => _cardType;

        public event Action UpdatedColor;

        public ColorBar() : base() { }

        public ColorBar(int maxValue) : base(maxValue) { }

        public void SetCardTypeCorol(CardType type)
        {
            _cardType = type;
            UpdatedColor?.Invoke();
        }

        public void SetCardTypeDefolt()
        {
            SetCardTypeCorol(CardType.Null);
        }

        public void SetNewValues(int value, CardType cardType = CardType.Null)
        {
            SetCardTypeCorol(cardType);
            base.SetNewValues(value);
        }

        public override void SetValueDefault()
        {
            base.SetValueDefault();

            SetCardTypeDefolt();
        }
    }
}

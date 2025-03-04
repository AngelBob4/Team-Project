using Events.Cards;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Events.View
{
    public class CardView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _name;
        [SerializeField] private Image _cardImage;
        [SerializeField] private TMP_Text _wound;
        [SerializeField] private TMP_Text _shield;
        [SerializeField] private TMP_Text _cards;
        [SerializeField] private CardCombinationsView _blueCombinations;
        [SerializeField] private CardCombinationsView _purpleCombinations;
        [SerializeField] private CardCombinationsView _greenCombinations;
        [SerializeField] private CardCombinationsView _yellowCombinations;
        [SerializeField] private CardCombinationsView _redCombinations;
        [SerializeField] private CardColorData _cardColorData;
        [SerializeField] private Color _colorDefault;

        private Card _card;

        public void Draw(Card card)
        {
            _card = card;

            _name.text = _card.Data.Name;
            _wound.text = _card.Data.Wound.ToString();
            _shield.text = _card.Data.Shield.ToString();
            _cards.text = _card.Data.Cards.ToString();

            _cardImage.color = _cardColorData.Colors[_card.Data.Type];

            SetColorCombinations(_card.Data.Combinations);
        }

        public void ButtonOnClick()
        {
            _card.ButtonOnClick();
        }

        private void SetColorCombinations(IReadOnlyDictionary<CardType, CardEffectType> combinations)
        {
            SetColorCombination(_blueCombinations, CardType.Blue);
            SetColorCombination(_purpleCombinations, CardType.Purple);
            SetColorCombination(_greenCombinations, CardType.Green);
            SetColorCombination(_yellowCombinations, CardType.Yellow);
            SetColorCombination(_redCombinations, CardType.Red);

            void SetColorCombination(CardCombinationsView combinationsView, CardType type)
            {
                if (combinations.ContainsKey(type))
                {
                    combinationsView.Draw(_cardColorData.Colors[type], combinations[type]);
                }
                else
                {
                    combinationsView.Draw(_colorDefault);
                }
            }
        }
    }
}
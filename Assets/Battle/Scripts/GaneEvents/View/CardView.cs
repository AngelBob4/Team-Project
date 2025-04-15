using Events.Animation;
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
        [SerializeField] private AnimationDamageCard _animationDamageCard;
        [SerializeField] private AnimationMoveCard _animationMoveCard;

        private Card _card;

        private void OnEnable()
        {
            Subscribe();
        }

        private void OnDisable()
        {
            Unsubscribe();
        }

        public void Draw(Card card)
        {
            _card = card;
            Subscribe();

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

        public void PlayAnimationMoveCard(Transform endTransform)
        {
            Debug.Log("CardView.PlayAnimationMoveCard");
            _animationMoveCard.Play(endTransform);
        }

        public void PlayAnimationMoveCard(Vector3 startTransform, Transform endTransform)
        {
            Debug.Log("CardView.PlayAnimationMoveCard");
            _animationMoveCard.Play(startTransform, endTransform);
        }

        private void PlayAnimationDamageCard()
        {
            _animationDamageCard.Play();
        }

        private void Subscribe()
        {
            if (_card != null)
            {
                Debug.Log("OnEnable");
                _card.TakenDamage += PlayAnimationDamageCard;
                _card.SetCardView(this);
                //_card.MovedCard += PlayAnimationMoveCard;
            }
        }

        private void Unsubscribe()
        {
            if (_card != null)
            {
                Debug.Log("OnDisable");
                _card.TakenDamage -= PlayAnimationDamageCard;

                if (_card.CardView == this)
                {
                    _card.SetCardView(null);
                }
                //_card.MovedCard -= PlayAnimationMoveCard;
            }
        }
    }
}
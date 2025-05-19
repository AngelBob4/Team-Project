using AYellowpaper.SerializedCollections;
using Events.Animation;
using Events.Cards;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Events.View
{
    public class CardView : MonoBehaviour
    {
        //[SerializeField] private TMP_Text _name;
        //[SerializeField] private Image _cardImage;
        [SerializeField] private Image _frameworkImage;
        [SerializeField] private Image _backgroundImage;
        [SerializeField] private Image _starsImage;
        
        [Header("Card EffectType Image")]
        [SerializeField] private Image _woundImage;
        [SerializeField] private Image _woundRedImage;
        [SerializeField] private Image _shieldImage;
        [SerializeField] private Image _cardsImage;

        [Header("Card Combinations View")]
        [SerializeField] private CardCombinationsView _combinationNull;
        [SerializeField] private CardCombinationsView _combinationFirst;
        [SerializeField] private CardCombinationsView _combinationSecond;
        //[SerializeField] private CardCombinationsView _yellowCombinations;
        //[SerializeField] private CardCombinationsView _redCombinations;
        //[SerializeField] private CardColorData _cardColorData;
        //[SerializeField] private Color _colorDefault;

        [Header("Animation")]
        [SerializeField] private AnimationDamageCard _animationDamageCard;
        [SerializeField] private AnimationMoveCard _animationMoveCard;

        [Header("Dictionary Images")]
        [SerializeField]
        [SerializedDictionary("LVL", "Framework")]
        private SerializedDictionary<int, Sprite> _stars;

        [SerializeField]
        [SerializedDictionary("CardType", "Framework")]
        private SerializedDictionary<CardType, Sprite> _frameworks;
        
        [SerializeField]
        [SerializedDictionary("CardType", "Background")]
        private SerializedDictionary<CardType, Sprite> _backgrounds;

        private readonly int _maxCombinations = 2;

        private Card _card;
        private List<CardCombinationsView> _cardCombinationList;

        private void Awake()
        {
            _cardCombinationList = new List<CardCombinationsView>() { _combinationFirst, _combinationSecond };
        }

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

            _woundImage.gameObject.SetActive(false);
            _woundRedImage.gameObject.SetActive(false);
            _shieldImage.gameObject.SetActive(false);
            _cardsImage.gameObject.SetActive(false);

            switch (_card.Data.Type)
            {
                case CardType.Green:
                    _shieldImage.gameObject.SetActive(true);
                    break;
                    
                case CardType.Red:
                    _woundRedImage.gameObject.SetActive(true);
                    break;
                    
                case CardType.Purple:
                    _cardsImage.gameObject.SetActive(true);
                    break;

                default:
                    _woundImage.gameObject.SetActive(true);
                    break;
            }

            _frameworkImage.sprite = _frameworks[_card.Data.Type];
            _backgroundImage.sprite = _backgrounds[_card.Data.Type];
            _starsImage.sprite = _stars[_card.Data.Level];
            ///_name.text = _card.Data.Name;
            ///_wound.text = _card.Data.Wound.ToString();
            ///_shield.text = _card.Data.Shield.ToString();
            ///_cards.text = _card.Data.Cards.ToString();
            ///
            ///_cardImage.color = _cardColorData.Colors[_card.Data.Type];

            DrawCombinations(_card.Data.Combinations);
        }

        public void ButtonOnClick()
        {
            _card.ButtonOnClick();
        }

        private void DrawCombinations(IReadOnlyDictionary<CardType, CardEffectType> combinations)
        {
            _combinationNull.gameObject.SetActive(false);
            _combinationFirst.gameObject.SetActive(false);
            _combinationSecond.gameObject.SetActive(false);

            if (combinations.Count == 0)
                return;

            if (combinations.Count != _maxCombinations)
            {
                _combinationNull.gameObject.SetActive(true);
            }

            List<CardType> combinationList = combinations.Keys.ToList();

            for (int i = 0; i < combinationList.Count; i++)
            {
                DrawCombination(_cardCombinationList[i], combinationList[i], combinations[combinationList[i]]);
            }

            void DrawCombination(CardCombinationsView combinationsView, CardType type, CardEffectType cardEffectType)
            {
                combinationsView.gameObject.SetActive(true);
                combinationsView.Draw(type, cardEffectType);
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
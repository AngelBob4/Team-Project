using AYellowpaper.SerializedCollections;
using Events.Cards;
using UnityEngine;
using UnityEngine.UI;

namespace Events.View
{
    [RequireComponent(typeof(Image))]
    public class CardCombinationsView : MonoBehaviour
    {
        //[SerializeField] private Image _wound;
        [SerializeField] private Image _shield;
        [SerializeField] private Image _cards;

        [SerializeField]
        [SerializedDictionary("CardType", "Sprite")]
        private SerializedDictionary<CardType, Sprite> _combinationsSprite;

        private Image _combinations;

        private void Awake()
        {
            //_wound.gameObject.SetActive(false);
            _shield.gameObject.SetActive(false);
            _cards.gameObject.SetActive(false);

            _combinations = GetComponent<Image>();
        }

        public void Draw(CardType cardType, CardEffectType bonusType = CardEffectType.Null)
        {
            _combinations.sprite = _combinationsSprite[cardType];

            switch (bonusType)
            {
                //case CardEffectType.Wound:
                //    _wound.gameObject.SetActive(true);
                //    break;

                case CardEffectType.Shield:
                    _shield.gameObject.SetActive(true);
                    break;

                case CardEffectType.TakeCards:
                    _cards.gameObject.SetActive(true);
                    break;
            }
        }
    }
}

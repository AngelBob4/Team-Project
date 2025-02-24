using Events.Cards;
using Events.Hand;
using TMPro;
using UnityEngine;

namespace Events.View
{
    public class CardEffectsView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _woundText;
        [SerializeField] private TMP_Text _shieldText;
        [SerializeField] private TMP_Text _cardsText;

        private readonly string _nullValue = "0";

        private CombinationDeck _combinationHand;

        private void OnEnable()
        {
            Subscribe();
        }

        private void OnDisable()
        {
            Unsubscribe();
        }

        public void SetCombinationHand(CombinationDeck combinationHand)
        {
            Unsubscribe();
            _combinationHand = combinationHand;
            Subscribe();
        }

        public void DrawNull()
        {
            _woundText.text = _nullValue;
            _shieldText.text = _nullValue;
            _cardsText.text = _nullValue;
        }

        public void Draw()
        {
            _woundText.text = _combinationHand.GetEffects(CardEffectType.Wound).ToString();
            _shieldText.text = _combinationHand.GetEffects(CardEffectType.Shield).ToString();
            _cardsText.text = _combinationHand.GetEffects(CardEffectType.TakeCards).ToString();
        }

        private void Subscribe()
        {
            if (_combinationHand != null)
            {
                _combinationHand.UpdatedDeck += Draw;
                Draw();
            }
        }

        private void Unsubscribe()
        {
            if (_combinationHand != null)
            {
                _combinationHand.UpdatedDeck -= Draw;
                DrawNull();
            }
        }
    }
}

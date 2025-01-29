using Events.Cards;
using Events.Hand;
using Events.View;
using UnityEngine;

namespace Events.MainGlobal
{
    public class RemoveCardPanel : MonoBehaviour
    {
        [SerializeField] private DeckView _deckView;
        [SerializeField] private PlayerGlobalData _playerGlobalData;

        private Deck _deck = new Deck();

        private void Awake()
        {
            _deckView.SetDeck(_deck);
        }

        private void OnEnable()
        {
            _deck.OnClickCardFromDeck += OnClickCard;
        }

        private void OnDisable()
        {
            _deck.OnClickCardFromDeck -= OnClickCard;
        }

        public void Init()
        {
            _deck.SetDeck(_playerGlobalData.CardDataList);
        }

        private void OnClickCard(Card card)
        {
            _playerGlobalData.RemoveCard(card.Data);

            gameObject.SetActive(false);
        }
    }
}

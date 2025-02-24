using Events.Cards;
using Events.Hand;
using MainGlobal;
using Events.View;
using UnityEngine;

namespace Events.Main.LevelingUpPlayer
{
    public class AddCardPanel : MonoBehaviour
    {
        [SerializeField] private CardView _cardPrefab;
        [SerializeField] private DeckView _deckView;
        [SerializeField] private CardDataList _cardDataList;
        [SerializeField] private PlayerGlobalData _playerGlobalData;

        private const int QuantityCards = 3;

        private Deck _deck = new Deck();

        private void Awake()
        {
            _cardDataList.Init();
            _deckView.SetDeck(_deck);
        }

        private void OnEnable()
        {
            _deck.OnClickCardFromDeck += AddCard;
        }

        private void OnDisable()
        {
            _deck.OnClickCardFromDeck -= AddCard;
        }

        public void Init()
        {
            _deck.Clear();

            for (int i = 0; i < QuantityCards; i++)
            {
                _deck.AddCard(new Card(_cardDataList.GetRandomCardData()));
            }
        }

        private void AddCard(Card cardData)
        {
            _playerGlobalData.AddCard(cardData.Data);
            gameObject.SetActive(false);
        }
    }
}

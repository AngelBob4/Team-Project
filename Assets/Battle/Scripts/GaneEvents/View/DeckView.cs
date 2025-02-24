using Events.Cards;
using Events.Hand;
using System.Collections.Generic;
using UnityEngine;

namespace Events.View
{
    public class DeckView : MonoBehaviour
    {
        [SerializeField] private CardView _cardViewPrefab;
        [SerializeField] private Transform _hand—ontainer;

        private List<CardView> _cardViews = new List<CardView>();
        private Deck _deck;

        public void SetDeck(Deck deck)
        {
            _deck = deck;

            Unsubscribe();
            Subscribe();
        }

        private void OnEnable()
        {
            Subscribe();
        }

        private void OnDisable()
        {
            Unsubscribe();
        }

        public void Draw()
        {
            Clear();

            foreach (Card card in _deck.GetAllCards())
            {
                CardView newCardView = Instantiate(_cardViewPrefab, _hand—ontainer);
                newCardView.Draw(card);
                _cardViews.Add(newCardView);
            }
        }

        private void Clear()
        {
            foreach (CardView cardView in _cardViews)
            {
                Destroy(cardView.gameObject);
            }

            _cardViews.Clear();
        }

        private void Subscribe()
        {
            if (_deck != null)
            {
                _deck.UpdatedDeck += Draw;
                Draw();
            }
        }

        private void Unsubscribe()
        {
            if (_deck != null)
            {
                _deck.UpdatedDeck -= Draw;
                Clear();
            }
        }
    }
}

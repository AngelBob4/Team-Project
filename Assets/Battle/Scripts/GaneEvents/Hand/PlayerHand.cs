using Events.Cards;
using Events.View;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Events.Hand
{
    public class PlayerHand : MonoBehaviour
    {
        private const int MaxCardsInHand = 7;

        [SerializeField] private DeckView _handView;
        [SerializeField] private DeckView _combinationView;
        [SerializeField] private CardEffectsView _cardEffectsView;
        [SerializeField] private TMP_Text _deckCardsText;
        [SerializeField] private TMP_Text _discardDeckCardsText;

        public event Action UpdatedDeck;

        private Deck _deck = new Deck();
        private Deck _discardDeck = new Deck();
        private Deck _hand = new Deck(MaxCardsInHand);
        private CombinationDeck _combinationHand = new CombinationDeck(MaxCardsInHand);

        public CombinationDeck CombinationHand => _combinationHand;
        public bool IsCardsHand => _hand.GetAllCards().Count > 0;
        public Deck DiscardDeck => _discardDeck;

        private void Awake()
        {
            _handView.SetDeck(_hand);
            _combinationView.SetDeck(_combinationHand);
            _cardEffectsView.SetCombinationHand(_combinationHand);
        }

        private void OnEnable()
        {
            _hand.OnClickCardFromDeck += MoveCardFromHandToCombination;
            _combinationHand.OnClickCardFromDeck += MoveCardFromCombinationToHand;

            _deck.UpdatedDeck += DrawText;
            _discardDeck.UpdatedDeck += DrawText;
        }

        private void OnDisable()
        {
            _hand.OnClickCardFromDeck -= MoveCardFromHandToCombination;
            _combinationHand.OnClickCardFromDeck -= MoveCardFromCombinationToHand;

            _deck.UpdatedDeck -= DrawText;
            _discardDeck.UpdatedDeck -= DrawText;
        }

        public void SetDeck(IReadOnlyList<CardData> cardDataList)
        {
            Clean();
            _deck.SetDeck(cardDataList);
        }

        public void Clean()
        {
            _deck.Clear();
            _hand.Clear();
            _combinationHand.Clear();
            _discardDeck.Clear();
        }

        public void TakeCardFromDeck(int quantity)
        {
            for (int i = 0; i < quantity; i++)
            {
                if (_deck.GetAllCards().Count == 0)
                {
                    MoveCardsDiscardToDeck();
                }

                TryMoveCard(_deck.GetRandomCard(), _deck, _hand);
            }
        }

        public void MoveCardToDiscard()
        {
            if (TryMoveCard(_deck.GetRandomCard(), _deck, _discardDeck) == false)
            {
                if (TryMoveCard(_hand.GetRandomCard(), _hand, _discardDeck) == false)
                {
                    MoveCardsDiscardToDeck();
                    TryMoveCard(_deck.GetRandomCard(), _deck, _discardDeck);
                }
            }
        }

        public void MoveCardsCombinationToDiscard()
        {
            MoveAllCards(_combinationHand, _discardDeck);
        }

        public void MoveCardsDiscardToDeck()
        {
            MoveAllCards(_discardDeck, _deck);
            UpdatedDeck?.Invoke();
        }

        private void MoveAllCards(Deck fromDesk, Deck toDesk)
        {
            foreach (Card card in fromDesk.GetAllCards())
            {
                toDesk.AddCard(card);
            }

            fromDesk.Clear();
        }

        private void MoveCardFromHandToCombination(Card card)
        {
            TryMoveCard(card, _hand, _combinationHand);
        }

        private void MoveCardFromCombinationToHand(Card card)
        {
            TryMoveCard(card, _combinationHand, _hand);
        }

        private bool TryMoveCard(Card card, Deck fromDesk, Deck toDesk)
        {
            if (card != null && fromDesk.CanRemoveCard(card) && toDesk.CanAddCard(card))
            {
                toDesk.AddCard(card);
                fromDesk.RemoveCard(card);
                return true;
            }
            else
            {
                return false;
            }
        }

        private void DrawText()
        {
            _deckCardsText.text = _deck.GetAllCards().Count.ToString();
            _discardDeckCardsText.text = _discardDeck.GetAllCards().Count.ToString();
        }
    }
}
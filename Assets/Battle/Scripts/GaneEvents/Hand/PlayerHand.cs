using Events.Animation;
using Events.Cards;
using Events.View;
using Reflex.Attributes;
using System;
using System.Collections;
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
        [SerializeField] private AnimationDamageDeck _animationDamageDeck;
        [SerializeField] private CardEffectsView _cardEffectsView;
        [SerializeField] private TMP_Text _deckCardsText;
        [SerializeField] private TMP_Text _discardDeckCardsText;
        [SerializeField] private Transform _discardDeckTransform;

        public event Action UpdatedDeck;

        private Deck _deck = new Deck();
        private Deck _discardDeck = new Deck();
        private Deck _hand = new Deck(MaxCardsInHand);
        private CombinationDeck _combinationHand = new CombinationDeck(MaxCardsInHand);
        private List<Card> _moveCards = new List<Card>();
        //private AnimationTime _animationTime;

        public CombinationDeck CombinationHand => _combinationHand;
        public bool IsCardsHand => _hand.GetAllCards().Count > 0;
        public Deck DiscardDeck => _discardDeck;
        public IReadOnlyDeck Hand => _hand;

        //[Inject]
        //private void Inject(AnimationTime animationTime)
        //{
        //    _animationTime = animationTime;
        //}

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

        public void StartNewRound()
        {
            MoveListCardToDiscard(_moveCards, _hand);

            _moveCards.Clear();
        }

        public void Test()
        {
            _moveCards = _hand.GetRandomListCard(1);

            foreach (Card card in _moveCards)
            {
                card.TakeDamage();
            }
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
            List<Card> moveCards = new List<Card>();

            for (int i = 0; i < quantity; i++)
            {
                if (_deck.GetCardsCount() == 0)
                {
                    MoveCardsDiscardToDeck();
                }

                Card moveCard = _deck.GetRandomCard();

                moveCards.Add(moveCard);

                TryMoveCard(moveCard, _deck, _hand);
            }

            foreach (Card card in moveCards)
            {
                card.MoveCard(_deckCardsText.transform.position, null);
            }
        }

        public void TakeDamagCardDeck(int quantity)
        {
            _animationDamageDeck.Play(quantity);

            for (int i = 0; i < quantity; i++)
            {
                if (_deck.GetCardsCount() == 0)
                {
                    MoveCardsDiscardToDeck();
                }

                TryMoveCard(_deck.GetRandomCard(), _deck, _discardDeck);
            }
        }

        public void TakeDamagCardHend(int quantity)
        {
            _moveCards = _hand.GetRandomListCard(quantity);

            foreach(Card card in _moveCards)
            {
                card.TakeDamage();
            }

            //MoveListCardToDiscard(_moveCards, _hand);

            //MoveCardToDiscard(_hand, _deck);
        }

        public void MoveCardsCombinationToDiscard()
        {
            Debug.Log("111");
            foreach (Card card in _combinationHand.GetAllCards())
            {
                Debug.Log("222");
                card.MoveCard(_discardDeckTransform);
            }

            StartCoroutine(MoveCard());

            IEnumerator MoveCard()
            {
                Debug.Log("333");
                yield return new WaitForSeconds(AnimationTime.TimeMoveCard);
                MoveAllCards(_combinationHand, _discardDeck);
                Debug.Log("444");
            }
        }

        public void MoveCardsDiscardToDeck()
        {
            MoveAllCards(_discardDeck, _deck);
            UpdatedDeck?.Invoke();
        }

        private void MoveListCardToDiscard(List<Card> cards, Deck deck)
        {
            foreach (Card card in cards)
            {
                TryMoveCard(card, deck, _discardDeck);
            }
        }

        private void MoveCardToDiscard(Deck deckFirst, Deck deckSecond)
        {
            if (TryMoveCard(deckFirst.GetRandomCard(), deckFirst, _discardDeck) == false)
            {
                if (TryMoveCard(deckSecond.GetRandomCard(), deckSecond, _discardDeck) == false)
                {
                    MoveCardsDiscardToDeck();
                    TryMoveCard(_deck.GetRandomCard(), _deck, _discardDeck);
                }
            }
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
            Vector3 startTransform = card.CardView.transform.position; 
            TryMoveCard(card, _hand, _combinationHand);
            card.MoveCard(startTransform, card.CardView.transform);
        }

        private void MoveCardFromCombinationToHand(Card card)
        {
            Vector3 startTransform = card.CardView.transform.position;
            TryMoveCard(card, _combinationHand, _hand);
            card.MoveCard(startTransform, card.CardView.transform);
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

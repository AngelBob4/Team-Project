using Events.Cards;
using Events.Hand;
using MainGlobal;
using Events.View;
using System.Collections.Generic;
using UnityEngine;

public abstract class ChooseInAllPlayerCardPanel : MonoBehaviour
{
    [SerializeField] private DeckView _deckView;
    [SerializeField] protected PlayerGlobalData _playerGlobalData;

    private const int MaxLevelCard = 3;

    private Deck _deck = new Deck();
    private List<CardData> _cards = new List<CardData>();

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

    public void Init(int maxLevel = MaxLevelCard)
    {
        _cards.Clear();

        gameObject.SetActive(true);

        foreach (var card in _playerGlobalData.CardDataList)
        {
            if(card.Level <= maxLevel)
            {
                _cards.Add(card);
            }
        }

        _deck.SetDeck(_cards);
    }

    protected abstract void OnClickCard(Card card);
}

using Events.Cards;
using Events.Hand;
using MainGlobal;
using Events.View;
using System.Collections.Generic;
using UnityEngine;
using Reflex.Attributes;

public abstract class ChooseInAllPlayerCardPanel : MonoBehaviour
{
    [SerializeField] private DeckView _deckView;

    private const int MaxLevelCard = 3;

    protected PlayerGlobalData _playerGlobalData;
    
    private Deck _deck = new Deck();
    private List<CardData> _cards = new List<CardData>();


    [Inject]
    private void Inject(PlayerGlobalData playerGlobalData)
    {
        _playerGlobalData = playerGlobalData;
    }

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

    public virtual void Init(int maxLevel = MaxLevelCard)
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

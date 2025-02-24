using Events.Cards;
using MainGlobal;
using Events.View;
using System.Collections.Generic;
using UnityEngine;
using Reflex.Attributes;

public class ImproveCardPanel : MonoBehaviour
{
    [SerializeField] private CardView _cardViewOriginal;
    [SerializeField] private CardView _cardViewNew;
    [SerializeField] private CardDataList _cardDataList;

    const int MaxLevelCard = 2;

    private PlayerGlobalData _playerGlobalData;
    private CardData _cardDataOriginal;
    private CardData _cardDataNew;
    private List<CardData> _cardDataNewList = new List<CardData>();
    private List<CardData> _cardDataOriginalList = new List<CardData>();

    [Inject]
    private void Inject(PlayerGlobalData playerGlobalData)
    {
        _playerGlobalData = playerGlobalData;
    }

    private void Awake()
    {
        _cardDataList.Init();

        gameObject.SetActive(false);
    }

    public void ImproveRandomCard()
    {
        _cardDataOriginalList.Clear();

        foreach (var card in _playerGlobalData.CardDataList)
        {
            if(card.Level <= MaxLevelCard)
            {
                _cardDataOriginalList.Add(card);
            }
        }

        if(_cardDataOriginalList.Count > 0)
        {
            ImproveCard(_cardDataOriginalList[Random.Range(0, _cardDataOriginalList.Count)]);
        }
    }

    public void ImproveCard(CardData cardData)
    {

        gameObject.SetActive(true);

        _cardDataNewList.Clear();

        _cardDataOriginal = cardData;

        foreach (var card in _cardDataList.List)
        {
            if (card.Type == _cardDataOriginal.Type && card.Level == _cardDataOriginal.Level + 1)
            {
                _cardDataNewList.Add(card);
            }
        }

        _cardDataNew = _cardDataNewList[Random.Range(0, _cardDataNewList.Count)];

        _playerGlobalData.RemoveCard(_cardDataOriginal);
        _playerGlobalData.AddCard(_cardDataNew);

        Draw();
    }

    private void Draw()
    {
        _cardViewOriginal.Draw(new Card(_cardDataOriginal));
        _cardViewNew.Draw(new Card(_cardDataNew));
    }
}

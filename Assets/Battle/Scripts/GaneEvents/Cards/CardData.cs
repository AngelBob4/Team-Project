using AYellowpaper.SerializedCollections;
using Events.Cards;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct CardData
{
    private string _name;
    private int _level;
    private CardType _cardType;
    private int _wound;
    private int _shield;
    private int _cards;
    private Dictionary<CardType, CardEffectType> _combinations;

    public string Name => _name;
    public int Level => _level;
    public CardType Type => _cardType;
    public int Wound => _wound;
    public int Shield => _shield;
    public int Cards => _cards;
    public IReadOnlyDictionary<CardType, CardEffectType> Combinations => _combinations;

    //public CardData()
    //{
    //    _name = "test";
    //    //_level = 1;
    //    //_cardType = CardType.Green;
    //    //_wound = 1;
    //    //_shield = 1;
    //    //_cards = 1;
    //    //_combinations = new Dictionary<CardType, CardEffectType>();
    //}

    public CardData(CardDataSO cardDataSO): this(cardDataSO.Name, cardDataSO.Level, cardDataSO.Type, 
        cardDataSO.Wound, cardDataSO.Shield, cardDataSO.Cards, cardDataSO.Combinations)
    { }

    public CardData(CardDataSave cardData) : this(cardData.Name, cardData.Level, cardData.Type,
        cardData.Wound, cardData.Shield, cardData.Cards, cardData.Combinations)
    { }

    private CardData(string name, int level, CardType cardType, int wound, int shield, int cards, IReadOnlyDictionary<CardType, CardEffectType> combinations)
    {
        _name = name;
        _level = level;
        _cardType = cardType;
        _wound = wound;
        _shield = shield;
        _cards = cards;

        _combinations = new Dictionary<CardType, CardEffectType>();
        foreach (CardType card in combinations.Keys)
        {
            _combinations.Add(card, combinations[card]);
        }
    }
}

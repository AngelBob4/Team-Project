using Events.Cards;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

public struct CardDataSave
{
    public string Name;
    public int Level;
    public CardType Type;
    public int Wound;
    public int Shield;
    public int Cards;
    public Dictionary<CardType, CardEffectType> Combinations;

    //public string Name => _name;
    //public int Level => _level;
    //public CardType Type => _cardType;
    //public int Wound => _wound;
    //public int Shield => _shield;
    //public int Cards => _cards;
    //public IReadOnlyDictionary<CardType, CardEffectType> Combinations => _combinations;

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

    public CardDataSave(CardData cardData) : this(cardData.Name, cardData.Level, cardData.Type,
        cardData.Wound, cardData.Shield, cardData.Cards, cardData.Combinations)
    { }

    private CardDataSave(string name, int level, CardType cardType, int wound, int shield, int cards, IReadOnlyDictionary<CardType, CardEffectType> combinations)
    {
        Name = name;
        Level = level;
        Type = cardType;
        Wound = wound;
        Shield = shield;
        Cards = cards;

        Combinations = new Dictionary<CardType, CardEffectType>();
        foreach (CardType card in combinations.Keys)
        {
            Combinations.Add(card, combinations[card]);
        }
    }
}

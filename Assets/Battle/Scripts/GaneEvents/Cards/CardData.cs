using AYellowpaper.SerializedCollections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Events.Cards
{
    [CreateAssetMenu(fileName = "CardData", menuName = "Data/CardData")]
    public class CardData : ScriptableObject
    {
        [SerializeField] private string _name;
        [SerializeField] private int _level;
        [SerializeField] private CardType _cardType;
        [SerializeField] private int _wound;
        [SerializeField] private int _shield;
        [SerializeField] private int _cards;

        [SerializeField]
        [SerializedDictionary("CardType", "Bonus")]
        private SerializedDictionary<CardType, CardEffectType> _combinations;

        public string Name => _name;
        public int Level => _level;
        public CardType Type => _cardType;
        public int Wound => _wound;
        public int Shield => _shield;
        public int Cards => _cards;
        public IReadOnlyDictionary<CardType, CardEffectType> Combinations => _combinations;
    }
}
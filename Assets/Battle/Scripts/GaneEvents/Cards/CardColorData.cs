using AYellowpaper.SerializedCollections;
using System.Collections.Generic;
using UnityEngine;

namespace Events.Cards
{
    [CreateAssetMenu(fileName = "CardData", menuName = "Data/CardColorData")]
    public class CardColorData : ScriptableObject
    {
        [SerializeField]
        [SerializedDictionary("CardType", "Color")]
        private SerializedDictionary<CardType, Color> _colors;

        public IReadOnlyDictionary<CardType, Color> Colors => _colors;
    }
}

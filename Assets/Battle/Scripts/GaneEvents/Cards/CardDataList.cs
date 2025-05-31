using System.Collections.Generic;
using UnityEngine;

namespace Events.Cards
{
    [CreateAssetMenu(fileName = "CardDataList", menuName = "Data/CardDataList")]
    public class CardDataList : ScriptableObject
    {
        [SerializeField] private List<CardDataSO> _list;
        [SerializeField] private List<CardDataList> _lists;

        private List<CardDataSO> _cards;

        public IReadOnlyList<CardDataSO> List => _cards;

        public void Init()
        {
            _cards = new List<CardDataSO>();

            foreach (var card in _list)
            {
                _cards.Add(card);
            }

            foreach (var list in _lists)
            {
                list.Init();

                foreach (var card in list.List)
                {
                    _cards.Add(card);
                }
            }
        }

        public CardData GetRandomCardData()
        {
            return new CardData(_cards[Random.Range(0, _cards.Count)]);
        }

        public List<CardData> GetList()
        {
            List<CardData> newList = new List<CardData>();

            foreach (CardDataSO card in _cards)
            {
                newList.Add(new CardData(card));
            }

            return newList;
        }
    }
}
using Events.Cards;
using Events.View;
using UnityEngine;

namespace Events.Main.LevelingUpPlayer
{
    public class AddOneCardPanel : MonoBehaviour
    {
        [SerializeField] private CardView _cardPrefab;
        [SerializeField] private Transform _container;

        private CardView _card;

        public void Init(Card card)
        {
            if (_card != null)
            {
                Destroy(_card.gameObject);
                _card = null;
            }

            _card = Instantiate(_cardPrefab, _container);
            _card.Draw(card);
        }
    }
}

using Events.Cards;
using Events.View;
using MainGlobal;
using Reflex.Attributes;
using UnityEngine;

namespace Events.Main.LevelingUpPlayer
{
    public class AddOneCardPanel : MonoBehaviour
    {
        [SerializeField] private CardView _cardPrefab;
        [SerializeField] private Transform _panel;
        [SerializeField] private Transform _container;

        private PlayerGlobalData _playerGlobalData;

        private CardView _card;

        [Inject]
        private void Inject(PlayerGlobalData playerGlobalData)
        {
            _playerGlobalData = playerGlobalData;
        }

        private void OnEnable()
        {
            _playerGlobalData.AddedOnlyCard += Init;
        }

        private void OnDisable()
        {
            _playerGlobalData.AddedOnlyCard -= Init;
        }

        public void Init(Card card)
        {
            _panel.gameObject.SetActive(true);

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
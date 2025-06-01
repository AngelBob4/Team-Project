using MainGlobal;
using Reflex.Attributes;
using System.Collections.Generic;
using UnityEngine;

namespace Events.Main.LevelingUpPlayer
{
    public class LevelingUpPanel : MonoBehaviour
    {
        [SerializeField] private AddCardPanel _addCardPanel;
        [SerializeField] private Transform _container;
        [SerializeField] private ButtonLevelingUp _buttonPrefab;
        [SerializeField] private List<Sprite> _sprites;

        private const int _MinAddCoins = 50;
        private const int _MaxAddCoins = 100;

        private PlayerGlobalData _playerGlobalData;
        private int _addCoins;
        private List<ButtonLevelingUp> _buttons = new List<ButtonLevelingUp>();
        
        [Inject]
        private void Inject(PlayerGlobalData playerGlobalData)
        {
            _playerGlobalData = playerGlobalData;
        }

        private void OnEnable()
        {
            foreach (var button in _buttons)
            {
                button.OnClick += OnClickButton;
            }
        }

        private void OnDisable()
        {
            foreach (var button in _buttons)
            {
                button.OnClick -= OnClickButton;
            }
        }

        public void Init()
        {
            Clear();
            _addCoins = Random.Range(_MinAddCoins, _MaxAddCoins + 1);

            AddButton("+ ", LevelingUpType.Card, _sprites[(int)LevelingUpType.Card]);
            AddButton("+ " + _addCoins, LevelingUpType.Coins, _sprites[(int)LevelingUpType.Coins]);
        }

        private void AddButton(string text, LevelingUpType type, Sprite sprite)
        {
            ButtonLevelingUp newButton = Instantiate(_buttonPrefab, _container);
            newButton.Init(text, type, sprite);
            _buttons.Add(newButton);
            newButton.OnClick += OnClickButton;
        }

        private void OnClickButton(ButtonLevelingUp button)
        {
            switch (button.Type)
            {
                case LevelingUpType.Coins:
                    _playerGlobalData.ChangeCoins(_addCoins);
                    break;

                case LevelingUpType.Card:
                    _addCardPanel.gameObject.SetActive(true);
                    _addCardPanel.Init();
                    break;
            }

            _buttons.Remove(button);
            Destroy(button.gameObject);
        }

        private void Clear()
        {
            foreach (var button in _buttons)
            {
                Destroy(button.gameObject);
            }

            _buttons.Clear();
        }
    }
}
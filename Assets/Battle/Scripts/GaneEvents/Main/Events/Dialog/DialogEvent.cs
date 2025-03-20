using Events.Cards;
using Events.Main.Events.Dialog.Instance;
using Events.MainGlobal;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Events.Main.Events.Dialog
{
    public class DialogEvent : GameEvent
    {
        [SerializeField] private TMP_Text _name;
        [SerializeField] private TMP_Text _text;
        [SerializeField] private Transform _buttonsContainer;
        [SerializeField] private DialogButton _buttonPrefab;
        [SerializeField] private PlayerGlobalData _playerGlobalData;
        [SerializeField] private CardDataList cardDataList;

        public override event Action FinishedEvent;

        private DialogEventData _eventData;
        private List<DialogButton> _dialogButtons = new List<DialogButton>();

        private void Awake()
        {
            _eventData = new DialogEventDataAddCard(cardDataList);
        }

        public override void StartEvent(int level)
        {
            Init();
        }

        private void OnEnable()
        {
            Subscribe();
        }

        private void OnDisable()
        {
            Unsubscribe();
        }

        private void Init()
        {
            Clear();

            if (_eventData == null)
                throw new NullReferenceException();

            _name.text = _eventData.Name;
            _text.text = _eventData.Text;

            for (int i = 0; i < _eventData.StringButtons.Count; i++)
            {
                DialogButton newDialogButton = Instantiate(_buttonPrefab, _buttonsContainer);
                newDialogButton.Init(_eventData.StringButtons[i], i);
                newDialogButton.OnClick += OnClickButton;
                _dialogButtons.Add(newDialogButton);
            }
        }

        private void OnClickButton(int index)
        {
            _eventData.OnClickButton(index, _playerGlobalData);
            gameObject.SetActive(false);
            FinishedEvent?.Invoke();
        }

        private void Clear()
        {
            Unsubscribe();

            foreach (DialogButton dialogButton in _dialogButtons)
            {
                Destroy(dialogButton.gameObject);
            }

            _dialogButtons.Clear();
        }

        private void Subscribe()
        {
            foreach (DialogButton dialogButton in _dialogButtons)
            {
                dialogButton.OnClick += OnClickButton;
            }
        }

        private void Unsubscribe()
        {
            foreach (DialogButton dialogButton in _dialogButtons)
            {
                dialogButton.OnClick -= OnClickButton;
            }
        }
    }
}

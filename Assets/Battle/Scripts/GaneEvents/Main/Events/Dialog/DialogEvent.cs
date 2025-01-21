using Events.Cards;
using Events.Main.Events.Dialog.Instance;
using Events.MainGlobal;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Events.Main.Events.Dialog
{
    public class DialogEvent : GameEvent
    {
        [SerializeField] private TMP_Text _name;
        [SerializeField] private TMP_Text _text;
        [SerializeField] private Transform _buttonsContainer;
        [SerializeField] private DialogButton _buttonPrefab;
        [SerializeField] private DialogEventCommunications _dialogEventCommunications;
        [SerializeField] private CardDataList cardDataList;
        [SerializeField] private PlayerGlobalData _playerGlobalData;

        public override event Action FinishedEvent;

        private DialogEventInstance _eventData;
        private List<DialogEventInstance> _allEventDataList;
        private List<DialogEventInstance> _eventDataList = new List<DialogEventInstance>();
        private List<DialogButton> _dialogButtons = new List<DialogButton>();

        private void Awake()
        {
            _allEventDataList = new List<DialogEventInstance>
            {
                new DialogEventMedicinalPlants(),
                new DialogEventPlacePower(),
                new DialogEventPriest(),
                new DialogEventShelter(),
                new DialogEventShrineCoins(),
                new DialogEventShrineImproveCard(),
                new DialogEventTrap(),
                new DialogEventVision(cardDataList)
            };

            gameObject.SetActive(false);
        }

        private void OnEnable()
        {
            Subscribe();
        }

        private void OnDisable()
        {
            Unsubscribe();
        }
        
        public override void StartEvent(int level)
        {
            InitInstance();
        }

        public void InitNewGame()
        {
            _eventDataList.Clear();

            foreach (DialogEventInstance instance in _allEventDataList)
            {
                _eventDataList.Add(instance);
            }
        }

        private void InitInstance()
        {
            Clear();

            _eventData = _eventDataList[UnityEngine.Random.Range(0, _eventDataList.Count)];

            if (_eventData == null)
                throw new NullReferenceException();

            _eventDataList.Remove(_eventData);

            _name.text = _eventData.Name;
            _text.text = _eventData.Text;

            for (int i = 0; i < _eventData.DialogEventButtonDataList.Count; i++)
            {
                DialogButton newDialogButton = Instantiate(_buttonPrefab, _buttonsContainer);
                newDialogButton.Init(_eventData.DialogEventButtonDataList[i].String, i);
                newDialogButton.OnClick += OnClickButton;
                _dialogButtons.Add(newDialogButton);

                if(_playerGlobalData.Coins.CurrentValue < Math.Abs(_eventData.DialogEventButtonDataList[i].PriceCount))
                {
                    newDialogButton.GetComponent<Button>().interactable = false;
                }
            }
        }

        private void OnClickButton(int index)
        {
            _eventData.OnClickButton(index, _dialogEventCommunications);
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

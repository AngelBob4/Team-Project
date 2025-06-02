using System;
using System.Collections.Generic;
using MainGlobal;
using Reflex.Attributes;
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

        [SerializeField] private Image _image;
        [SerializeField] private DialogSpriteSO _dialogSpritesSO;
        [SerializeField] private Dictionary<DialogTypes, Sprite> _dialogSprites;

        public event Action OnClickedButton;

        private PlayerGlobalData _playerGlobalData;
        private DialogEventDataList _dialogEventDataList;
        private DialogEventInstance _eventData;
        private List<DialogButton> _dialogButtons = new List<DialogButton>();

        [Inject]
        private void Inject(DialogEventDataList dialogEventDataList, PlayerGlobalData playerGlobalData)
        {
            _dialogEventDataList = dialogEventDataList;
            _playerGlobalData = playerGlobalData;
        }

        private void Awake()
        {
            _dialogSprites = new()
            {
                { DialogTypes.MedicalHerbs, _dialogSpritesSO.MedicalPlants },
                { DialogTypes.PowerPlace, _dialogSpritesSO.PowerPlace },
                { DialogTypes.Priest, _dialogSpritesSO.Priest },
                { DialogTypes.Shelter, _dialogSpritesSO.Shelter },
                { DialogTypes.ShrineCoins, _dialogSpritesSO.ShrineCoins },
                { DialogTypes.ShrineCard, _dialogSpritesSO.ShrineCard },
                { DialogTypes.Trap, _dialogSpritesSO.Trap },
                { DialogTypes.Vision, _dialogSpritesSO.Visions },
            };
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
            InitBackgroundImage(_dialogSprites[_eventData.DialogType]);
        }

        private void InitBackgroundImage(Sprite sprite)
        {
            _image.sprite = sprite;
        }

        private void InitInstance()
        {
            Clear();

            _eventData = _dialogEventDataList.GetRandomDialogEventInstance();

            if (_eventData == null)
                throw new NullReferenceException();

            _name.text = _eventData.Name;
            _text.text = _eventData.Text;

            for (int i = 0; i < _eventData.DialogEventButtonDataList.Count; i++)
            {
                DialogButton newDialogButton = Instantiate(_buttonPrefab, _buttonsContainer);
                newDialogButton.Init(_eventData.DialogEventButtonDataList[i].String, i);
                newDialogButton.OnClick += OnClickButton;
                _dialogButtons.Add(newDialogButton);

                if (_playerGlobalData.Coins.CurrentValue < Math.Abs(_eventData.DialogEventButtonDataList[i].PriceCount))
                {
                    newDialogButton.GetComponent<Button>().interactable = false;
                }
            }
        }

        private void OnClickButton(int index)
        {
            _eventData.OnClickButton(index, _dialogEventCommunications);
            gameObject.SetActive(false);
            OnClickedButton?.Invoke();
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
using MapSection.Infrastructure;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace MapSection.Views
{
    public class MapCellView : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private Image _backGround;

        private IPresenter _presenter;

        public event Action ButtonClicked;

        public void Init(IPresenter presenter)
        {
            gameObject.SetActive(false);
            _presenter = presenter;
            gameObject.SetActive(true);
        }

        public void InitImage(Sprite sprite)
        {
            _backGround.sprite = sprite;
        }

        private void OnEnable()
        {
            _button?.onClick.AddListener(OnButtonClicked);
            _presenter?.Enable();
        }

        private void OnDisable()
        {
            _button?.onClick.RemoveListener(OnButtonClicked);
            _presenter?.Disable();
        }

        public void SetRed()
        {
            _backGround.color = Color.red;
        }

        public void TurnOn()
        {
            _button.interactable = true;
        }

        public void TurnOff()
        {
            _button.interactable = false;
        }

        private void OnButtonClicked()
        {
            ButtonClicked?.Invoke();
        }
    }
}
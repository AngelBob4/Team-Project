using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Events.Main.Events.Dialog
{
    public class DialogButton : MonoBehaviour
    {
        [SerializeField] private TMP_Text _text;
        [SerializeField] private Button _button;

        public event Action<int> OnClick;

        private int _index;

        public void Init(string text, int index)
        {
            _text.text = text;
            _index = index;
        }

        public void OnClickButton()
        {
            OnClick?.Invoke(_index);
        }

        public void iii()
        {
            _button.interactable = false;
        }
    }
}

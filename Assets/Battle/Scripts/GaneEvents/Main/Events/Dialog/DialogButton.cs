using System;
using TMPro;
using UnityEngine;

namespace Events.Main.Events.Dialog
{
    public class DialogButton : MonoBehaviour
    {
        [SerializeField] private TMP_Text _text;

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
    }
}

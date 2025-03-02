using System;
using TMPro;
using UnityEngine;

namespace Events.Main.LevelingUpPlayer
{
    public class ButtonLevelingUp : MonoBehaviour
    {
        [SerializeField] private TMP_Text _text;

        public event Action<ButtonLevelingUp> OnClick;

        private LevelingUpType _type;

        public LevelingUpType Type => _type;

        public void Init(string text, LevelingUpType type)
        {
            _text.text = text;
            _type = type;
        }

        public void OnClickButton()
        {
            OnClick.Invoke(this);
        }
    }
}
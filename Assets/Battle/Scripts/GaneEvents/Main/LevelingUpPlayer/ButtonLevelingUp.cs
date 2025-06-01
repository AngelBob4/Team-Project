using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Events.Main.LevelingUpPlayer
{
    public class ButtonLevelingUp : MonoBehaviour
    {
        [SerializeField] private TMP_Text _text;
        [SerializeField] private Image _image;

        public event Action<ButtonLevelingUp> OnClick;

        private LevelingUpType _type;

        public LevelingUpType Type => _type;

        public void Init(string text, LevelingUpType type, Sprite sprite)
        {
            _text.text = text;
            _type = type;
            _image.sprite = sprite;
        }

        public void OnClickButton()
        {
            OnClick.Invoke(this);
        }
    }
}
using Events.Cards;
using UnityEngine;
using UnityEngine.UI;

namespace Events.View
{
    public class ColorForCardTypeView : MonoBehaviour
    {
        [SerializeField] private Image _image;
        [SerializeField] private CardColorData _cardColorData;

        private Color _defaultColor;
        private IColorForCardType _colorForCardType = null;

        private void Awake()
        {
            _defaultColor = _image.color;
        }

        private void OnEnable()
        {
            Subscribe();
        }

        private void OnDisable()
        {
            Unsubscribe();
        }

        public void SetColorForCardType(IColorForCardType colorForCardType)
        {
            _colorForCardType = colorForCardType;

            if (_colorForCardType != null)
            {
                Subscribe();
            }
        }

        private void Draw()
        {
            if (_colorForCardType == null)
            {
                return;
            }

            if (_colorForCardType.CardType != CardType.Null)
            {
                _image.color = _cardColorData.Colors[_colorForCardType.CardType];
            }
            else
            {
                _image.color = _defaultColor;
            }
        }

        private void Subscribe()
        {
            if (_colorForCardType != null)
            {
                _colorForCardType.UpdatedColor += Draw;
                Draw();
            }
        }

        private void Unsubscribe()
        {
            if (_colorForCardType != null)
            {
                _colorForCardType.UpdatedColor -= Draw;
            }
        }
    }
}
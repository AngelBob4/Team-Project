using Events.Main.CharactersBattle;
using TMPro;
using UnityEngine;

namespace Events.View
{
    public class BarView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _text;
        [SerializeField] private bool _isDrawAtZeroValue;

        private IBar _bar = null;

        private void OnEnable()
        {
            Subscribe();
        }

        private void OnDisable()
        {
            Unsubscribe();
        }

        public void SetBar(IBar bar)
        {
            _bar = bar;
            Subscribe();
        }

        private void Draw()
        {
            if (_bar == null)
            {
                return;
            }

            gameObject.SetActive(_bar.CurrentValue > 0 || _isDrawAtZeroValue);

            _text.text = _bar.CurrentValue.ToString();

            if (_bar.IsEndlessBar == false)
            {
                _text.text = _text.text + "/" + _bar.MaxValue;
            }
        }

        private void Subscribe()
        {
            if (_bar != null)
            {
                _bar.UpdatedBar += Draw;
                Draw();
            }
        }

        private void Unsubscribe()
        {
            if (_bar != null)
            {
                _bar.UpdatedBar -= Draw;

                gameObject.SetActive(false);
                _text.text = "";
            }
        }
    }
}

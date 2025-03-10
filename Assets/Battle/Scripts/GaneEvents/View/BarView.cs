using Events.Main.CharactersBattle;
using TMPro;
using UnityEngine;

namespace Events.View
{
    public class BarView : MonoBehaviour
    {
        [SerializeField] private Transform _conteiner;
        [SerializeField] private TMP_Text _text;
        [SerializeField] private bool _isDrawAtZeroValue;
        [SerializeField] private AnimationDamageInt _animationDamageInt;

        private IBar _bar = null;

        private void Awake()
        {
            if(_conteiner == null)
            {
                _conteiner = GetComponent<Transform>();
            }
        }

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

            if (_bar != null)
            {
                Subscribe();
            }
            else
            {
                _conteiner.gameObject.SetActive(false);
            }
        }

        private void Draw()
        {
            if (_bar == null || _conteiner == null)
            {
                return;
            }

            _conteiner.gameObject.SetActive(_bar.CurrentValue > 0 || _isDrawAtZeroValue);

            _text.text = _bar.CurrentValue.ToString();

            if (_bar.IsEndlessBar == false)
            {
                _text.text = _text.text + "/" + _bar.MaxValue;
            }
        }

        private void PlayAnimationDamage(int damag)
        {
            _animationDamageInt.Play(damag);
        }

        private void Subscribe()
        {
            if (_bar != null)
            {
                _bar.UpdatedBar += Draw;

                if (_animationDamageInt != null)
                {
                    _bar.DamagBar += PlayAnimationDamage;
                }

                Draw();
            }
        }

        private void Unsubscribe()
        {
            if (_bar != null)
            {
                _bar.UpdatedBar -= Draw;

                if (_animationDamageInt != null)
                {
                    _bar.DamagBar -= PlayAnimationDamage;
                }

                _text.text = "";
            }
        }
    }
}

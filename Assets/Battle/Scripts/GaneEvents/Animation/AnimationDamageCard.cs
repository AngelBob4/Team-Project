using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Reflex.Attributes;

namespace Events.Animation
{
    public class AnimationDamageCard : MonoBehaviour
    {
        [SerializeField] private Image _image;

        //[SerializeField] private bool _isTween = false;

        private float _time = AnimationTime.TimeDamageCard;
        //private Tween _tween;

        //public bool IsPlay => _isTween;

        //private void Update()
        //{
        //    if (_isTween == false && _tween != null && _tween.active)
        //    {
        //        _isTween = true;
        //    }
        //
        //    if (_isTween && _tween.active == false)
        //    {
        //        _isTween = false;
        //    }
        //}

        public void Play()
        {
            _image.gameObject.SetActive(true);
            _image.DOFade(1, _time);//.SetLoops(2, LoopType.Yoyo);
        }


    }
}

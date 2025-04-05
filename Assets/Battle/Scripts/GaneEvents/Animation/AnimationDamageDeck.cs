using Events.Animation;
using Reflex.Attributes;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class AnimationDamageDeck : AnimationDamageInt
{
    [SerializeField] private Image _image;
    [SerializeField] private Image _imageText;
    [SerializeField] private TMP_Text _text;

    private float _time;
    private float _timeModifier = 0.5f;

    private void Awake()
    {
        _time = AnimationTime.TimeDamageCard * _timeModifier;
    }

    public override void Play(int quantity)
    {
        _text.text = quantity.ToString();

        //_image.gameObject.SetActive(true);
        //_text.gameObject.SetActive(true);

        _image.DOFade(1, _time).SetLoops(2, LoopType.Yoyo);
        _imageText.DOFade(1, _time).SetLoops(2, LoopType.Yoyo);
        _text.DOFade(1, _time).SetLoops(2, LoopType.Yoyo);
    }
}

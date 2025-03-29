using Events.Main.CharactersBattle;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarImageView : MonoBehaviour
{
    [SerializeField] private List<Image> _images;
    [SerializeField] private Color32 _colorActiv;
    [SerializeField] private Color32 _colorNoActiv;
    //[SerializeField] private AnimationDamageInt _animationDamageInt;

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

        if (_bar != null)
        {
            Subscribe();
        }
    }

    private void Draw()
    {
        if (_bar == null)
        {
            return;
        }

        foreach (var image in _images)
        {
            image.color = _colorNoActiv;
        }

        for(int i = 0; i < _bar.CurrentValue && i < _images.Count; i++)
        {
            _images[i].color = _colorActiv;
        }
    }

    private void PlayAnimationDamage(int damag)
    {
        //if (_animationDamageInt == null)
        //    return;
        //
        //_animationDamageInt.Play(damag);
    }

    private void Subscribe()
    {
        if (_bar != null)
        {
            _bar.UpdatedBar += Draw;

            //if (_animationDamageInt != null)
            //{
            //    _bar.DamagBar += PlayAnimationDamage;
            //}

            Draw();
        }
    }

    private void Unsubscribe()
    {
        if (_bar != null)
        {
            _bar.UpdatedBar -= Draw;

            //if (_animationDamageInt != null)
            //{
            //    _bar.DamagBar -= PlayAnimationDamage;
            //}
        }
    }
}

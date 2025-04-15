using Events.Animation;
using Reflex.Attributes;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class AnimationMoveCard : MonoBehaviour
{
    [SerializeField] private Image _image;

    private Vector3 _offset;

    //[SerializeField] private bool _isTween = false;

    private float _time = AnimationTime.TimeMoveCard;

    public void Play(Transform endTransform, bool isFrom = false)
    {
        Debug.Log("AnimationMoveCard");
        //_image.gameObject.SetActive(true);
        if (isFrom == false)
        {
            _image.transform.DOMove(new Vector3(endTransform.position.x, endTransform.position.y, endTransform.position.z), _time, false);//.SetLoops(2, LoopType.Yoyo);
        }
        else
        {

        }
    }

    public void Play(Vector3 startTransform, Transform endTransform)
    {
        //Debug.Log("AnimationMoveCard");
        //_image.gameObject.SetActive(true);
        _offset = _image.transform.position;

        _image.transform.position = startTransform;

        //Play(endTransform);
        _image.transform.DOLocalMove(Vector3.zero, _time);
        //_image.transform.DOMove(startTransform, _time).From();
        //_image.transform.DOMove(new Vector3(endTransform.position.x, endTransform.position.y, endTransform.position.z), _time, false);//.SetLoops(2, LoopType.Yoyo);
    }
}

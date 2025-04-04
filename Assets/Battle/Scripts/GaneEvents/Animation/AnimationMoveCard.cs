using Events.Animation;
using Reflex.Attributes;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class AnimationMoveCard : MonoBehaviour
{
    [SerializeField] private Image _image;

    //[SerializeField] private bool _isTween = false;

    private float _time = AnimationTime.TimeMoveCard;

    public void Play(Transform transform)
    {
        Debug.Log("AnimationMoveCard");
        //_image.gameObject.SetActive(true);
        _image.transform.DOMove(new Vector3(transform.position.x, transform.position.y, transform.position.z), _time, false);//.SetLoops(2, LoopType.Yoyo);
    }
}

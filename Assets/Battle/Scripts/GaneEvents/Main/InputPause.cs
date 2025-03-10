using DG.Tweening;
using Events.Animation;
using Events.Main.CharactersBattle.Enemies;
using Reflex.Attributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputPause : MonoBehaviour
{
    [SerializeField] private Image _blockImage;

    public void SetInput(bool value)
    {
        _blockImage.gameObject.SetActive(!value);
    }
}

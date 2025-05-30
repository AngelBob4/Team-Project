using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;
using UnityEngine.UI;

public class Loads : MonoBehaviour
{
    [SerializeField] private Button _buttonLoad;

    private void OnEnable() => YandexGame.GetDataEvent += GetLoad;
    private void OnDisable() => YandexGame.GetDataEvent -= GetLoad;

    private void Start()
    {
        if (YandexGame.SDKEnabled == true)
        {
            GetLoad();
        }
    }

    public void Load() => YandexGame.LoadProgress();

    public void GetLoad()
    {
        _buttonLoad.interactable = YandexGame.savesData.IsSave;
    }
}

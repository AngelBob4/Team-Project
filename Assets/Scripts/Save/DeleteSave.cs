using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;

public class DeleteSave : MonoBehaviour
{
    public void Delete()
    {
        YandexGame.savesData.IsSave = false;
        YandexGame.SaveProgress();
    }
}

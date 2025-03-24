using MainGlobal;
using Reflex.Attributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewGameButton : MonoBehaviour
{
    private LoadingScene _loadingScene;

    [Inject]
    private void Inject(LoadingScene loadingScene)
    {
        _loadingScene = loadingScene;
    }

    public void OnClickButton()
    {
        _loadingScene.LoadSceneStartGame();
    }
}

using MainGlobal;
using Reflex.Attributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGemeTest : MonoBehaviour
{
    private GlobalGame _globalGame;

    [Inject]
    private void Inject(GlobalGame globalGame)
    {
        _globalGame = globalGame;
    }

    public void StartNewGame()
    {
        _globalGame.NewGame();
    }
}

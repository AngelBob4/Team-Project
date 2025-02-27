using Events.Main.Events;
using MainGlobal;
using Reflex.Attributes;
using System;

public class TestEventRunner : GameEvent
{
    //public override event Action FinishedEvent;

    private GlobalGame _globalGame;

    [Inject]
    private void Inject(GlobalGame globalGame)
    {
        _globalGame = globalGame;
    }

    public override void StartEvent(int level)
    {

    }

    public void OnClickButton()
    {
        //_globalGame.SetEvent(eventsType);
        _globalGame.StartEvent();
        //gameObject.SetActive(false);
        //FinishedEvent?.Invoke();
    }
}

using Events.Main.Events;
using MainGlobal;
using Reflex.Attributes;
using System;

public class TestEventMap : GameEvent
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

    public void OnClickButtonBattle()
    {
        OnClickButton(EventsType.Battle);
    }

    public void OnClickButtonDialog()
    {
        OnClickButton(EventsType.Dialog);
    }

    public void OnClickButtonShop()
    {
        OnClickButton(EventsType.Shop);
    }

    private void OnClickButton(EventsType eventsType)
    {
        _globalGame.SetEvent(eventsType);
        _globalGame.StartRunner();
        //gameObject.SetActive(false);
        //FinishedEvent?.Invoke();
    }
}

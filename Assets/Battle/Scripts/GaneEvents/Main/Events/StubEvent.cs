using System;

namespace Events.Main.Events
{
    public class StubEvent : GameEvent
    {
        public override event Action FinishedEvent;

        public override void StartEvent(int level)
        {
            
        }

        public void OnClickButton()
        {
            gameObject.SetActive(false);
            FinishedEvent?.Invoke();
        }
    }
}

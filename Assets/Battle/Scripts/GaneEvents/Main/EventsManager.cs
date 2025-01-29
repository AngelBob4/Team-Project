using Events.Main.Events;
using System;
using UnityEngine;

namespace Events.Main
{
    public class EventsManager : MonoBehaviour
    {
        [SerializeField] private GameEvent _buttleEvent;
        [SerializeField] private GameEvent _dialogEvent;
        [SerializeField] private GameEvent _shop;

        public event Action FinishedEvent;

        private int _level;
        private EventsType _eventType;

        public EventsType EventType => _eventType;

        private void OnEnable()
        {
            _buttleEvent.FinishedEvent += FinishedEvent;
            _dialogEvent.FinishedEvent += FinishedEvent;
            _shop.FinishedEvent += FinishedEvent;
        }

        private void OnDisable()
        {
            _buttleEvent.FinishedEvent -= FinishedEvent;
            _dialogEvent.FinishedEvent -= FinishedEvent;
            _shop.FinishedEvent -= FinishedEvent;
        }

        public void SetLevel(int level)
        {
            _level = level;
        }

        public void StartNewEvent(EventsType eventType)
        {
            _eventType = eventType;

            switch (eventType)
            {
                case EventsType.Battle:
                    StartEvent(_buttleEvent);
                    break;

                case EventsType.Dialog:
                    StartEvent(_dialogEvent);
                    break;

                case EventsType.Shop:
                    StartEvent(_shop);
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }

            _level++;
        }

        public void EndEvent()
        {
            _eventType = EventsType.Null;
            _buttleEvent.gameObject.SetActive(false);
            _dialogEvent.gameObject.SetActive(false);
        }

        private void StartEvent(GameEvent newEvent)
        {
            newEvent.gameObject.SetActive(true);
            newEvent.StartEvent(_level);
        }
    }
}

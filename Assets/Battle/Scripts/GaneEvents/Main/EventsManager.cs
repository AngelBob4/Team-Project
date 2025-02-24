using Events.Main.Events;
using MainGlobal;
using Reflex.Attributes;
using System;
using UnityEngine;

namespace Events.Main
{
    public class EventsManager : MonoBehaviour
    {
        [SerializeField] private GameEvent _battleEvent;
        [SerializeField] private GameEvent _dialogEvent;
        [SerializeField] private GameEvent _shopEvent;

        //public event Action FinishedEvent;

        private EventsType _eventType;
        private GlobalGame _globalGame;

        public EventsType EventType => _eventType;

        [Inject]
        private void Inject(GlobalGame globalGame)
        {
            _globalGame = globalGame;
        }

        private void Start()
        {
            StartNewEvent(_globalGame.EventsType, _globalGame.Level);
        }

        private void OnEnable()
        {
            _battleEvent.FinishedEvent += FinishedEvent;
            _dialogEvent.FinishedEvent += FinishedEvent;
            _shopEvent.FinishedEvent += FinishedEvent;
        }

        private void OnDisable()
        {
            _battleEvent.FinishedEvent -= FinishedEvent;
            _dialogEvent.FinishedEvent -= FinishedEvent;
            _shopEvent.FinishedEvent -= FinishedEvent;
        }

        public void StartNewEvent(EventsType eventType, int level)
        {
            _eventType = eventType;

            switch (eventType)
            {
                case EventsType.Battle:
                    StartEvent(_battleEvent, level);
                    break;

                case EventsType.Dialog:
                    StartEvent(_dialogEvent);
                    break;

                case EventsType.Shop:
                    StartEvent(_shopEvent);
                    break;

                case EventsType.Boss:
                    StartEvent(_battleEvent);
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public void EndEvent()
        {
            _eventType = EventsType.Null;
            _battleEvent.gameObject.SetActive(false);
            _dialogEvent.gameObject.SetActive(false);
            _shopEvent.gameObject.SetActive(false);
        }

        private void StartEvent(GameEvent newEvent, int level)
        {
            newEvent.gameObject.SetActive(true);
            newEvent.StartEvent(level);
        }

        private void StartEvent(GameEvent newEvent)
        {
            StartEvent(newEvent, newEvent.DefaultLevel);
        }

        private void FinishedEvent()
        {
            _globalGame.StartMap();
        }
    }
}

using Events.Main.Events;
using Events.Main.Events.Dialog;
using MainGlobal;
using Reflex.Attributes;
using System;
using UnityEngine;

namespace Events.Main
{
    public class EventsManager : MonoBehaviour
    {
        [SerializeField] private GameEvent _battleEvent;
        [SerializeField] private DialogEvent _dialogEvent;
        [SerializeField] private GameEvent _shopEvent;
        [SerializeField] private WindowsManager _windowsManager;

        private EventsType _eventType;
        private GlobalGame _globalGame;
        private LoadingScene _loadingScene;

        public EventsType EventType => _eventType;

        [Inject]
        private void Inject(GlobalGame globalGame, LoadingScene loadingScene)
        {
            _globalGame = globalGame;
            _loadingScene = loadingScene;
        }

        private void Start()
        {
            StartNewEvent(_globalGame.EventsType, _globalGame.Level);
        }

        private void OnEnable()
        {
            _dialogEvent.OnClickedButton += CheckFinishedEvent;
        }

        private void OnDisable()
        {
            _dialogEvent.OnClickedButton -= CheckFinishedEvent;
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

                //default:
                //    throw new ArgumentOutOfRangeException();
            }
        }

        public void CheckFinishedEvent()
        {
            if (_windowsManager.IsAllWindowsAreTurnedOff())
            {
                FinishedEvent();
            }
        }

        public void GameOver()
        {
            EndEvent();
            _loadingScene.LoadSceneStartGame();
        }

        private void EndEvent()
        {
            _eventType = EventsType.Null;
            _windowsManager.TurnOffAlllWindows();
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
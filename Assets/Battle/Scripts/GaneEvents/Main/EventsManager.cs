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
        [SerializeField] private Transform _gameOverPanel;

        private EventsType _eventType;
        private GlobalGame _globalGame;
        private LoadingScene _loadingScene;
        private PlayerGlobalData _playerGlobalData;
        //private bool _isBoss;

        public EventsType EventType => _eventType;

        [Inject]
        private void Inject(GlobalGame globalGame, LoadingScene loadingScene, PlayerGlobalData playerGlobalData)
        {
            _globalGame = globalGame;
            _loadingScene = loadingScene;
            _playerGlobalData = playerGlobalData;
        }

        private void Start()
        {
            StartNewEvent(EventsType.Battle, 1);
            //StartNewEvent(_globalGame.EventsType, _globalGame.Level);
        }

        private void OnEnable()
        {
            _playerGlobalData.Died += GameOver;
            _dialogEvent.OnClickedButton += CheckFinishedEvent;
        }

        private void OnDisable()
        {
            _playerGlobalData.Died -= GameOver;
            _dialogEvent.OnClickedButton -= CheckFinishedEvent;
            EndEvent();
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
                    StartEvent(_shopEvent);
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
            _gameOverPanel.gameObject.SetActive(true);
            //EndEvent();
            //_loadingScene.LoadSceneStartGame();
        }

        public void EndEvent()
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
            if(_eventType != EventsType.Boss)
            {
                _globalGame.StartMap();
            }
            else
            {
                StartEvent(_battleEvent);
            }
        }
    }
}
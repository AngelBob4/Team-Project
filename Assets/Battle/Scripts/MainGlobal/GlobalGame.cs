using Events.Main;
using Events.Main.Events;
using Events.Main.Events.Dialog;
using UnityEngine;

namespace Events.MainGlobal
{
    public class GlobalGame : MonoBehaviour
    {
        [SerializeField] private int _startLevel;
        [SerializeField] private PlayerGlobalData _playerGlobalData;
        [SerializeField] private EventsManager _eventsManager;
        [SerializeField] private DialogEvent _dialogEvent;
        [SerializeField] private StubEvent _mapManager;
        [SerializeField] private StubEvent _runnerManager;

        private EventsType _eventType;

        private void OnEnable()
        {
            _eventsManager.FinishedEvent += StartMap;
            _mapManager.FinishedEvent += StartRunner;
            _runnerManager.FinishedEvent += StartEvent;
            _playerGlobalData.Died += GameOver;
        }

        private void OnDisable()
        {
            _eventsManager.FinishedEvent -= StartMap;
            _mapManager.FinishedEvent -= StartRunner;
            _runnerManager.FinishedEvent -= StartEvent;
            _playerGlobalData.Died -= GameOver;
        }

        public void NewGame()
        {
            _dialogEvent.InitNewGame();
            _eventsManager.SetLevel(_startLevel);
            _playerGlobalData.InitNewPlayer();

            StartMap();
        }

        public void SetEventBattle()
        {
            SetEvent(EventsType.Battle);
        }

        public void SetEventDialog()
        {
            SetEvent(EventsType.Dialog);
        }

        public void SetEventShop()
        {
            SetEvent(EventsType.Shop);
        }

        private void SetEvent(EventsType eventType)
        {
            _eventType = eventType;
        }

        private void StartEvent()
        {
            _eventsManager.StartNewEvent(_eventType);
        }

        private void StartRunner()
        {
            _runnerManager.gameObject.SetActive(true);
        }

        private void StartMap()
        {
            _mapManager.gameObject.SetActive(true);
        }

        private void GameOver()
        {

        }
    }
}

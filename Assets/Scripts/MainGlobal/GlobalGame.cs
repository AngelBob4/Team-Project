using Events.Main;
using Events.Main.Events;
using Events.Main.Events.Dialog;
using Reflex.Attributes;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MainGlobal
{
    public class GlobalGame
    {
        //[SerializeField] private DialogEvent _dialogEvent;
        //[SerializeField] private TestEventMap _mapManager;
        //[SerializeField] private StubEvent _bossMapManager;
        //[SerializeField] private StubEvent _runnerManager;
        //[SerializeField] private Transform _loseGamePanel;

        private readonly int _startLevel = 1;
        private readonly int _levelBoss = 10;
        //private readonly int _levelBossStart = -1;

        private EventsManager _eventsManager;
        private int _level;
        private EventsType _eventType;
        private PlayerGlobalData _playerGlobalData;
        private LoadingScene _loadingScene;
        private DialogEventDataList _dialogEventDataList;
        //private PlayerBattleCharacterData _playerBattleCharacterData;

        public EventsType EventsType => _eventType;
        public int Level => _level;

        //[Inject]
        //private void Inject
        //    (
        //    PlayerGlobalData playerGlobalData, 
        //    LoadingScene loadingScene,
        //    DialogEventDataList dialogEventDataList
        //    )
        //{
        //    _playerGlobalData = playerGlobalData;
        //    _loadingScene = loadingScene;
        //    _dialogEventDataList = dialogEventDataList;
        //
        //    Debug.Log("555");
        //
        //}

        public GlobalGame
            (
            PlayerGlobalData playerGlobalData,
            LoadingScene loadingScene,
            DialogEventDataList dialogEventDataList
            //PlayerBattleCharacterData playerBattleCharacterData
            )
        {
            _playerGlobalData = playerGlobalData;
            _loadingScene = loadingScene;
            _dialogEventDataList = dialogEventDataList;
            //_playerBattleCharacterData = playerBattleCharacterData;

            Debug.Log("555");
        }

        //private void OnEnable()
        //{
            //_eventsManager.FinishedEvent += StartMap;
            //_mapManager.FinishedEvent += StartRunner;
            //_bossMapManager.FinishedEvent += StartRunner;
            //_runnerManager.FinishedEvent += StartEvent;
            //_playerGlobalData.Died += GameOver;
        //}

        //private void OnDisable()
        //{
            //_eventsManager.FinishedEvent -= StartMap;
            //_mapManager.FinishedEvent -= StartRunner;
            //_bossMapManager.FinishedEvent -= StartRunner;
            //_runnerManager.FinishedEvent -= StartEvent;
            //_playerGlobalData.Died -= GameOver;
        //}

        public void NewGame()
        {
            if (_dialogEventDataList == null)
                Debug.Log("111");

            _dialogEventDataList.InitNewGame();
            _level = _startLevel;
            _playerGlobalData.InitNewPlayer();

            _eventType = EventsType.Null;
            StartMap();
        }

        //public void SetEventBattle()
        //{
        //    SetEvent(EventsType.Battle);
        //}
        //
        //public void SetEventBattleBoss()
        //{
        //    SetEvent(EventsType.Boss);
        //}
        //
        //public void SetEventDialog()
        //{
        //    SetEvent(EventsType.Dialog);
        //}
        //
        //public void SetEventShop()
        //{
        //    SetEvent(EventsType.Shop);
        //}

        public void SetEvent(EventsType eventType)
        {
            _eventType = eventType;
        }

        public void StartEvent()
        {
            _loadingScene.LoadSceneEvent();
            //_eventsManager.StartNewEvent(_eventType, _level);
            
            if(_level <= _levelBoss)
                _level++;
        }

        public void StartRunner()
        {
            _loadingScene.LoadSceneRuner();
            //_runnerManager.gameObject.SetActive(true);
        }

        public void StartMap()
        {
            _loadingScene.LoadSceneMap();

            //if (_eventType == EventsType.Boss)
            //{
            //    Debug.Log("Победа");
            //    return;
            //}
            //
            //if (_level < _levelBoss)
            //{
            //    _mapManager.gameObject.SetActive(true);
            //}
            //else
            //{
            //    if( _level == _levelBoss) 
            //    {
            //        _bossMapManager.gameObject.SetActive(true);
            //    }
            //    else
            //    {
            //        SetEvent(EventsType.Boss);
            //        StartEvent();
            //    }
            //}
        }

        private void GameOver()
        {
            //_loseGamePanel.gameObject.SetActive(true);
        }
    }
}

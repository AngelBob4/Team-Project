using Events.Main.Events;
using Events.Main.Events.Dialog;
using UnityEngine;

namespace MainGlobal
{
    public class GlobalGame
    {
        private readonly int _startLevel = 1;
        private readonly int _levelBoss = 10;

        private int _level;
        private EventsType _eventType;
        private PlayerGlobalData _playerGlobalData;
        private LoadingScene _loadingScene;
        private DialogEventDataList _dialogEventDataList;

        public EventsType EventsType => _eventType;
        public int Level => _level;

        public GlobalGame
            (
            PlayerGlobalData playerGlobalData,
            LoadingScene loadingScene,
            DialogEventDataList dialogEventDataList
            )
        {
            _playerGlobalData = playerGlobalData;
            _loadingScene = loadingScene;
            _dialogEventDataList = dialogEventDataList;
        }

        public void NewGame()
        {
            _dialogEventDataList.InitNewGame();
            _level = _startLevel;
            _playerGlobalData.InitNewPlayer();

            _eventType = EventsType.Null;
            StartMap();
        }

        public void SetEvent(EventsType eventType)
        {
            _eventType = eventType;
        }

        public void StartEvent()
        {
            _loadingScene.LoadSceneEvent();
            
            _level++;
        }

        public void StartRunner()
        {
            _loadingScene.LoadSceneRuner();
        }

        public void StartMap()
        {
            if (_eventType == EventsType.Boss)
            {
                Debug.Log("Победа");
                _loadingScene.LoadSceneStartGame();
                return;
            }

            if (_level < _levelBoss - 1)
            {
                _loadingScene.LoadSceneMap();
            }
            else
            {
                if (_level == _levelBoss - 1)
                {
                    SetEvent(EventsType.Shop);
                    _loadingScene.LoadSceneRuner();
                }
                else
                {
                    SetEvent(EventsType.Boss);
                    StartEvent();
                }
            }
        }
    }
}
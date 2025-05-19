using Events.Main.Events;
using Events.Main.Events.Dialog;
using Runner.Enums;
using UnityEngine;

namespace MainGlobal
{
    public class GlobalGame
    {
        private readonly int _startLevel = 1;
        // private readonly int _levelBoss = 10;

        private float _soundEffectsVolume = 1;
        private float _backgroundMusicVolume = 1;

        private int _level;
        private EventsType _eventType;
        private PlayerGlobalData _playerGlobalData;
        private LoadingScene _loadingScene;
        private DialogEventDataList _dialogEventDataList;
        // private LocationTypes _locationRunnerTypes;
        private Map _map;

        public EventsType EventsType => _eventType;
        // public LocationTypes LocationRunnerTypes => _locationRunnerTypes;
        public int Level => _level;
        public float SoundEffectsVolume => _soundEffectsVolume;
        public float BackgroundMusicVolume => _backgroundMusicVolume;

        public GlobalGame
            (
            PlayerGlobalData playerGlobalData,
            LoadingScene loadingScene,
            DialogEventDataList dialogEventDataList,
            Map map
            )
        {
            _playerGlobalData = playerGlobalData;
            _loadingScene = loadingScene;
            _dialogEventDataList = dialogEventDataList;
            _map = map;
        }

        public void SetEffectsVolume(float soundEffects)
        {
            _soundEffectsVolume = soundEffects;
        }

        public void SetMusicVolume(float backgroundMusic)
        {
            _backgroundMusicVolume = backgroundMusic;
        }

        public void NewGame()
        {
            _dialogEventDataList.InitNewGame();
            _level = _startLevel;
            _playerGlobalData.InitNewPlayer();
            _map.RestartGame();

            _eventType = EventsType.Null;

            // SetLocationRunner(LocationTypes.Cemetery);

            StartMap();
        }

        public void SetEvent(EventsType eventType)
        {
            _eventType = eventType;
        }

        //public void SetLocationRunner(LocationTypes locationRunner)
        //{
        //    _locationRunnerTypes = locationRunner;
        //}

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
                //_loadingScene.LoadSceneStartGame();
                return;
            }
            else
            {
                _loadingScene.LoadSceneMap();
            }
        }
    }
}
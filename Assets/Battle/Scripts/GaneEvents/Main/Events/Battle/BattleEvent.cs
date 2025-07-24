using Events.Main.CharactersBattle;
using Events.Main.CharactersBattle.Enemies;
using Events.Main.LevelingUpPlayer;
using UnityEngine;

namespace Events.Main.Events.Battle
{
    public class BattleEvent : GameEvent
    {
        [SerializeField] private PlayerBattle _player;
        [SerializeField] private EnemyManager _enemy;
        [SerializeField] private LevelingUpPanel _levelingUpPanel;
        [SerializeField] private Transform _victoryGamePanel;
        [SerializeField] private InputPause _inputPause;

        private bool _isBattle = false;
        private bool _isBoss = false;

        public bool IsBattle => _isBattle;

        private void OnEnable()
        {
            _player.Died += PlayerDied;
            _enemy.Died += Victoryed;
        }

        private void OnDisable()
        {
            _enemy.Died -= Victoryed;
            _player.Died -= PlayerDied;
        }

        public override void StartEvent(int level)
        {
            _isBattle = true;

            _player.Died -= PlayerDied;
            _player.InitNewBattle();
            _player.Died += PlayerDied;

            if(level != DefaultLevel)
            {
                _isBoss = false;
                _enemy.InitNewEnemy(level);
            }
            else
            {
                _isBoss = true;
                _enemy.InitNewBossEnemy();
            }
        }

        public void EndEvent()
        {
            _levelingUpPanel.gameObject.SetActive(false);
            gameObject.SetActive(false);
        }

        private void Victoryed()
        {
            _isBattle = false;

            if (_isBoss == false)
            {
                _isBattle = false;
                _levelingUpPanel.gameObject.SetActive(true);
                _levelingUpPanel.Init();
            }
            else
            {
                _victoryGamePanel.gameObject.SetActive(true);
            }

            _inputPause.SetInput(true);
        }

        private void PlayerDied()
        {
            //EndEvent();
        }
    }
}
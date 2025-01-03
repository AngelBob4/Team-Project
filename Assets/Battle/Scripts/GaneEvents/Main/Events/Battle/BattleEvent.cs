using Events.Main.CharactersBattle;
using Events.Main.CharactersBattle.Enemies;
using Events.Main.LevelingUpPlayer;
using System;
using UnityEngine;

namespace Events.Main.Events.Battle
{
    public class BattleEvent : GameEvent
    {
        [SerializeField] private PlayerBattle _player;
        [SerializeField] private Enemy _enemy;
        [SerializeField] private LevelingUpPanel _victoryGamePanel;

        public override event Action FinishedEvent;

        private bool _isBattle = false;

        public bool IsBattle => _isBattle;

        private void OnEnable()
        {
            _player.Died += PlayerDied;
            _enemy.Died += Victoryed;
        }

        private void OnDisable()
        {
            _enemy.Died -= Victoryed;
        }

        public override void StartEvent(int level)
        {
            _isBattle = true;
            _player.InitNewBattle();
            _enemy.InitNewEnemy(level);
        }

        public void EndEvent()
        {
            _victoryGamePanel.gameObject.SetActive(false);
            gameObject.SetActive(false);

            FinishedEvent?.Invoke();
        }

        private void Victoryed()
        {
            _isBattle = false;
            _victoryGamePanel.gameObject.SetActive(true);
            _victoryGamePanel.Init();
        }

        private void PlayerDied()
        {
            EndEvent();
        }
    }
}

using Events.Main.CharactersBattle;
using Events.Main.CharactersBattle.Enemies;
using UnityEngine;

namespace Events.Main.Events.Battle
{
    public class Attack : MonoBehaviour
    {
        [SerializeField] private PlayerBattle _player;
        [SerializeField] private Enemy _enemy;
        [SerializeField] private BattleEvent _battleEvent;

        //private EnemyData _enemy => _enemyManager.Enemy;

        public void OnClickAttack()
        {
            _player.Attack(_enemy);

            EnemyAttack();

            StartRound();
        }

        private void EnemyAttack()
        {
            if (IsBattle())
            {
                _enemy.Attack(_player);
            }
        }

        private void StartRound()
        {
            if (IsBattle())
            {
                _player.StartRound();
                _enemy.StartRound();
            }
        }

        private bool IsBattle()
        {
            return _battleEvent.IsBattle;
        }
    }
}
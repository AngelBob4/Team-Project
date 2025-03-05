using Events.Animation;
using Events.Main.CharactersBattle;
using Events.Main.CharactersBattle.Enemies;
using Reflex.Attributes;
using System.Collections;
using UnityEngine;

namespace Events.Main.Events.Battle
{
    public class Attack : MonoBehaviour
    {
        [SerializeField] private PlayerBattle _player;
        [SerializeField] private Enemy _enemy;
        [SerializeField] private BattleEvent _battleEvent;

        private AnimationTime _animationTime;

        [Inject]
        private void Inject(AnimationTime animationTime)
        {
            _animationTime = animationTime;
        }

        public void OnClickAttack()
        {
            StartCoroutine(PlayRaund());
        }

        private IEnumerator PlayRaund()
        {
            _player.Attack(_enemy);

            EnemyAttack();

            yield return new WaitForSeconds(_animationTime.TimeDamageCard);

            StartNewRound();
        }

        private void EnemyAttack()
        {
            if (IsBattle())
            {
                _enemy.Attack(_player);
            }
        }

        private void StartNewRound()
        {
            if (IsBattle())
            {
                _player.StartRound();
                _enemy.EnemyData.StartRound();
            }
        }

        private bool IsBattle()
        {
            return _battleEvent.IsBattle;
        }
    }
}
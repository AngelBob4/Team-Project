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
        [SerializeField] private EnemyManager _enemy;
        [SerializeField] private BattleEvent _battleEvent;
        [SerializeField] private InputPause _inputPause;

        //private AnimationTime _animationTime;

        //[Inject]
        //private void Inject(AnimationTime animationTime)
        //{
        //    _animationTime = animationTime;
        //}

        public void OnClickAttack()
        {
            StartCoroutine(PlayRaund());
        }

        private IEnumerator PlayRaund()
        {
            _inputPause.SetInput(false);

            if(_player.Attack(_enemy))
                yield return new WaitForSeconds(AnimationTime.TimeDamageCard);

            EnemyAttack();
            yield return new WaitForSeconds(AnimationTime.TimeDamageCard);

            StartNewRound();

            _inputPause.SetInput(true);
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
                //_enemy.StartRound();
            }
        }

        private bool IsBattle()
        {
            return _battleEvent.IsBattle;
        }
    }
}
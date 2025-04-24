using System.Collections;
using UnityEngine;

namespace Runner.PlayerController
{
    public class PlayerEffectsModule : MonoBehaviour
    {
        [SerializeField] private Player _player;
        [SerializeField] private ParticleSystem _poisonEffect;
        [SerializeField] private ParticleSystem _burningEffect;

        private IEnumerator _coroutine;

        private void OnEnable()
        {
            _player.PlayerCollisions.PlayerIsPoisoned += StartPoisoning;
            _player.PlayerCollisions.PlayerIsHealedFromPosion += StopPoisoning;

            _player.PlayerCollisions.PlayerIsBurning += StartBurning;
            _player.PlayerCollisions.PlayerIsHealedFromBurning += StopBurning;
        }

        private void OnDisable()
        {
            _player.PlayerCollisions.PlayerIsPoisoned -= StartPoisoning;
            _player.PlayerCollisions.PlayerIsHealedFromPosion -= StopPoisoning;

            _player.PlayerCollisions.PlayerIsBurning -= StartBurning;
            _player.PlayerCollisions.PlayerIsHealedFromBurning -= StopBurning;
        }

        public void StartPoisoning(int value)
        {
            if (_coroutine == null)
            {
                _coroutine = EffectRoutine(value, _poisonEffect);
                StartCoroutine(_coroutine);
            }
        }

        public void StopPoisoning()
        {
            if (_coroutine != null)
            {
                _poisonEffect.Stop();
                StopCoroutine(_coroutine);
                _coroutine = null;
            }
        }

        private void StartBurning(int value)
        {
            if (_coroutine == null)
            {
                _coroutine = EffectRoutine(value, _burningEffect);
                StartCoroutine(_coroutine);
            }
        }

        private void StopBurning()
        {
            if (_coroutine != null)
            {
                _burningEffect.Stop();
                StopCoroutine(_coroutine);
                _coroutine = null;
            }
        }

        private IEnumerator EffectRoutine(int value, ParticleSystem effect)
        {
            int pause = 1;

            while (true)
            {
                _player.PlayerGlobalData.ChangeHP(value);
                effect.Play();
                yield return new WaitForSeconds(pause);
            }
        }
    }
}
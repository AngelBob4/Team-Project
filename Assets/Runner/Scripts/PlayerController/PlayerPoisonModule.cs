using System.Collections;
using UnityEngine;

namespace Runner.PlayerController
{
    public class PlayerPoisonModule : MonoBehaviour
    {
        [SerializeField] private Player _player;
        [SerializeField] private ParticleSystem _poisonEffect;

        private IEnumerator _coroutine;

        private void OnEnable()
        {
            _player.PlayerCollisions.PlayerIsPoisoned += StartPoisoning;
            _player.PlayerCollisions.PlayerIsHealed += StopPoisoning;
        }

        private void OnDisable()
        {
            _player.PlayerCollisions.PlayerIsPoisoned -= StartPoisoning;
            _player.PlayerCollisions.PlayerIsHealed -= StopPoisoning;
        }

        public void StartPoisoning(int value)
        {
            if (_coroutine == null)
            {
                _coroutine = PoisonRoutine(value);
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

        private IEnumerator PoisonRoutine(int value)
        {
            int pause = 1;

            while (true)
            {
                _player.PlayerGlobalData.ChangeHP(value);
                _poisonEffect.Play();
                yield return new WaitForSeconds(pause);
            }
        }
    }
}
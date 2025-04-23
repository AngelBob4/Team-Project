using MainGlobal;
using Runner.NonPlayerCharacters;
using Runner.Settings;
using System.Collections;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

namespace Runner.PlayerController
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private PlayerLantern _playerLantern;
        [SerializeField] private PlayerMovement _playerMovement;
        [SerializeField] private PlayerAnimations _playerAnimations;
        [SerializeField] private PlayerAudioEffects _playerAudioEffects;
        [SerializeField] private PlayerCollisions _playerCollisions;

        private IEnumerator _coroutine;

        private LevelController _levelController;
        private PlayerGlobalData _playerGlobalData;

        public PlayerLantern PlayerLantern => _playerLantern;

        public PlayerGlobalData PlayerGlobalData => _playerGlobalData;

        public LevelController LevelController => _levelController;

        private void OnEnable()
        {
            _playerCollisions.PlayerIsPoisoned += StartPoisoning;
            _playerCollisions.PlayerIsHealed += StopPoisoning;
        }

        private void OnDisable()
        {
            _playerCollisions.PlayerIsPoisoned -= StartPoisoning;
            _playerCollisions.PlayerIsHealed -= StopPoisoning;
        }

        private void Update()
        {
            if (_levelController.IsRunnerStarted)
            {
                _playerMovement.StartMovement();
            }
        }

        public void Initialize(LevelController levelController, PlayerGlobalData playerGlobalData)
        {
            _levelController = levelController;
            _playerGlobalData = playerGlobalData;
        }

        public void StartGameProcess()
        {
            _playerAnimations.SetRunAnimation();
            _playerLantern.ReduceLight();
        }

        public void Die()
        {
            _playerCollisions.DisableCollider();
            _playerAnimations.SetDeathAnimation();
        }

        public void PlayAudio(int index)
        {
            _playerAudioEffects.PlayAudioEffect(index);
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
                StopCoroutine(_coroutine);
                _coroutine = null;
            }
        }

        private IEnumerator PoisonRoutine(int value)
        {
            int pause = 1;

            while (true)
            {
                _playerGlobalData.ChangeHP(value);
                yield return new WaitForSeconds(pause);
            }
        }
    }
}

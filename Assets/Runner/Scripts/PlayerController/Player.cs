using MainGlobal;
using Reflex.Attributes;
using Runner.Settings;
using UnityEngine;

namespace Runner.PlayerController
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private PlayerLantern _playerLantern;
        [SerializeField] private PlayerMovement _playerMovement;
        [SerializeField] private PlayerAnimations _playerAnimations;
        [SerializeField] private PlayerAudioEffects _playerAudioEffects;
        [SerializeField] private PlayerCollisions _playerCollisions;

        [SerializeField] private LevelController _levelController;

        private PlayerGlobalData _playerGlobalData;

        public PlayerLantern PlayerLantern => _playerLantern;

        public PlayerGlobalData PlayerGlobalData => _playerGlobalData;

        [Inject]
        private void Inject(PlayerGlobalData playerGlobalData)
        {
            _playerGlobalData = playerGlobalData;
        }

        private void Update()
        {
            if (_levelController.IsRunnerStarted)
            {
                _playerMovement.StartMovement();
            }
        }

        public void StartRun()
        {
            _playerAnimations.SetRunAnimation();
            _playerLantern.ReduceLight();
        }

        public void Die()
        {
            _playerCollisions.DisableCollider();
            _playerAnimations.SetDeathAnimation();
        }

        public void PlayEffect(int index)
        {
            _playerAudioEffects.PlayAudioEffect(index);
        }
    }
}

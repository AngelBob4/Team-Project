using MainGlobal;
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

        private LevelController _levelController;
        private PlayerGlobalData _playerGlobalData;

        public PlayerLantern PlayerLantern => _playerLantern;

        public PlayerGlobalData PlayerGlobalData => _playerGlobalData;

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

        public void PlayEffect(int index)
        {
            _playerAudioEffects.PlayAudioEffect(index);
        }
    }
}

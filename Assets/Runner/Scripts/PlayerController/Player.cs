using Runner.Settings;
using UnityEngine;

namespace Runner.PlayerController
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private PlayerHealth _playerHealth;
        [SerializeField] private PlayerLantern _playerLantern;
        [SerializeField] private PlayerMovement _playerMovement;
        [SerializeField] private PlayerSouls _playerSouls;
        [SerializeField] private PlayerAnimations _playerAnimations;
        [SerializeField] private PlayerAudioEffects _playerAudioEffects;
        [SerializeField] private PlayerCollisions _playerCollisions;

        [SerializeField] private LevelController _levelController;

        public PlayerHealth PlayerHealth => _playerHealth;

        public PlayerLantern PlayerLantern => _playerLantern;

        public PlayerSouls PlayerSouls => _playerSouls;

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

using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

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

        public PlayerHealth PlayerHealth => _playerHealth;

        public PlayerLantern PlayerLantern => _playerLantern;

        public PlayerMovement PlayerMovement => _playerMovement;

        public PlayerSouls PlayerSouls => _playerSouls;

        public PlayerAnimations PlayerAnimations => _playerAnimations;

        public PlayerAudioEffects PlayerAudioEffects => _playerAudioEffects;

        public PlayerCollisions PlayerCollisions => _playerCollisions;

        public void Die()
        {
            _playerCollisions.DisableCollider();
            _playerAnimations.SetDeathAnimation();
        }
    }
}

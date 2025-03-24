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

        public PlayerHealth PlayerHealth => _playerHealth;

        public PlayerLantern PlayerLantern => _playerLantern;

        public PlayerMovement PlayerMovement => _playerMovement;

        public PlayerSouls PlayerSouls => _playerSouls;

        public PlayerAnimations PlayerAnimations => _playerAnimations;

        public PlayerAudioEffects PlayerAudioEffects => _playerAudioEffects;
    }
}

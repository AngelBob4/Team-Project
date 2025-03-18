using UnityEngine;

namespace Runner.PlayerController
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private PlayerHealth _playerHealth;
        [SerializeField] private PlayerLantern _playerLantern;
        [SerializeField] private PlayerMovement _playerMovement;
        [SerializeField] private PlayerSouls _playerSouls;

        public PlayerHealth PlayerHealth => _playerHealth;

        public PlayerLantern PlayerLantern => _playerLantern;

        public PlayerMovement PlayerMovement => _playerMovement;

        public PlayerSouls PlayerSouls => _playerSouls;
    }
}

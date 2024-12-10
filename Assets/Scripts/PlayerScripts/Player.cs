using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerHealth _playerHealth;
    [SerializeField] private PlayerLantern _playerLantern;
    public PlayerHealth PlayerHealth => _playerHealth;

    public PlayerLantern PlayerLantern => _playerLantern;
}


using Runner.NonPlayerCharacters;
using Runner.PlatformsHandler;
using Runner.PlayerController;
using UnityEngine;

public class BossSpawner : MonoBehaviour
{
    [SerializeField] PlatformsCounter _platformsCounter;
    [SerializeField] Boss _boss;

    [SerializeField] Player _player;

    public void EnableBoss()
    {
        _boss.transform.position = _player.transform.position;
        _boss.InitPlayer(_player);
        _boss.gameObject.SetActive(true);
    }
}

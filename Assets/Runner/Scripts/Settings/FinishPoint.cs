using UnityEngine;
using Runner.PlayerController;

namespace Runner.Settings
{
    public class FinishPoint : MonoBehaviour
    {
        [SerializeField] private Player _player;

        public void TransferData()
        {
            //���� ������
            float lanternIntensity;
            lanternIntensity = _player.PlayerLantern.GetCurrentLanternLightIntensity();
            //��������
            int health;
            health = _player.PlayerHealth.GetCurrentHealthValue();

            print(lanternIntensity + " " + health);

            // ��������� ����� ���/��������
        }
    }
}
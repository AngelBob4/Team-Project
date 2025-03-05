using UnityEngine;
using Runner.NonPlayerCharacters;
using Runner.Settings;

namespace Runner.PlayerController
{
    public class PlayerCollisions : MonoBehaviour
    {
        [SerializeField] private Player _player;
        [SerializeField] private FinishPoint _finishPoint;

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.collider.TryGetComponent(out NPC npc))
            {
                _player.PlayerHealth.OnHealthChanged(npc.HealthModifier);
                _player.PlayerLantern.ChangeLanternLightIntensity(npc.LightIntensityModifier);
            }

            if (collision.collider.TryGetComponent(out Tomb tomb))
            {
                _finishPoint.TransferData();
            }

            if (collision.collider.TryGetComponent(out Embrion embrion))
            {
                _player.PlayerHealth.OnHealthChanged(embrion.Damage);
            }
        }

        private void OnTriggerEnter(Collider collider)
        {
            if (collider.TryGetComponent(out Soul soul))
            {
                _player.PlayerSouls.ChangeSoulsAmount(soul.SoulsAmount);
           }
        }
    }
}

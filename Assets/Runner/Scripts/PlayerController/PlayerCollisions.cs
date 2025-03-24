using Runner.NonPlayerCharacters;
using Runner.Settings;
using UnityEngine;

namespace Runner.PlayerController
{
    public class PlayerCollisions : MonoBehaviour
    {
        [SerializeField] private Player _player;
        [SerializeField] private RunnerGameManager _runnerGameManager;

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.collider.TryGetComponent(out NPC npc))
            {
                if (npc as Soul)
                {
                    _player.PlayerSouls.ChangeSoulsAmount(npc.SoulsModifier);
                }
                else
                {
                    _player.PlayerHealth.OnHealthChanged(npc.HealthModifier);
                    _player.PlayerLantern.ChangeLanternLightIntensity(npc.LightIntensityModifier);
                }
            }

            if (collision.collider.TryGetComponent(out Tomb tomb))
            {
                _runnerGameManager.EndGame();
            }

            //if (collision.collider.TryGetComponent(out Embrion embrion))
            //{
            //    _player.PlayerHealth.OnHealthChanged(embrion.Damage);
            //}
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out NPC npc))
            {
                // сделать свойство у всех нпс - аудиоклип 
                // сделать свойство у всех нпс -  эффект
                _player.PlayerAudioEffects.PlayAudioEffect((int)npc.NPCType);
                npc.gameObject.SetActive(false);
            }
        }
    }
}

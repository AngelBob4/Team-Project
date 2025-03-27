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
                if (npc.NPCType == Enums.NPCTypes.Sceleton || npc.NPCType == Enums.NPCTypes.Zombie || npc.NPCType == Enums.NPCTypes.Leech)
                {
                    _player.PlayerHealth.OnHealthChanged(npc.HealthModifier);
                    _player.PlayerLantern.ChangeLanternLightIntensity(npc.LightIntensityModifier);
                    _player.PlayerAudioEffects.PlayAudioEffect((int)npc.NPCType);
                }
            }

            if (collision.collider.TryGetComponent(out Tomb tomb))
            {
                _runnerGameManager.EndGame();
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out NPC npc))
            {
                if (npc.NPCType == Enums.NPCTypes.Soul)
                {
                    _player.PlayerSouls.ChangeSoulsAmount(npc.SoulsModifier);
                }
                else
                {
                    _player.PlayerLantern.ChangeLanternLightIntensity(npc.LightIntensityModifier);
                }

                _player.PlayerAudioEffects.PlayAudioEffect((int)npc.NPCType);
                npc.gameObject.SetActive(false);
            }
        }
    }
}

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
                int modifier = 5;

                if (npc.Type != Enums.NPCTypes.Leech)
                {
                    _player.PlayerLantern.ChangeLanternLightIntensity(npc.Value / modifier);
                }

                _player.PlayerHealth.OnHealthChanged(npc.Value);
                _player.PlayerAudioEffects.PlayAudioEffect((int)npc.Type);
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
                if (npc.Type == Enums.NPCTypes.Soul)
                {
                    _player.PlayerSouls.ChangeSoulsAmount(npc.Value);
                }
                else
                {
                    _player.PlayerLantern.ChangeLanternLightIntensity(npc.Value);
                }

                _player.PlayerAudioEffects.PlayAudioEffect((int)npc.Type);
                npc.gameObject.SetActive(false);
            }
        }
    }
}

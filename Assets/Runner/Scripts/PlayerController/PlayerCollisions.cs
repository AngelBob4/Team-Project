using Runner.NonPlayerCharacters;
using UnityEngine;

namespace Runner.PlayerController
{
    public class PlayerCollisions : MonoBehaviour
    {
        [SerializeField] private Player _player;

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.collider.TryGetComponent(out NPC npc))
            {
                _player.PlayEffect((int)npc.Type);
                _player.PlayerGlobalData.ChangeHP(npc.Value);

                switch (npc.Type)
                {
                    case Enums.NPCTypes.Bat:
                        {
                            _player.PlayerGlobalData.ChangeCoins(npc.Value);
                        }
                        break;

                    case Enums.NPCTypes.LittleGhoul:
                        {
                            _player.PlayerLantern.ChangeLanternLightIntensity(npc.Value);
                        }
                        break;

                    case Enums.NPCTypes.Sceleton:
                    case Enums.NPCTypes.Zombie:
                        {
                            int modifier = 5;
                            _player.PlayerLantern.ChangeLanternLightIntensity(npc.Value / modifier);
                        }
                        break;
                }
            }

            if (collision.collider.TryGetComponent(out Tomb tomb))
            {
                _player.LevelController.FinishRunner();
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out NPC npc))
            {

                if (npc.Type == Enums.NPCTypes.Soul)
                {
                    _player.PlayerGlobalData.ChangeCoins(npc.Value);
                }
                else
                {
                    _player.PlayerLantern.ChangeLanternLightIntensity(npc.Value);
                }

                _player.PlayEffect((int)npc.Type);
                npc.gameObject.SetActive(false);
            }
        }

        public void DisableCollider()
        {
            _player.GetComponent<Collider>().enabled = false;
        }
    }
}

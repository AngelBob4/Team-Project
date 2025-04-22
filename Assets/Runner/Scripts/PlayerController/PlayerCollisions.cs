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
                _player.PlayAudio((int)npc.Type);
                // _player.PlayerGlobalData.ChangeHP(npc.Value);

                switch (npc.Type)
                {
                    case Enums.NPCTypes.Bat:
                    case Enums.NPCTypes.Demon:
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
                    case Enums.NPCTypes.SandSpider:
                    case Enums.NPCTypes.Watcher:
                        {
                            _player.PlayerGlobalData.ChangeHP(npc.Value);
                        }
                        break;

                    case Enums.NPCTypes.BlackWidowSpider:
                        {
                            _player.PlayerGlobalData.ChangeHP(npc.Value);
                            //poison Player
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
                _player.PlayAudio((int)npc.Type);
                npc.gameObject.SetActive(false);

                switch (npc.Type)
                {
                    case Enums.NPCTypes.Soul:
                        {
                            _player.PlayerGlobalData.ChangeCoins(npc.Value);
                        }
                        break;

                    case Enums.NPCTypes.Mushroom:
                        {
                            _player.PlayerGlobalData.ChangeHP(npc.Value);
                            // stop poisoning
                        }
                        break;

                    case Enums.NPCTypes.Fireflies:
                        {
                            _player.PlayerLantern.ChangeLanternLightIntensity(npc.Value);
                        }
                        break;
                }
            }
        }
        public void DisableCollider()
        {
            _player.GetComponent<Collider>().enabled = false;
        }
    }
}

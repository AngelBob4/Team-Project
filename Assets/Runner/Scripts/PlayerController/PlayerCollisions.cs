using Runner.NonPlayerCharacters;
using Runner.Settings;
using UnityEngine;

namespace Runner.PlayerController
{
    public class PlayerCollisions : MonoBehaviour
    {
        [SerializeField] private Player _player;
        [SerializeField] private LevelController _levelController;

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.collider.TryGetComponent(out NPC npc))
            {
                if (npc.Type == Enums.NPCTypes.Bat)
                {
                    _player.PlayerGlobalData.ChangeCoins(npc.Value);
                }

                if (npc.Type != Enums.NPCTypes.Leech)
                {
                    int modifier = 5;
                    _player.PlayerLantern.ChangeLanternLightIntensity(npc.Value / modifier);
                }

                _player.PlayerGlobalData.ChangeHP(npc.Value);
                _player.PlayEffect((int)npc.Type);
            }

            if (collision.collider.TryGetComponent(out Tomb tomb))
            {
                // переделать, убрать томб 
                _levelController.FinishRunner();
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out NPC npc))
            {

                if (npc.Type == Enums.NPCTypes.Soul)
                {
                    // _player.PlayerSouls.ChangeSoulsAmount(npc.Value);
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

using UnityEngine;
using NonPlayerCharacters;

namespace PlayerController
{
    public class PlayerCollisions : MonoBehaviour
    {
        [SerializeField] private Player _player;

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.collider.TryGetComponent<NPC>(out NPC npc))
            {
                _player.PlayerHealth.OnHealthChanged(npc.HealthModifier);
                _player.PlayerLantern.ChangeLanternLightIntensity(npc.LightIntensityModifier);
            }
        }
    }
}

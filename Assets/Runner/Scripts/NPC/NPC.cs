using UnityEngine;
using Runner.PlayerController;
using Runner.Enums;

namespace Runner.NonPlayerCharacters
{
    public class NPC : MonoBehaviour
    {
        [SerializeField] protected int _healthModifier;
        [SerializeField] protected int _lightIntensityModifier;
        [SerializeField] protected int _soulsValue;
        [SerializeField] protected float Speed;

        [SerializeField] protected NPCTypes _npcType;
        [SerializeField] protected ParticleSystem _particleSystem;
        
        public int LightIntensityModifier => _lightIntensityModifier;
        public int HealthModifier => _healthModifier;
        public int SoulsModifier => _soulsValue;

        public  NPCTypes NPCType => _npcType;

        private void Update()
        {
            Move();
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.collider.TryGetComponent(out Player player))
            {
              //  _particleSystem.Play();
            }
        }

        public virtual void Move()
        {
            transform.position += Speed * Time.deltaTime * -transform.forward;
        }
    }
}

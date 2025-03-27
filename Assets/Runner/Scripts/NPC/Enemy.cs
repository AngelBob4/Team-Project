using Runner.PlayerController;
using UnityEngine;

namespace Runner.NonPlayerCharacters
{
    public class Enemy : NPC
    {
        [SerializeField] protected float Speed;
        [SerializeField] protected ParticleSystem _particleSystem;

        private void Update()
        {
            Move();
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.collider.TryGetComponent(out Player player))
            {
                _particleSystem.Play();
            }
        }

        public virtual void Move()
        {
            transform.position += Speed * Time.deltaTime * -transform.forward;
        }
    }
}

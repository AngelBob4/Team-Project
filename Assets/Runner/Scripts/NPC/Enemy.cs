using Runner.PlayerController;
using UnityEngine;

namespace Runner.NonPlayerCharacters
{
    public class Enemy : NPC
    {
        [SerializeField] protected float Speed;
        [SerializeField] protected ParticleSystem _particleSystem;

        protected Vector3 _offset;

        private void Start()
        {
            _offset = CalculateOffset();
        }

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

        protected virtual Vector3 CalculateOffset()
        {
            return Speed * Time.deltaTime * -transform.forward;
        }

        private void Move()
        {
            transform.position += _offset;
        }
    }
}

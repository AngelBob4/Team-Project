using Runner.PlayerController;
using UnityEngine;

namespace Runner.NonPlayerCharacters
{
    public class Enemy : NPC
    {
        [SerializeField] private float _speed;
        [SerializeField] private ParticleSystem _particleSystem;

        protected Vector3 _offset;

        public float Speed => _speed;

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
            return _speed * -transform.forward;
        }

        protected virtual void Move()
        {
            transform.position += _offset * Time.deltaTime;
        }
    }
}

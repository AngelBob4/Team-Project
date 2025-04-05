using MainGlobal;
using Reflex.Attributes;
using Runner.PlayerController;
using Runner.Settings;
using UnityEngine;

namespace Runner.NonPlayerCharacters
{
    public class Enemy : NPC
    {
        [SerializeField] protected float Speed;
        [SerializeField] protected ParticleSystem _particleSystem;

        private EntryPoint _entryPoint;

        protected Vector3 _offset;

        //[Inject]
        //private void Inject(EntryPoint entryPoint)
        //{
        //    _entryPoint = entryPoint;
        //}

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

        protected virtual void Move()
        {
            transform.position += _offset;
        }
    }
}

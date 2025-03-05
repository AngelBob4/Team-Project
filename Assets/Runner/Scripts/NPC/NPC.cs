using UnityEngine;
using Runner.PlayerController;

namespace Runner.NonPlayerCharacters
{
    [RequireComponent(typeof(AudioSource))]
    public class NPC : MonoBehaviour
    {
        [SerializeField] protected int _healthModifier;
        [SerializeField] protected int _lightIntensityModifier;
        [SerializeField] protected float Speed;

        [SerializeField] protected AudioClip _audioClip;
        [SerializeField] protected ParticleSystem _particleSystem;
        [SerializeField] protected AudioSource _audioSource;

        public int LightIntensityModifier => _lightIntensityModifier;
        public int HealthModifier => _healthModifier;

        private void Update()
        {
            Move();
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.collider.TryGetComponent(out Player player))
            {
                _audioSource.PlayOneShot(_audioClip);
                _particleSystem.Play();
            }
        }

        public virtual void Move()
        {
            transform.position += Speed * Time.deltaTime * -transform.forward;
        }
    }
}

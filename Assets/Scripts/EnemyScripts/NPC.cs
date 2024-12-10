using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public abstract class NPC : MonoBehaviour
{
    protected AudioSource _audioSource;

    [SerializeField] protected int _healthModifier;
    [SerializeField] protected int _lightIntensityModifier;

    [SerializeField] protected float Speed;

    [SerializeField] protected AudioClip _audioClip;
    [SerializeField] protected ParticleSystem _particleSystem;

    public int LightIntensityModifier => _lightIntensityModifier;
    public int HealthModifier => _healthModifier;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        Move();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent(out Player player))
        {
            _audioSource.PlayOneShot(_audioClip);
            ReactToPlayer();
            //this.gameObject.SetActive(false);
        }
    }

    public abstract void Move();

    public abstract void ReactToPlayer();
}

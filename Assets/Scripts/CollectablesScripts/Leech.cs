using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Leech : NPC
{
    [SerializeField] private float _jumpHeight;

    public override void Move()
    {
        transform.position += new Vector3(0, _jumpHeight, -Speed) * Speed * Time.deltaTime;
    }

    public override void ReactToPlayer()
    {
        _particleSystem.Play();
        print("with a smacking sound, fly apart into drops of blood");
    }
}

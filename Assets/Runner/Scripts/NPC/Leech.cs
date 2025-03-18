using UnityEngine;

namespace Runner.NonPlayerCharacters
{
    [RequireComponent(typeof(Rigidbody))]
    public class Leech : NPC
    {
        [SerializeField] private float _jumpHeight;

        public override void Move()
        {
            transform.position += new Vector3(0, _jumpHeight, -Speed) * Speed * Time.deltaTime;
        }
    }
}

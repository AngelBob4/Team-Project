using UnityEngine;

namespace Runner.NonPlayerCharacters
{
    [RequireComponent(typeof(Rigidbody))]
    public class Leech : Enemy
    {
        [SerializeField] private float _jumpHeight;

        protected override Vector3 CalculateOffset()
        {
            return new Vector3(0, _jumpHeight, -Speed) * Speed * Time.deltaTime;
        }
    }
}

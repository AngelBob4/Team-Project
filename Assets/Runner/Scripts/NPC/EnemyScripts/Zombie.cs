using UnityEngine;

namespace Runner.NonPlayerCharacters
{
    public class Zombie : NPC
    {
        public override void Move()
        {
            transform.position += -transform.forward * Speed * Time.deltaTime;
        }

        public override void ReactToPlayer()
        {
            _particleSystem.Play();
            print("Attack");
        }
    }
}

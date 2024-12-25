using UnityEngine;

namespace Runner.NonPlayerCharacters
{
    public class Sceleton : NPC
    {
        public override void Move()
        {
            transform.position += -transform.forward * Speed * Time.deltaTime;
        }

        public override void ReactToPlayer()
        {
            _particleSystem.Play();
            print("crumble into bones with crunch");
        }
    }
}

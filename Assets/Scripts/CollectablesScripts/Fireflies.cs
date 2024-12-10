using UnityEngine;

public class Fireflies : NPC
{
    public override void Move()
    {
        transform.position += -transform.forward * Speed * Time.deltaTime;
    }

    public override void ReactToPlayer()
    {

    }
}

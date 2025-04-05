using Runner.PlayerController;
using UnityEngine;

namespace Runner.NonPlayerCharacters
{
    public class Boss : Enemy
    {
        private Player _player;
        public void InitPlayer(Player player)
        {
            _player = player;
        }

        protected override void Move()
        {
            if (transform.position != _player.transform.position)
            {
                transform.position = Vector3.MoveTowards(transform.position, _player.transform.position, 9 * Time.deltaTime);
            }
        }
    }
}

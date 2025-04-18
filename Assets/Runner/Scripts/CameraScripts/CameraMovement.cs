using Runner.PlayerController;
using UnityEngine;

namespace Runner
{
    public class CameraMovement : MonoBehaviour
    {
        private Player _target;

        public void Initialize(Player player)
        {
            transform.parent = null;
            _target = player;
        }

        private void LateUpdate()
        {
            if (_target != null)
            {
                transform.position = _target.transform.position;
            }
        }
    }
}

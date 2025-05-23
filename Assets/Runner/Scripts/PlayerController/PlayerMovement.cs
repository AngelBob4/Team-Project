using UnityEngine;
namespace Runner.PlayerController
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float _borderX;
        [SerializeField] private float _borderY;
        [SerializeField] private float _speed;

        private float _oldMousePosX;
        private float _angleY;

        public void StartMovement()
        {
            Move();
            Rotate();
        }

        private void Move()
        {
            Vector3 newPosition = transform.position + transform.forward * Time.deltaTime * _speed;
            newPosition.x = Mathf.Clamp(newPosition.x, -_borderX, _borderX);
            transform.position = newPosition;
        }

        private void Rotate()
        {
            float deltaX = Input.mousePosition.x - _oldMousePosX;
            _oldMousePosX = Input.mousePosition.x;

            _angleY = Mathf.Clamp(_angleY + deltaX, -_borderY, _borderY);
            transform.eulerAngles = new Vector3(0, _angleY, 0);
        }
    }
}
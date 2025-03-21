using Runner.Settings;
using UnityEngine;

namespace Runner.PlayerController
{
    public class PlayerMovement : MonoBehaviour
    {
        private const string Run = nameof(Run);
        private const string Die = nameof(Die);

        [SerializeField] private float _borderX;
        [SerializeField] private float _borderY;
        [SerializeField] private float _speed;
        [SerializeField] private Animator _animator;
        [SerializeField] private EntryPoint _entryPoint;

        private float _oldMousePosX;
        private float _angleY;

        private void Update()
        {
            if (_entryPoint.IsRunnerStarted)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    _oldMousePosX = Input.mousePosition.x;
                    _animator.SetBool(Run, true);
                }
               
                if (Input.GetMouseButton(0))
                {
                    Vector3 newPosition = transform.position + transform.forward * Time.deltaTime * _speed;
                    newPosition.x = Mathf.Clamp(newPosition.x, -_borderX, _borderX);
                    transform.position = newPosition;

                    float deltaX = Input.mousePosition.x - _oldMousePosX;
                    _oldMousePosX = Input.mousePosition.x;

                    _angleY = Mathf.Clamp(_angleY + deltaX, -_borderY, _borderY);
                    transform.eulerAngles = new Vector3(0, _angleY, 0);
                }

                if (Input.GetMouseButtonUp(0))
                {
                    _animator.SetBool(Run, false);
                }
            }
        }

        public void SetDeathAnimation()
        {
            _animator.SetTrigger(Die);
        }
    }
}

using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform _target;

    private void Start()
    {
        transform.parent = null;
    }

    private void LateUpdate()
    {
        if (_target != null)
        {
            transform.position = _target.position;
        }
    }
}

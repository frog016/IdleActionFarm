using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Movement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;

    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void Move(Vector3 direction)
    {
        _rigidbody.MovePosition(_rigidbody.position + direction * _moveSpeed);
        RotateInDirection(direction);
    }

    private void RotateInDirection(Vector3 direction)
    {
        _rigidbody.rotation = Quaternion.LookRotation(direction);
    }
}

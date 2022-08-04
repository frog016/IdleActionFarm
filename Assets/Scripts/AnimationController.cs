using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private Animator _animator;
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _animator = GetComponentInParent<Animator>();
        _rigidbody = GetComponentInParent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        _animator.SetFloat("WalkSpeed", _rigidbody.velocity.magnitude);
    }
}

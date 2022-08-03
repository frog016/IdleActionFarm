using UnityEngine;

[RequireComponent(typeof(Movement))]
public class CharacterController : MonoBehaviour
{
    private Movement _movement;
    private IInputSystem _inputSystem;

    private void Awake()
    {
        _movement = GetComponent<Movement>();
        _inputSystem = new JoystickInput(FindObjectOfType<Joystick>());
    }

    private void FixedUpdate()
    {
        TryMove();
    }

    private void TryMove()
    {
        var direction = _inputSystem.GetMoveDirection();
        if (direction.magnitude < 1e-4)
            return;

        _movement.Move(direction * Time.fixedDeltaTime);
    }
}

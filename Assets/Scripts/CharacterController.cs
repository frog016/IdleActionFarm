using UnityEngine;

[RequireComponent(typeof(Movement), typeof(Harvester))]
public class CharacterController : MonoBehaviour
{
    private Movement _movement;
    private Harvester _harvester;
    private IInputSystem _inputSystem;

    private void Awake()
    {
        _movement = GetComponent<Movement>();
        _harvester = GetComponent<Harvester>();
        _inputSystem = new JoystickInput(FindObjectOfType<Joystick>());
    }

    private void Update()
    {
        //Input.GetMouseButtonDown(1)
        if (Input.GetMouseButtonDown(1) && _harvester.CanUse)
            _harvester.HarvestWheat();
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

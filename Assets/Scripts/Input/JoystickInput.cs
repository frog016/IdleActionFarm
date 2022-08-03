using UnityEngine;

public class JoystickInput : IInputSystem
{
    private Joystick _joystick;

    public JoystickInput(Joystick joystick)
    {
        _joystick = joystick;
    }

    public Vector3 GetMoveDirection()
    {
        return new Vector3(_joystick.Horizontal, 0, _joystick.Vertical).normalized;
    }
}

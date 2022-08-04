using UnityEngine;

public interface IInputSystem
{
    public bool IsActionButtonUsed();
    public Vector3 GetMoveDirection();
}

using System;
using UnityEngine;

public class InputService : IUpdateService
{
    public event Action<Vector2> OnMove;
    public event Action<bool> OnShoot;

    private IInputHandler _currentInputHandler;

    public InputService()
    {
        _currentInputHandler = new PCInputHandler();

        _currentInputHandler.OnMove += (direction) => OnMove?.Invoke(direction);
        _currentInputHandler.OnShoot += (state) => OnShoot?.Invoke(state);
    }

    public void OnUpdate()
    {
        _currentInputHandler.Update();
    }
}
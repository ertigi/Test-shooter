using System;

public class InputService : IUpdateService
{
    public event Action<float, float> OnMove;
    public event Action<bool> OnShoot;

    private IInputHandler _inputHandler;

    public InputService()
    {
        _inputHandler = new PCInputHandler();

        _inputHandler.OnMove += (x, y) => OnMove?.Invoke(x, y);
        _inputHandler.OnShoot += (state) => OnShoot?.Invoke(state);
    }

    public void OnUpdate()
    {
        _inputHandler.Update();
    }
}
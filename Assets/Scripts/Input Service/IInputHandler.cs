using System;

public interface IInputHandler
{
    event Action<float, float> OnMove;
    event Action<bool> OnShoot;

    void Update();
}

using System;

public class MobileInputHandler : IInputHandler
{
    public event Action<float, float> OnMove;
    public event Action<bool> OnShoot;

    public void Update()
    {

    }
}
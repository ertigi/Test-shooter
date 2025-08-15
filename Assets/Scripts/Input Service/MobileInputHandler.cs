using System;
using UnityEngine;

public class MobileInputHandler : IInputHandler
{
    public event Action<Vector2> OnMove;
    public event Action<bool> OnShoot;

    public void Update()
    {

    }
}
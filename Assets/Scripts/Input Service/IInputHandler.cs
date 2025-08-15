using System;
using UnityEngine;

public interface IInputHandler
{
    event Action<Vector2> OnMove;
    event Action<bool> OnShoot;

    void Update();
}

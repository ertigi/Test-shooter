using System;
using UnityEngine;

public class PCInputHandler : IInputHandler
{
    public event Action<Vector2> OnMove;
    public event Action<bool> OnShoot;

    private bool lastShootState = false;

    public void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        OnMove?.Invoke(new Vector2(horizontal, vertical));

        bool shoot = Input.GetMouseButton(0);
        if (shoot != lastShootState)
        {
            OnShoot?.Invoke(shoot);
            lastShootState = shoot;
        }
    }
}

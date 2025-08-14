using UnityEngine;

public class GameLoopState : IState
{
    public void Enter()
    {
        Debug.Log($"Game started");
    }

    public void Exit()
    {

    }
}

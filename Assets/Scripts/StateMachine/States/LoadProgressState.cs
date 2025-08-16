using System;
using UnityEngine;

public class LoadProgressState : IState
{
    private readonly StateMachine _stateMachine;

    public LoadProgressState(StateMachine gameStateMachine)
    {
        _stateMachine = gameStateMachine;
    }

    public void Enter()
    {
        LoadSaves();
        _stateMachine.Enter<LoadMetaState>();
    }

    public void Exit()
    {

    }

    private void LoadSaves()
    {
        Debug.Log($"Load Saves");
    }
}

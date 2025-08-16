using System;
using UnityEngine;

public class LoadMetaState : IState
{
    private readonly StateMachine _stateMachine;

    public LoadMetaState(StateMachine stateMachine)
    {
        _stateMachine = stateMachine;
    }

    public void Enter()
    {
        LoadUI();
        _stateMachine.Enter<LoadLevelState>();
    }

    public void Exit()
    {

    }

    private void LoadUI()
    {
        Debug.Log($"Load UI");
    }
}

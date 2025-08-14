using System;
using UnityEngine;

public class LoadMetaState : IState
{
    private readonly GameStateMachine _gameStateMachine;

    public LoadMetaState(GameStateMachine gameStateMachine)
    {
        _gameStateMachine = gameStateMachine;
    }

    public void Enter()
    {
        LoadUI();
        _gameStateMachine.Enter<LoadLevelState>();
    }

    public void Exit()
    {

    }

    private void LoadUI()
    {
        Debug.Log($"Load UI");
    }
}

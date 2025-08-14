using System;
using UnityEngine;

public class LoadProgressState : IState
{
    private readonly GameStateMachine _gameStateMachine;

    public LoadProgressState(GameStateMachine gameStateMachine)
    {
        _gameStateMachine = gameStateMachine;
    }

    public void Enter()
    {
        LoadSaves();
        _gameStateMachine.Enter<LoadMetaState>();
    }

    public void Exit()
    {

    }

    private void LoadSaves()
    {
        Debug.Log($"Load Saves");
    }
}

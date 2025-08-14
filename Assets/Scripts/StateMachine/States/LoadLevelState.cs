using System;
using UnityEngine;

public class LoadLevelState : IState
{
    private readonly GameStateMachine _gameStateMachine;

    public LoadLevelState(GameStateMachine gameStateMachine)
    {
        _gameStateMachine = gameStateMachine;
    }

    public void Enter()
    {
        LoadLevel();
        _gameStateMachine.Enter<GameLoopState>();
    }

    public void Exit()
    {

    }

    private void LoadLevel()
    {
        Debug.Log($"Level Loaded");
    }
}

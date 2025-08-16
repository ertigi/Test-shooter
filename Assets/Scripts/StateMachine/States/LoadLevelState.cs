using System;
using UnityEngine;
using Zenject;

public class LoadLevelState : IState
{
    private readonly StateMachine _stateMachine;
    private readonly SceneLoader _sceneLoader;
    private readonly LevelConfig _levelConfig;

    public LoadLevelState(StateMachine stateMachine, SceneLoader sceneLoader, LevelConfig levelConfig)
    {
        _stateMachine = stateMachine;
        _sceneLoader = sceneLoader;
        _levelConfig = levelConfig;
    }

    public void Enter()
    {
        LoadLevel();
    }

    public void Exit()
    {

    }

    private void LoadLevel()
    {
        _sceneLoader.Load(_levelConfig.EnvironmentSceneName, true, OnLoaded);
    }

    private void OnLoaded()
    {
        _stateMachine.Enter<GameLoopState>();
    }
}

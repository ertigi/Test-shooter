using System;
using UnityEngine;
using Zenject;

public class LoadLevelState : IState
{
    private readonly StateMachine _stateMachine;
    private readonly DiContainer _container;
    private readonly SceneLoader _sceneLoader;
    private readonly LevelConfig _levelConfig;
    private readonly CameraContainer _cameraContainer;

    public LoadLevelState(StateMachine stateMachine, DiContainer container, SceneLoader sceneLoader, LevelConfig levelConfig, CameraContainer cameraContainer)
    {
        _stateMachine = stateMachine;
        _container = container;
        _sceneLoader = sceneLoader;
        _levelConfig = levelConfig;
        _cameraContainer = cameraContainer;
    }

    public void Enter()
    {
        LoadLevel();
        CreateCamera();
        CreatePlayer();
    }

    public void Exit()
    {

    }

    private void LoadLevel()
    { 
        _sceneLoader.Load(_levelConfig.EnvironmentSceneName, true, OnLoaded);
    }

    private void CreateCamera()
    {
        var cameraObject = UnityEngine.Object.Instantiate(_cameraContainer.CameraObject);
        _container.Bind<CameraObject>().FromInstance(cameraObject).AsSingle();
    }

    private void CreatePlayer()
    {
        _container.Bind<PlayerController>().AsSingle().NonLazy();
        _container.Resolve<BotFactory>().SetPlayerTransform(_container.Resolve<PlayerController>().Transform);
    }

    private void OnLoaded()
    {
        _stateMachine.Enter<GameLoopState>();
    }
}

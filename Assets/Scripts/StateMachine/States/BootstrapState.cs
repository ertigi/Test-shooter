using System;
using UnityEngine;
using Zenject;

public class BootstrapState : IState
{
    private readonly GameStateMachine _gameStateMachine;
    private readonly DiContainer _container;

    public BootstrapState(GameStateMachine gameStateMachine, DiContainer container)
    {
        _gameStateMachine = gameStateMachine;
        _container = container;
    }

    public void Enter()
    {
        RegusterServices();
        _gameStateMachine.Enter<LoadProgressState>();
    }

    public void Exit()
    {

    }

    private void RegusterServices()
    {
        _container.BindInterfacesAndSelfTo<InputService>().AsSingle();

        CreateTickManager();
    }

    private void CreateTickManager()
    {
        var tickManager = _container.InstantiateComponentOnNewGameObject<TickManager>("TickManager");
        tickManager.transform.SetParent(ProjectContext.Instance.transform, false);

        _container.Bind<TickManager>().FromInstance(tickManager).AsSingle();
    }
}

using System;
using UnityEngine;
using Zenject;

public class BootstrapState : IState
{
    private readonly StateMachine _stateMachine;
    private readonly DiContainer _container;

    public BootstrapState(StateMachine stateMachine, DiContainer container)
    {
        _stateMachine = stateMachine;
        _container = container;
    }

    public void Enter()
    {
        RegusterServices();
        _stateMachine.Enter<LoadProgressState>();
    }

    public void Exit()
    {

    }

    private void RegusterServices()
    {
        _container.BindInterfacesAndSelfTo<InputService>().AsSingle();
        _container.Bind<SceneLoader>().AsSingle();
        _container.Bind<CursorService>().AsSingle();

        CreateTickManager();
    }

    private void CreateTickManager()
    {
        var tickManager = _container.InstantiateComponentOnNewGameObject<TickManager>("TickManager");
        tickManager.transform.SetParent(ProjectContext.Instance.transform, false);

        _container.Bind<TickManager>().FromInstance(tickManager).AsSingle();
    }
}

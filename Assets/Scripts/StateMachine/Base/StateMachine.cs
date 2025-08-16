using System;
using System.Collections.Generic;
using Zenject;

public class StateMachine
{
    private readonly DiContainer _container;
    private IState _activeState;

    public StateMachine(DiContainer container)
    {
        _container = container;
    }

    public void Enter<TState>() where TState : IState
    {
        _activeState?.Exit();

        var state = _container.Instantiate<TState>();
        _activeState = state;

        state.Enter();
    }
}
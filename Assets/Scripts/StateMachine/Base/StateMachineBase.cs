using System;
using System.Collections.Generic;

public class StateMachineBase
{
    protected Dictionary<Type, IExitableState> _states;
    protected IExitableState _activeState;

    public virtual void Enter<TState>() where TState : class, IState
    {
        IState state = ChangeState<TState>();
        state.Enter();
    }

    private TState ChangeState<TState>() where TState : class, IExitableState
    {
        _activeState?.Exit();

        TState state = GetState<TState>();
        _activeState = state;

        return state;
    }

    public IExitableState GetActiveState()
    {
        return _activeState;
    }

    private TState GetState<TState>() where TState : class, IExitableState =>
      _states[typeof(TState)] as TState;
}
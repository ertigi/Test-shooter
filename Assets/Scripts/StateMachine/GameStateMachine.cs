using System;
using System.Collections.Generic;
using Zenject;

public class GameStateMachine : UpdateStateMachine, IInitializable
{
    private readonly StateFactory _stateFactory;

    public GameStateMachine(StateFactory stateFactory)
    {
        _stateFactory = stateFactory;
    }

    public void Initialize()
    {
        _states = new Dictionary<Type, IExitableState>
        {
            [typeof(BootstrapState)] = _stateFactory
            .CreateState<BootstrapState>(),
            [typeof(LoadProgressState)] = _stateFactory
            .CreateState<LoadProgressState>(),
            [typeof(LoadMetaState)] = _stateFactory
            .CreateState<LoadMetaState>(),
            [typeof(LoadLevelState)] = _stateFactory
            .CreateState<LoadLevelState>(),
            [typeof(GameLoopState)] = _stateFactory
            .CreateState<GameLoopState>()
        };

        Enter<BootstrapState>();
    }
}

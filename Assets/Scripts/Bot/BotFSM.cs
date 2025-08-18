using System;
using System.Collections.Generic;
using UnityEngine;

public class BotFSM
{
    private readonly Dictionary<Type, IBotState> _states;
    public IBotState CurrentState { get; private set; }

    public BotFSM(Bot bot, Transform player)
    {
        _states = new()
        {
            { typeof(BotRespawnState), new BotRespawnState(bot) },
            { typeof(BotMovementState), new BotMovementState(bot, player) },
            { typeof(BotAttackState), new BotAttackState(bot, player) },
            { typeof(BotDieState), new BotDieState(bot) }
        };
    }

    public void Enter<T>() where T : IBotState
    {
        CurrentState?.Exit();
        CurrentState = _states[typeof(T)];
        CurrentState.Enter();
    }

    public void Update() => CurrentState?.Update();
}

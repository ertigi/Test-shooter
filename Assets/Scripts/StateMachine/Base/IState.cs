public interface IState : IExitableState
{
    void Enter();
}

public interface IPayloadedState<TPayload> : IExitableState
{
    void Enter(TPayload payload);
}

public interface IExitableState
{
    void Exit();
}

public interface IUpdateState : IState
{
    void Update();
}

public interface IFixedUpdateState : IState
{
    void FixedUpdate();
}

public interface ILateUpdateState : IState
{
    void LateUpdate();
}